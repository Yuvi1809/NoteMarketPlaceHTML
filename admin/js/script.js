function show(input){
	if(input.attr("type")=="password"){
		input.attr("type","text");
	}else{
		input.attr("type","password");
	}
}
$(".toggle-password").click(function(){
	var input =$($(this).attr("toggle"));
	show(input);
})
/*mobile navigation*/
$(function () {
    $("#mobile-nav-open-btn").click(function () {
        $("#mobile-nav").css("height", "100%");
    });
    $("#mobile-nav-close-btn, #mobile-nav a").click(function () {
        $("#mobile-nav").css("height", "0%");
    });
});