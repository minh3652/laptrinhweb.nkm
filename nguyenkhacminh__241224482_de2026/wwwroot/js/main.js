// BookHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });
    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
    $('.search-box input').on('focus', function () { $(this).select(); });
});
$(document).ready(function () {
    $(document).on("click", ".loc-the-loai", function (e) {
        e.preventDefault();

        var maTl = $(this).data("id");

        $.ajax({
            url: "/Home/LocSachTheoTheLoai",
            type: "GET",
            data: { maTl: maTl },
            success: function (result) {
                $("#mainContent").html(result);
            },
            error: function () {
                alert("Khong the tai danh sach sach!");
            }
        });
    });
});