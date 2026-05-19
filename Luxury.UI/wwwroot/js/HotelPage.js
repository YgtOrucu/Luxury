document.addEventListener("DOMContentLoaded", function () {

    const skeletonContainer = document.getElementById("skeletonContainer");
    const realHotelsContainer = document.getElementById("realHotelsContainer");

    if (skeletonContainer && realHotelsContainer) {
        setTimeout(() => {
            skeletonContainer.classList.add("d-none-custom");
            realHotelsContainer.classList.remove("d-none-custom");

            const cards = realHotelsContainer.querySelectorAll(".animate-card");
            cards.forEach((card, index) => {
                card.style.animation = `fadeIn 0.5s ease forward`;
                card.style.animationDelay = `${index * 0.1}s`;
            });
        }, 900);
    }

    const backToTopBtn = document.getElementById("backToTop");
    if (backToTopBtn) {
        window.addEventListener("scroll", function () {
            if (window.scrollY > 400) {
                backToTopBtn.classList.add("show");
            } else {
                backToTopBtn.classList.remove("show");
            }
        });

        backToTopBtn.addEventListener("click", function () {
            window.scrollTo({
                top: 0,
                behavior: "smooth"
            });
        });
    }

    const checkInInput = document.getElementById("checkIn");
    const checkOutInput = document.getElementById("checkOut");

    if (checkInInput && checkOutInput) {
        const today = new Date().toISOString().split('T')[0];
        checkInInput.setAttribute('min', today);

        checkInInput.addEventListener("change", function () {
            checkOutInput.setAttribute('min', checkInInput.value);
            if (checkOutInput.value && checkOutInput.value < checkInInput.value) {
                checkOutInput.value = checkInInput.value;
            }
        });
    }

    (function initNavbar() {
        const nav = document.getElementById('mainNav');
        if (!nav) return;
        const navbarCollapse = document.getElementById('navbarContent');
        let ticking = false;

        function onScroll() {
            const scrollY = window.scrollY;

            if (scrollY > 60 || (navbarCollapse && navbarCollapse.classList.contains('show'))) {
                nav.classList.add('nav-scrolled');
            } else {
                nav.classList.remove('nav-scrolled');
            }
        }
        window.addEventListener('scroll', function () {
            if (!ticking) {
                window.requestAnimationFrame(function () {
                    onScroll();
                    ticking = false;
                });
                ticking = true;
            }
        }, { passive: true });

        if (navbarCollapse) {
            navbarCollapse.addEventListener('show.bs.collapse', function () {
                nav.classList.add('nav-scrolled');
            });

            navbarCollapse.addEventListener('hidden.bs.collapse', function () {
                onScroll();
            });
        }

        document.addEventListener('DOMContentLoaded', onScroll);
        onScroll();
    })();
});