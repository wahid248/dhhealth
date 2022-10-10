$(document).ready(function () {
    var index;
    $('.readmoreBtn').on('click', function () {
        index = $(this).data('index');
        $('.modal_multi[data-index="' + index + '"]').css('display', 'block');
        $('body').css('overflow', 'hidden');
        $("#goTopButton").hide();
        window.location.hash = index;
    });
   
    //dynamically show News 
    $(window).on('hashchange', function () {
        newsId = window.location.hash.substring(1);
        $('body').find(`.readmoreBtn[data-index=${newsId}]`).get(0).click();
    });
    //manually tiggering it if we have hash part in URL
    if (window.location.hash) {
        $(window).trigger('hashchange')
    }
    //close modal
    $('.close_modal').on('click', function () {
        $('.modal_multi[data-index="' + index + '"]').css('display', 'none');
        history.pushState({}, null, window.location.href.split('#')[0]);
        $('body').css('overflow', 'auto');
        $("#goTopButton").show();
    });
    $('.modal').on('click', function () {
        $('.modal_multi[data-index="' + index + '"]').css('display', 'none');
        history.pushState({}, null, window.location.href.split('#')[0]);
        $("#goTopButton").show();
        document.body.style.overflow = "auto";
    });

});


