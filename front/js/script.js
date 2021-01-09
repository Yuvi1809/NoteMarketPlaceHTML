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
$('#myModal').on('shown.bs.modal', function () {
  $('#myInput').trigger('focus')
})
/*faq*/
$(document).ready(function () {
  $(".faq-second-border").hide();
  for (let i = 1; i <= 7; i++) {
    $("#faq-" + i).click(function () {
      $("#faq-" + i).hide(500);
      $("#faq-part-" + i).slideToggle(500);
    });

    $("#faq-part-" + i).click(function () {
      $("#faq-part-" + i).slideUp(500, () => {
        $("#faq-" + i).show(500);
      });
    });
  }
});
/*mobile navigation*/
$(function () {
    $("#mobile-nav-open-btn").click(function () {
        $("#mobile-nav").css("height", "100%");
    });
    $("#mobile-nav-close-btn, #mobile-nav a").click(function () {
        $("#mobile-nav").css("height", "0%");
    });
});