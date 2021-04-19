

/**
 * @param document: the Document's object which save cookie
 * @param name:		cookie's name
 * @param hours:	cookie's avilable time
 * @param path:		cookie's path
 * @param domain:	cookie's domain
 * @param secure:	if cookie needs a safe link
**/

function Cookie(document, name, hours, path, domain, secure){
	this.$document = document;
	this.$name = name;
	if(hours)
		this.$expiration= new Date((new Date()).getTime()+hours*3600000);
	else
		this.$expiration = null;
		
	if(path)
		this.$path = path;
	else
		this.$path = null;
		
	if(domain)
		this.$domain = domain;
	else
		this.$domain = null;
		
	if(secure)
		this.$secure = true;
	else
		this.$secure = false;
}


Cookie.prototype.store=function(){
	var cookieval = "";
	for(var prop in this){
		
		if((prop.charAt(0) == '$') || ((typeof this[prop])=='function'))
			continue;
			
		if(cookieval!="")
			cookieval += '&';
			
		cookieval+= prop + ":" + escape(this[prop]);
	}
	
	var cookie = this.$name + '=' + cookieval;
	
	if(this.$expiration)
		cookie+=';expires='+this.$expiration.toGMTString();
		
	if(this.$path)
		cookie+=';path='+this.$path;
		
	if(this.$domain)
		cookie+=';domain='+this.$domain;
		
	if(this.$secure)
		cookie+=';secure'
		
		
	this.$document.cookie=cookie;
}


Cookie.prototype.load=function(){
	var allcookies=this.$document.cookie;
	
	if(allcookies=="")
		return false;
		
	var start=allcookies.indexOf(this.$name+"=");
	
	if(start==-1)
		return false;
		
	start+=this.$name.length + 1;
	
	var end=allcookies.indexOf(";",start);
	
	if(end==-1)
		end=allcookies.length;
		
	var cookieval=allcookies.substring(start,end);
	
	var a=cookieval.split('&');
	for(var i=0;i<a.length;i++)
		a[i]=a[i].split(':');
	
	for(var i=0; i< a.length; i++)
		this[a[i][0]]=unescape(a[i][1]);
	
	return true;
}

Cookie.prototype.remove=function(){
	var cookie;
	cookie=this.$name+"=";
	
	if(this.$path)
		cookie+=';path='+this.$path;
		
	if(this.$domain)
		cookie+=';domain='+this.$domain;
		
	cookie+=';expires=Fri, 02-Jan-1970 00:00:00 GMT';
	
	this.$document.cookie=cookie;
}