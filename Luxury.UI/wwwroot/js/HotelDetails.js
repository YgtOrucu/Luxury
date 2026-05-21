
(function () {
    'use strict';

    /* ── Navbar scroll state ── */
    var nav = document.getElementById('mainNav');
    function updateNav() {
        nav.classList.toggle('nav-scrolled', window.scrollY > 50);
    }
    window.addEventListener('scroll', updateNav, { passive: true });
    updateNav();

    /* ── Back-to-top toggle ── */
    var backBtn = document.getElementById('backToTop');
    window.addEventListener('scroll', function () {
        backBtn.classList.toggle('show', window.scrollY > 400);
    }, { passive: true });
    backBtn.addEventListener('click', function () {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });

    /* ── Smooth scroll for all anchor links ── */
    document.querySelectorAll('a[href^="#"]').forEach(function (anchor) {
        anchor.addEventListener('click', function (e) {
            var targetId = this.getAttribute('href');
            if (targetId === '#') return;
            var target = document.querySelector(targetId);
            if (target) {
                e.preventDefault();
                var navH = nav ? nav.offsetHeight : 72;
                window.scrollTo({ top: target.getBoundingClientRect().top + window.scrollY - navH - 16, behavior: 'smooth' });
            }
        });
    });

    /* ── Hero background slideshow ── */
    var heroBg = document.getElementById('heroBg');
    if (heroBg) {
        var slides = heroBg.querySelectorAll('img');
        if (slides.length > 1) {
            var currentSlide = 0;
            setInterval(function () {
                slides[currentSlide].classList.remove('active');
                currentSlide = (currentSlide + 1) % slides.length;
                slides[currentSlide].classList.add('active');
            }, 4500);
        }
    }

    /* ─────────────────────────────────────────────
   Gallery thumbnail interaction
───────────────────────────────────────────── */
    var galleryMain = document.getElementById('galleryMain');
    var thumbsContainer = document.getElementById('galleryThumbs');
    var currentPhotoNum = document.getElementById('currentPhotoNum');

    if (galleryMain && thumbsContainer) {
        if (galleryMain.src.includes('max300')) {
            galleryMain.src = galleryMain.src.replace('max300', 'max700');
        }

        thumbsContainer.querySelectorAll('.gallery-thumb').forEach(function (thumb, idx) {
            function selectThumb() {
                var originalSrc = thumb.src;

                var highResSrc = originalSrc.includes('max300')
                    ? originalSrc.replace('max300', 'max700')
                    : originalSrc;

                galleryMain.src = highResSrc;
                galleryMain.alt = thumb.alt;

                thumbsContainer.querySelectorAll('.gallery-thumb').forEach(function (t) {
                    t.classList.remove('active');
                });
                thumb.classList.add('active');
                if (currentPhotoNum) currentPhotoNum.textContent = idx + 1;
            }

            thumb.addEventListener('click', selectThumb);

            thumb.addEventListener('keydown', function (e) {
                if (e.key === 'Enter' || e.key === ' ') {
                    e.preventDefault();
                    selectThumb();
                }
            });
        });
    }

})();

/* ── Currency tab switcher (price card) ── */
function switchCurrency(type) {
    var panelOriginal = document.getElementById('panel-original');
    var panelTry = document.getElementById('panel-try');
    var tabOriginal = document.getElementById('tab-original');
    var tabTry = document.getElementById('tab-try');

    if (!panelOriginal || !panelTry) return;

    if (type === 'try') {
        panelOriginal.style.display = 'none';
        panelTry.style.display = '';
        tabTry.classList.add('active');
        tabTry.setAttribute('aria-selected', 'true');
        tabOriginal.classList.remove('active');
        tabOriginal.setAttribute('aria-selected', 'false');
    } else {
        panelTry.style.display = 'none';
        panelOriginal.style.display = '';
        tabOriginal.classList.add('active');
        tabOriginal.setAttribute('aria-selected', 'true');
        tabTry.classList.remove('active');
        tabTry.setAttribute('aria-selected', 'false');
    }
}