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

    // Mobile menu toggle - Tamamen özel çözüm
    let isMenuOpen = false;
    
    $('.navbar-toggler').off('click').on('click', function(e) {
        e.preventDefault();
        e.stopPropagation();
        
        console.log('Toggler tıklandı, mevcut durum:', isMenuOpen);
        
        const $toggler = $(this);
        const $collapse = $('#navbarNav');
        
        if (isMenuOpen) {
            // Menüyü kapat
            $collapse.removeClass('show');
            $toggler.removeClass('active');
            $toggler.attr('aria-expanded', 'false');
            isMenuOpen = false;
            console.log('Menü kapatıldı');
        } else {
            // Menüyü aç
            $collapse.addClass('show');
            $toggler.addClass('active');
            $toggler.attr('aria-expanded', 'true');
            isMenuOpen = true;
            console.log('Menü açıldı');
        }
    });
    
    // Menü dışında tıklandığında kapat
    $(document).off('click.navbar').on('click.navbar', function(e) {
        if (isMenuOpen && !$(e.target).closest('.navbar').length) {
            console.log('Dışarı tıklandı, menü kapatılıyor');
            $('#navbarNav').removeClass('show');
            $('.navbar-toggler').removeClass('active').attr('aria-expanded', 'false');
            isMenuOpen = false;
        }
    });
    
    // Nav linklerine tıklandığında menüyü kapat
    $('.navbar-nav .nav-link').off('click.navbar').on('click.navbar', function() {
        if (isMenuOpen && $(window).width() < 992) {
            console.log('Nav link tıklandı, menü kapatılıyor');
            $('#navbarNav').removeClass('show');
            $('.navbar-toggler').removeClass('active').attr('aria-expanded', 'false');
            isMenuOpen = false;
        }
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