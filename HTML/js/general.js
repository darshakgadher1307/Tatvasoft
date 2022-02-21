$(document).ready(function(){
    $(window).scroll(function(){
        var scroll = $(window).scrollTop();
        if (scroll > 0) {
          $("header").addClass("fixed");
        }
  
        else{
            $("header").removeClass("fixed");  	
        }
    })

  $(".nav-tabs a").click(function(){
    $(this).tab('show');
  });

  $(window).resize(function(){
    if($(window).width()<1200){
      $("#upcoming-service-menu-table").addClass("flex-column");
      $("#upcoming-service-menu").removeClass("flex-column");
      $("#upcoming-service-menu").addClass("flex-row justify-content-center");
    }
    else{
      $("#upcoming-service-menu-table").removeClass("flex-column");
      $("#upcoming-service-menu").addClass("flex-column");
      $("#upcoming-service-menu").removeClass("flex-row justify-content-center");
    } 
    if($(window).width()<992){
      $("#nav-line").removeClass("line");
      $("#l1").removeClass("line");
    }
    else{
      $("#nav-line").addClass("line");
      $("#l1").addClass("line");
    }
    if($(window).width()<718){
      $("tr#service").addClass("d-flex");
      $("tr#service").addClass("flex-column");
      $("td").addClass("text-center");
      $("#table-row-number").addClass("flex-column")
    }
    else{
      $("tr,#service").removeClass("d-flex");
      $("tr,#service").removeClass("flex-column");
      $("td").removeClass("text-center");
      $("#table-row-number").removeClass("flex-column")
    }
    if($(window).width()<940){
      $("#admin-user").addClass("flex-column");
      $(".admin-menu button").addClass("show");
      $(".admin-menu button").removeClass("hide");
      $(".admin-menu .navbar").addClass("collapse");
      $(".admin-menu .navbar .nav").removeClass("flex-column");
    }
    else{
      $("#admin-user").removeClass("flex-column");
      $(".admin-menu button").removeClass("show");
      $(".admin-menu button").addClass("hide");
      $(".admin-menu .navbar").removeClass("collapse");
      $(".admin-menu .navbar .nav").addClass("flex-column");
    }
    if($(window).width()<660){
      $("tr#admin").addClass("d-flex");
      $("tr#admin").addClass("flex-column");
    }
    else{
      $("tr,#admin").removeClass("d-flex");
      $("tr,#admin").removeClass("flex-column");
    }
  });

  $('#AddAddressButton').click(function(){
    $('#AddAddressForm').removeClass('hide');
    $('#AddAddressForm').addClass('show');
    $('#AddAddressButton').addClass('hide');
  });

  $('#AddAddressCancel').click(function(){
    $('#AddAddressForm').removeClass('show');
    $('#AddAddressForm').addClass('hide');
    $('#AddAddressButton').removeClass('hide');
  });

  $('#InvoiceCheckbox').click(function(){
    if($('#InvoiceCheckbox').prop('checked')){
      $('#invoice-form').removeClass('hide');
    }
    else
    {
      $('#invoice-form').addClass('hide');
    }
  });

  $(window).resize(function(){
    if($(window).width()<901){
      $('#payment-modal').addClass('modal');
      $('#payment-modal').addClass('fade');
      $('#modal-button').removeClass('hide');
      $('#modal-close').removeClass('hide');
    }
    else{
      $('#payment-modal').removeClass('modal');
      $('#payment-modal').removeClass('fade');
      $('#modal-button').addClass('hide');
      $('#modal-close').addClass('hide');
    }
  });

  $('#payment-tabs li a').not('.active').addClass('disabled');

  $('#check-btn').click(function(){
    $('#SchedulePlan-tab').removeClass('disabled').addClass('active');
    $('#SetupService-tab').removeClass('active').addClass('active-after');
    $('#SetupService').removeClass('show active')
    $('#SchedulePlan').addClass('show active');
    });

  $('#continue-btn').click(function(){
    $('#YourDetails-tab').removeClass('disabled').addClass('active');
    $('#SchedulePlan-tab').removeClass('active').addClass('active-after');
    $('#SchedulePlan').removeClass('show active')
    $('#YourDetails').addClass('show active');
  });

  $('#continue-btn2').click(function(){
    $('#payment-tabs li a').next().removeClass('active-after');
    $('#MakePayment-tab').removeClass('disabled').addClass('active');
    $('#YourDetails-tab').removeClass('active').addClass('active-after');
    $('#YourDetails').removeClass('show active')
    $('#MakePayment').addClass('show active');
  });

//   var d = $('.extra-container .extra-check input[type="checkbox"]');
//   d.each(function(){
//     d.click(function(){
//     var c = d.attr('name');
//     var cb = '#checkbox-'+c;
//     var x = '#extra-'+c;
//     if($(cb).prop('checked'))
//     {
//       $(x).removeClass('hide');
//     }
//     else
//     {
//       $(x).addClass('hide');
//     }
//     c="";
//     cb="";
//     x="";
//   });
// });

  var a1 = 0;
  var a2 = 0;
  var a3 =0;
  var a4 = 0;
  var a5 = 0;


  $('#checkbox-1').click(function () {
    if ($('#checkbox-1').prop('checked')) {
      $('#extra-1').removeClass('hide');
      a1 = 1;
    }
    else {
      $('#extra-1').addClass('hide');
      a1 = 0;
    }
    xyz();
  });
  $('.extra-check').click(function () {
    if ($('#checkbox-2').prop('checked')) {
      $('#extra-2').removeClass('hide');
      a2 = 1;
    }
    else {
      $('#extra-2').addClass('hide');
      a2 = 0;
    }
    xyz();
  });
  $('.extra-check').click(function () {
    if ($('#checkbox-3').prop('checked')) {
      $('#extra-3').removeClass('hide');
      a3 = 1;
    }
    else {
      $('#extra-3').addClass('hide');
      a3 = 0;
    }
    xyz();
  });
  $('.extra-check').click(function () {
    if ($('#checkbox-4').prop('checked')) {
      $('#extra-4').removeClass('hide');
      a4 = 1;
    }
    else {
      $('#extra-4').addClass('hide');
      a4 = 0;
    }
    xyz();
  });
  $('.extra-check').click(function () {
    if ($('#checkbox-5').prop('checked')) {
      $('#extra-5').removeClass('hide');
      a5 = 1;
    }
    else {
      $('#extra-5').addClass('hide');
      a5 = 0;
    }
    xyz();
  });

  function xyz(){
  if(a1 == 1 || a2 == 1 || a3 ==1 || a4 == 1 || a5 == 1)
  {
    $('#extra').removeClass('hide');
  }
  else if(a1 == 0 && a2 == 0 && a3 ==0 && a4 == 0 && a5 == 0)
  {
    $('#extra').addClass('hide');
  }
}
  
});

