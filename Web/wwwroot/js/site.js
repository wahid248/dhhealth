$(document).ready(function () {
	var url = window.location;
	$('.navbar-light .navbar-nav a[href="' + url + '"]').parent().addClass('active');
	$('.navbar-light .navbar-nav a').filter(function () {
		return this.href == url;
	}).parent().addClass('active');
	$(".animated-body").animate({
		opacity: 1
	}, 400)

	$('.readBtn').on("click", function (e) {
		e.preventDefault();
		$('#readMorePopup').appendTo("body").modal('show');
	});

	//play video on popup modal
	$('.player').on("click", function (e) {
		e.preventDefault();

		$('#videoPopup').appendTo("body").modal('show');
		$('#videoPopup iframe').prop('src', 'https://www.youtube.com/embed/avEG01UsiSM');
	});
	//stop playing video
	$('#videoPopup').on('hidden.bs.modal', function () {

		$('#videoPopup iframe').prop('src', '');
	});

	//go to top button
	var gotopbtn = $('#goTopButton');
	$(window).scroll(function () {
		if ($(window).scrollTop() > 300) {
			gotopbtn.addClass('show');
		} else {
			gotopbtn.removeClass('show');
		}
	});
	gotopbtn.on('click', function (e) {
		e.preventDefault();
		$('html, body').animate({ scrollTop: 0 }, '300');
	});

	//Lazy loading
	echo.init({
		callback: function (elem, op) {
			$(elem).next().hide();
		}
	});

	//hamburger click
	$('.hamburger input').on("click", function (e) {
		$('.nav-3').css('height', $(this).is(":checked") ? '100%' : '70%');
	});
});



