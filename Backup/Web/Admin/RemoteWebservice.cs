using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Dianda.Web
{
    public class RemoteWebservice
    {

        #region remote webservice

        /// <summary>
        /// 序列化二进制数据流
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializeObject(object obj)
        {
            byte[] rst;
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, obj);
            rst = memoryStream.GetBuffer();
            memoryStream.Dispose();
            memoryStream.Close();
            return rst;
        }

        /// <summary>
        /// 反序列化二进制数据流
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object DeserializeObject(byte[] bytes)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(new MemoryStream(bytes));
        }

        #region InvokeWebService 动态调用web服务

        public static object InvokeWebService(string url, string methodname, object[] args)
        {
            return InvokeWebService(url, null, methodname, args);
        }

        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            if ((classname == null) || (classname == ""))
            {
                classname = GetWsClassName(url);
            }

            try
            {
                //获取WSDL
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);

                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                //ICodeCompiler icc = csc.CreateCompiler();     //已过时

                //设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                //CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);     //已过时
                CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                //生成代理实例，并调用方法
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodname);

                return mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }

        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        #endregion

        public static object GetRemoteWebseviceResult(string url, string serviceName, object[] args)
        {
            return InvokeWebService(url, serviceName, args);
        }

        #endregion
    }
}
