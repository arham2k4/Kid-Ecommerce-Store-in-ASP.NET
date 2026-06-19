$(document).ready(function(){

    $(".product-card").hover(function(){

        $(this).css(
            "box-shadow",
            "0 5px 20px rgba(0,0,0,.3)"
        );

    }, function(){

        $(this).css(
            "box-shadow",
            "none"
        );

    });

});