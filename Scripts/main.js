$(document).ready(function() {
    // Navbar scroll effect
    $(window).scroll(function() {
        if ($(this).scrollTop() > 50) {
            $('.navbar').addClass('navbar-scrolled');
            $('.navbar').css('background-color', 'rgba(33, 37, 41, 0.95)');
        } else {
            $('.navbar').removeClass('navbar-scrolled');
            $('.navbar').css('background-color', '');
        }
    });

    // Smooth scrolling for anchor links
    $('a[href*="#"]').not('[href="#"]').not('[href="#0"]').click(function(event) {
        if (
            location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') 
            && 
            location.hostname == this.hostname
        ) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                event.preventDefault();
                $('html, body').animate({
                    scrollTop: target.offset().top - 70
                }, 1000);
            }
        }
    });

    // Newsletter form submission
    $('.newsletter-form').submit(function(e) {
        e.preventDefault();
        const email = $(this).find('input[type="email"]').val();
        
        // Here you would typically send the email to your server
        // For now, we'll just show a success message
        $(this).html('<div class="alert alert-success">Bültenimize başarıyla abone oldunuz!</div>');
    });

    // Add animation to cards when they come into view
    const animateCards = () => {
        $('.card').each(function() {
            const cardTop = $(this).offset().top;
            const windowHeight = $(window).height();
            const scrollTop = $(window).scrollTop();

            if (cardTop < windowHeight + scrollTop - 100) {
                $(this).addClass('animate__animated animate__fadeInUp');
            }
        });
    };

    // Initial check for cards in view
    animateCards();

    // Check for cards in view on scroll
    $(window).scroll(function() {
        animateCards();
    });

    // Add hover effect to social media icons
    $('.social-links a').hover(
        function() {
            $(this).addClass('text-primary');
        },
        function() {
            $(this).removeClass('text-primary');
        }
    );

    // Mobile menu toggle animation
    $('.navbar-toggler').click(function() {
        $(this).toggleClass('active');
    });

    // Add loading animation to images
    $('img').on('load', function() {
        $(this).addClass('loaded');
    });

    // Add active class to current nav item
    const currentLocation = location.href;
    $('.nav-link').each(function() {
        if ($(this).attr('href') === currentLocation) {
            $(this).addClass('active');
        }
    });
}); 