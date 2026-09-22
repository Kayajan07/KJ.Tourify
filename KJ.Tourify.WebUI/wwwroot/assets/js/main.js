(function ($) {
    "use strict";

    var reduceMotion = window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    if (reduceMotion) {
        $('[data-bs-ride="carousel"]').removeAttr('data-bs-ride').attr('data-bs-interval', 'false');
    }

    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner(0);


    $(window).scroll(function () {
        if ($(this).scrollTop() > 45) {
            $('.navbar').addClass('sticky-top shadow-sm');
        } else {
            $('.navbar').removeClass('sticky-top shadow-sm');
        }
    });


    $(".InternationalTour-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        center: false,
        dots: true,
        loop: true,
        margin: 25,
        nav : false,
        navText : [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsiveClass: true,
        responsive: {
            0:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:2
            },
            1200:{
                items:3
            }
        }
    });


    $(".packages-carousel").owlCarousel({
        autoplay: !reduceMotion,
        smartSpeed: 1000,
        center: false,
        dots: false,
        loop: true,
        margin: 25,
        mouseDrag: false,
        touchDrag: false,
        pullDrag: false,
        nav : true,
        navText : [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsiveClass: true,
        responsive: {
            0:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:2
            },
            1200:{
                items:3
            }
        }
    });

    $(document).on('click', 'a.tour-detail-link', function (e) {
        var targetUrl = $(this).attr('href');
        if (!targetUrl) {
            return;
        }

        e.preventDefault();
        window.location.assign(targetUrl);
    });


    $(".testimonial-carousel").each(function () {
        var itemCount = $(this).children().length;

        $(this).owlCarousel({
            autoplay: !reduceMotion,
            smartSpeed: 1000,
            center: true,
            dots: true,
            loop: itemCount > 3,
            margin: 25,
            nav : true,
            navText : [
                '<i class="bi bi-arrow-left"></i>',
                '<i class="bi bi-arrow-right"></i>'
            ],
            responsiveClass: true,
            responsive: {
                0:{
                    items:1
                },
                768:{
                    items:2
                },
                992:{
                    items:2
                },
                1200:{
                    items:3
                }
            }
        });
    });

    
   $(window).scroll(function () {
    if ($(this).scrollTop() > 300) {
        $('.back-to-top').fadeIn('slow');
    } else {
        $('.back-to-top').fadeOut('slow');
    }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    }); 

})(jQuery);

