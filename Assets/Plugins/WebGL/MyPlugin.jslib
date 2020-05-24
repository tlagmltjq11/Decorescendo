var PluginName = {
//Function without argument 
	saveww: function(arg){
		var ele = document.getElementById("node");
		ele.addEventListener("click", function() {
   		saveweb(Pointer_stringify(arg));
		}, false);
		ele.click();
	},
	loadweb: function(){
		var ele = document.getElementById("nodel");
		ele.addEventListener("click", function() {
   		loadunity();
		}, false);
		ele.click();
	}
};

mergeInto(LibraryManager.library, PluginName);