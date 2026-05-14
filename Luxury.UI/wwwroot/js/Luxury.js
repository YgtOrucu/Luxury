'use strict';

function formatCurrency(value, currency = '₺') {
    if (value === null || value === undefined || isNaN(value)) return '—';
    return currency + Number(value).toLocaleString('tr-TR', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}

function formatChange(change) {
    if (change === null || change === undefined || isNaN(change)) {
        return { text: '', cls: '' };
    }

    const sign = change >= 0 ? '+' : '';
    return {
        text: `${sign}${Number(change).toFixed(2)}%`,
        cls: change >= 0 ? 'up' : 'down'
    };
}

function formatUpdatedAt() {
    const now = new Date();
    const hh = String(now.getHours()).padStart(2, '0');
    const mm = String(now.getMinutes()).padStart(2, '0');
    return `Son güncelleme: ${hh}:${mm}`;
}

function weatherEmoji(icon) {
    const map = {
        sun: '☀️',
        cloudy: '☁️',
        rain: '🌧️',
        storm: '⛈️',
        snow: '❄️',
        fog: '🌫️',
        partlycloudy: '⛅',
        wind: '💨',
    };
    return map[icon] || '🌡️';
}

function el(id) {
    return document.getElementById(id);
}

/* ================= NAVBAR ================= */
(function initNavbar() {
    const nav = el('mainNav');
    if (!nav) return;

    let ticking = false;

    function onScroll() {
        const scrollY = window.scrollY;

        if (scrollY > 60) {
            nav.classList.add('nav-scrolled');
        } else {
            nav.classList.remove('nav-scrolled');
        }
    }

    window.addEventListener('scroll', function () {
        if (!ticking) {
            requestAnimationFrame(function () {
                onScroll();
                ticking = false;
            });
            ticking = true;
        }
    }, { passive: true });

    onScroll();
})();

/* ================= SEARCH FORM ================= */
(function initSearchForm() {
    const form = el('hotelSearchForm');
    const errorMsg = el('formError');
    const checkIn = el('checkIn');
    const checkOut = el('checkOut');
    const cityInput = el('city');

    if (!form) return;

    const today = new Date();
    const todayStr = today.toISOString().split('T')[0];

    if (checkIn) checkIn.min = todayStr;
    if (checkOut) checkOut.min = todayStr;

    if (checkIn && checkOut) {
        checkIn.addEventListener('change', function () {
            if (checkIn.value) {
                const minCheckOut = new Date(checkIn.value);
                minCheckOut.setDate(minCheckOut.getDate() + 1);
                checkOut.min = minCheckOut.toISOString().split('T')[0];

                if (checkOut.value && checkOut.value <= checkIn.value) {
                    checkOut.value = '';
                }
            }
        });
    }

    form.addEventListener('submit', function (e) {
        if (!form.checkValidity()) {
            e.preventDefault();

            if (errorMsg) {
                errorMsg.hidden = false;
                errorMsg.textContent = 'Lütfen tüm zorunlu alanları doldurun.';
            }

            const firstInvalid = form.querySelector(':invalid');
            if (firstInvalid) firstInvalid.focus();
            return;
        }

        if (checkIn && checkOut && checkOut.value <= checkIn.value) {
            e.preventDefault();

            if (errorMsg) {
                errorMsg.hidden = false;
                errorMsg.textContent = 'Çıkış tarihi, giriş tarihinden sonra olmalıdır.';
            }

            checkOut.focus();
            return;
        }

        if (errorMsg) errorMsg.hidden = true;

        const btn = form.querySelector('.btn-search-luxury');
        if (btn) {
            btn.disabled = true;
            btn.innerHTML = `
                <span class="search-spinner"></span>
                <span>Aranıyor...</span>
            `;
        }
    });

    form.querySelectorAll('.form-control-luxury').forEach(input => {
        input.addEventListener('input', () => {
            if (errorMsg) errorMsg.hidden = true;
        });
    });

    if (cityInput) {
        cityInput.addEventListener('blur', () => {
            cityInput.value = cityInput.value.trim();
        });
    }
})();

/* ================= BACK TO TOP ================= */
(function initBackToTop() {
    const btn = document.getElementById('backToTop');
    if (!btn) return;

    let ticking = false;

    window.addEventListener('scroll', function () {
        if (!ticking) {
            requestAnimationFrame(function () {
                btn.classList.toggle("show", window.scrollY > 400);
                ticking = false;
            });
            ticking = true;
        }
    }, { passive: true });

    btn.addEventListener('click', function () {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });
})();

/* ================= SMOOTH SCROLL ================= */
(function initSmoothScroll() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const targetId = anchor.getAttribute('href').slice(1);
            const target = document.getElementById(targetId);

            if (!target) return;

            e.preventDefault();

            const navHeight = parseInt(
                getComputedStyle(document.documentElement)
                    .getPropertyValue('--nav-height') || '72',
                10
            );

            const offsetTop = target.getBoundingClientRect().top + window.scrollY - navHeight - 16;

            window.scrollTo({ top: offsetTop, behavior: 'smooth' });
        });
    });
})();

/* ================= DESTINATION CARDS ================= */
(function initDestinationCards() {
    document.querySelectorAll('.dest-card').forEach(card => {

        card.addEventListener('keydown', function (e) {
            if (e.key === 'Enter' || e.key === ' ') {
                const link = card.querySelector('.dest-btn');
                if (link) {
                    e.preventDefault();
                    link.click();
                }
            }
        });

        card.addEventListener('focusin', () => {
            card.classList.add('card-focused');
        });

        card.addEventListener('focusout', () => {
            card.classList.remove('card-focused');
        });
    });
})();

function formatChange(change) {
    if (change === null || change === undefined || isNaN(change)) {
        return { text: '', cls: '' };
    }

    const sign = change >= 0 ? '+' : '';

    return {
        text: `${sign}${Number(change).toFixed(2)}%`,
        cls: change >= 0 ? 'up' : 'down'
    };
}


/* ================= SPINNER STYLE ================= */
(function injectSpinnerStyle() {
    const style = document.createElement('style');
    style.textContent = `
        .search-spinner {
            display: inline-block;
            width: 14px;
            height: 14px;
            border: 2px solid rgba(14,12,10,0.3);
            border-top-color: #0e0c0a;
            border-radius: 50%;
            animation: spin 0.7s linear infinite;
        }

        @keyframes spin {
            to { transform: rotate(360deg); }
        }

        .card-focused .dest-btn {
            opacity: 1 !important;
            transform: translateY(0) !important;
        }
    `;
    document.head.appendChild(style);
})();