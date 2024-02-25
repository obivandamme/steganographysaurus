// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function preview(input) {
    if (input.files[0]) {
        var uploadimg = new FileReader();
        uploadimg.onload = function (displayimg) {
            $("#image-preview").attr('src', displayimg.target.result).attr('class', 'img-thumbnail');
        }
        uploadimg.readAsDataURL(input.files[0]);
    }
}