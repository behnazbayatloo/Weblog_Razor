// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const imageInput = document.getElementById("imageInput");
    if (imageInput) {
        imageInput.addEventListener("change", function () {
            const file = this.files[0];
            if (file) {
                // بررسی حجم (2MB)
                if (file.size > 2 * 1024 * 1024) {
                    alert("حجم فایل نباید بیشتر از 2 مگابایت باشد.");
                    this.value = "";
                }

                // بررسی فرمت
                if (file.type !== "image/jpeg") {
                    alert("فقط فایل JPEG مجاز است.");
                    this.value = "";
                }
            }
        });
    }
});