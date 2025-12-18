const navbar = document.querySelector('.custom-navbar');
const sections = document.querySelectorAll('.section');
const navLinks = document.querySelectorAll('.nav-link');
const scrollBtn = document.getElementById('scrollTopBtn');
const brand = document.querySelector('.navbar-brand');

if (brand) {
    brand.addEventListener('click', function (e) {
        // Eğer aynı sayfadaysak scroll top gibi davransın
        if (window.location.pathname === '/User/About' || window.location.pathname === '/') {
            e.preventDefault();

            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        }
    });
}


/* NAVBAR SHRINK + SCROLL TOP */
window.addEventListener('scroll', () => {
    let scrollY = window.scrollY;

    // navbar küçülme
    if (scrollY > 80) navbar.classList.add('scrolled');
    else navbar.classList.remove('scrolled');

    // scroll top button
    if (scrollY > 400) scrollBtn.classList.add('show');
    else scrollBtn.classList.remove('show');

    // active menu
    sections.forEach(section => {
        const top = scrollY + 120;
        const offset = section.offsetTop;
        const height = section.offsetHeight;
        const id = section.getAttribute('id');

        if (top >= offset && top < offset + height) {
            navLinks.forEach(link => {
                link.classList.remove('active');
                document
                    .querySelector('.nav-link[href="#' + id + '"]')
                    ?.classList.add('active');
            });
        }
    });
});

/* SMOOTH SCROLL */
navLinks.forEach(link => {
    link.addEventListener('click', e => {
        e.preventDefault();
        const target = document.querySelector(link.getAttribute('href'));
        if (!target) return;

        window.scrollTo({
            top: target.offsetTop - 90,
            behavior: 'smooth'
        });
    });
});

/* SCROLL TO TOP */
scrollBtn.addEventListener('click', () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
});

/* SECTION REVEAL */
const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('show');
        }
    });
}, { threshold: 0.15 });

sections.forEach(section => observer.observe(section));
