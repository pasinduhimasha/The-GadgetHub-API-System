// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<script>
    let currentSlide = 0;
    const slides = document.querySelectorAll(".testimonial-slide");

    function showSlide(index) {
        slides.forEach(slide => slide.classList.remove("active"));
    slides[index].classList.add("active");
  }

    function nextSlide() {
        currentSlide = (currentSlide + 1) % slides.length;
    showSlide(currentSlide);
  }

  document.addEventListener("DOMContentLoaded", () => {
        showSlide(currentSlide);
    setInterval(nextSlide, 6000); // Change every 6 seconds
  });
</script>
