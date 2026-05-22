
    // ── Navbar scroll effect ──────────────────────────────────────
    const mainNav = document.getElementById('mainNav');
    window.addEventListener('scroll', () => {
        mainNav.classList.toggle('scrolled', window.scrollY > 60);
    }, {passive: true });

    // ── Back to top ───────────────────────────────────────────────
    const btt = document.getElementById('backToTop');
    window.addEventListener('scroll', () => {
        btt.classList.toggle('visible', window.scrollY > 400);
    }, {passive: true });
    btt.addEventListener('click', () => window.scrollTo({top: 0, behavior: 'smooth' }));

    // ── Fade-up IntersectionObserver ──────────────────────────────
    const fuEls = document.querySelectorAll('.fade-up');
    const fuObserver = new IntersectionObserver(entries => {
        entries.forEach(e => {
            if (e.isIntersecting) {
                e.target.classList.add('visible');
                fuObserver.unobserve(e.target);
            }
        });
    }, {threshold: 0.12 });
    fuEls.forEach(el => fuObserver.observe(el));

    // ── Hero slider ───────────────────────────────────────────────
    (function () {
        const slides = document.querySelectorAll('.hero-slide');
    const dots = document.querySelectorAll('.hero-dot');
    if (!slides.length) return;
    let current = 0, timer;
    function goTo(idx) {
        slides[current].classList.remove('active');
    dots[current]?.classList.remove('active');
    current = (idx + slides.length) % slides.length;
    slides[current].classList.add('active');
    dots[current]?.classList.add('active');
        }
    function next() {goTo(current + 1); }
    function startAuto() {timer = setInterval(next, 5000); }
    function stopAuto() {clearInterval(timer); }
        dots.forEach((d, i) => d.addEventListener('click', () => {stopAuto(); goTo(i); startAuto(); }));
    startAuto();
    })();

    // ── Room gallery slider ───────────────────────────────────────
    var roomStates = { };
    function slideRoom(idx, dir) {
        var inner = document.getElementById('roomGallery_' + idx);
    if (!inner) return;
    var photos = inner.querySelectorAll('.room-photo');
    if (!photos.length) return;
    if (!roomStates[idx]) roomStates[idx] = 0;
    roomStates[idx] = (roomStates[idx] + dir + photos.length) % photos.length;
    inner.style.transform = 'translateX(-' + (roomStates[idx] * 100) + '%)';
    var counter = document.getElementById('roomCount_' + idx);
    if (counter) counter.textContent = (roomStates[idx] + 1) + ' / ' + photos.length;
    }

    // ── Room policy toggle ────────────────────────────────────────
    function togglePolicy(btn) {
        var body = btn.nextElementSibling;
    var open = body.classList.toggle('open');
    btn.setAttribute('aria-expanded', open);
    var icon = btn.querySelector('.bi-chevron-down, .bi-chevron-up');
    if (icon) icon.className = open ? 'bi bi-chevron-up ms-auto' : 'bi bi-chevron-down ms-auto';
    }
