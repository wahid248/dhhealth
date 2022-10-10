$(document).ready(function () {
    // Get the modal
    var modalparent = document.getElementsByClassName("modal_multi");
    // Get the button that opens the modal
    var modal_btn_multi = document.getElementsByClassName("readmoreBtn");
    // Get the <span> element that closes the modal
    var span_close_multi = document.getElementsByClassName("close_multi");

    for (i = 0; i < modal_btn_multi.length; i++) {
        modal_btn_multi[i].setAttribute('data-index', i);
        modalparent[i].setAttribute('data-index', i);
        span_close_multi[i].setAttribute('data-index', i);

    }
    for (i = 0; i < modal_btn_multi.length; i++) {
        modal_btn_multi[i].onclick = function () {
            var ElementIndex = this.getAttribute('data-index');
            window.location.hash = ElementIndex;
            modalparent[ElementIndex].style.display = "block";
            $("#goTopButton").hide();
            document.body.style.overflow = "hidden";
            $('.hamburger ul').css('display', 'none');
        };
        // on span(x) click, close the modal
        span_close_multi[i].onclick = function () {
            var ElementIndex = this.getAttribute('data-index');
            modalparent[ElementIndex].style.display = "none";
            history.pushState({}, null, window.location.href.split('#')[0]);
            $("#goTopButton").show();
            document.body.style.overflow = "auto";
            $('.hamburger ul').css('display', 'block');
        };

    }
    //show modal on hashchange 
    $(window).on('hashchange', function () {
        Id = window.location.hash.substring(1);
        $('body').find(`.readmoreBtn[data-index=${Id}]`).get(0).click();
    });
    //manually tiggering it if hash part in URL
    if (window.location.hash) {
        $(window).trigger('hashchange')
    }
    // click anywhere close modal
    window.onclick = function (event) {
        if (event.target === modalparent[event.target.getAttribute('data-index')]) {
            history.pushState({}, null, window.location.href.split('#')[0]);
            modalparent[event.target.getAttribute('data-index')].style.display = "none";
            $("#goTopButton").show();
            document.body.style.overflow = "auto";
            $('.hamburger ul').css('display', 'block');
        }
    };
});



