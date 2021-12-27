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
      $("tr").addClass("d-flex");
      $("tr").addClass("flex-column");
      $("td").addClass("text-center");
      $("#table-row-number").addClass("flex-column")
    }
    else{
      $("tr").removeClass("d-flex");
      $("tr").removeClass("flex-column");
      $("td").removeClass("text-center");
      $("#table-row-number").removeClass("flex-column")
    }
  });
});

