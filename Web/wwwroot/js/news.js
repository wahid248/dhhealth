$(document).ready(function () {
    $('.count').each(function () {
        var value = parseInt($(this).text().replace(/\D/g, ''));
        var fristChar = $(this).text().slice(0, 1);
        var lastChar = $(this).text().substr(-1);
        $(this).prop('Counter', 0).animate({   
            Counter: value
        }, {
            duration: 2000,
            easing: 'swing',
                step: function (now) {
                    if ($.isNumeric(fristChar)) {
                        $(this).text(Math.ceil(now).toLocaleString('en') + lastChar);
                    } else {
                        $(this).text(fristChar + Math.ceil(now).toLocaleString('en') + lastChar);
                    }                    
            }
        });
    });

    //readmore button on click set modal share button attributes
    $(document).on("click", ".readmoreBtn", function () {

        var newsIndex = $(this).data('index');
        var modal = $(".modal_multi[data-index='" + newsIndex + "']");
        var url = encodeURIComponent(window.location.href);
        //var img = $(this).parent().parent().parent().parent().prev().find('img').prop('src');
        var title = modal.children().children().next().next().find('h2').text().trim();
        var description = modal.children().children().next().next().find('p').text().trim().substr(0, 180) + '...';

        $("meta[property='og\\:url']").attr('content', url);
        $("meta[name='twitter:domain']").attr('content', url);
        $("meta[property='og\\:title']").attr('content', title);
        $("meta[name='twitter:title']").attr('content', title);
        $("meta[property='og\\:description']").attr('content', description);
        $("meta[name='twitter:description']").attr('content', description);
        //$("meta[property='og\\:image:url']").attr('content', img);
        //$("meta[name='twitter:image']").attr('content', img);
        var tweet = encodeURIComponent($("meta[name='twitter:description']").attr("content"));
        $('a.fbShare, a.twitterShare, a.linkedinShare').attr('target', '_blank');
        $("a.fbShare").attr('href', 'https://www.facebook.com/sharer.php?u=' + url);
        $("a.twitterShare").attr('href', 'https://twitter.com/intent/tweet?url=' + url + "&text=" + tweet);
        $('a.linkedinShare').attr('href', 'https://www.linkedin.com/shareArticle?mini=true&url=' + url);


    });
    //share button popover
    $(document).on("click", ".shareBtn", function (e) {
        e.preventDefault();

        var newsIndex = $(this).closest('div.read-btn-div').find('button.readmoreBtn').data('index');
        var url = window.location.href + "#" + newsIndex;
        url = encodeURIComponent(url);
        //var img = $(this).parent().parent().parent().parent().prev().find('img').prop('src');
        var title = $(this).parent().parent().parent().parent().find('h3').text().trim();
        var description = $(this).parent().parent().parent().parent().find('p').text().trim().substr(0, 180) + '...';
        if (newsIndex == 0) {
            title = $(this).parent().parent().parent().parent().find('h1').text().trim();
            description = $(this).parent().parent().parent().parent().find('p').text().trim().substr(0, 180) + '...';
        }
        else if (newsIndex == 7 || newsIndex == 8 || newsIndex == 9 || newsIndex == 10) {
            title = $(this).parent().parent().parent().prev('h3').text().trim();
            description = $(".modal_multi[data-index='" + newsIndex + "']").children().children().next().next().find('p').text().trim().substr(0, 180) + '...';
        }

        $("meta[property='og\\:url']").attr('content', url);
        $("meta[name='twitter:domain']").attr('content', url);
        $("meta[property='og\\:title']").attr('content', title);
        $("meta[name='twitter:title']").attr('content', title);
        $("meta[property='og\\:description']").attr('content', description);
        $("meta[name='twitter:description']").attr('content', description);
        //$("meta[property='og\\:image:url']").attr('content', img);
        //$("meta[name='twitter:image']").attr('content', img);
        var tweet = encodeURIComponent($("meta[name='twitter:description']").attr("content"));
        $('a.fbShare, a.twitterShare, a.linkedinShare').attr('target', '_blank');
        $("a.fbShare").attr('href', 'https://www.facebook.com/sharer.php?u=' + url);
        $("a.twitterShare").attr('href', 'https://twitter.com/intent/tweet?url=' + url + "&text=" + tweet);
        $('a.linkedinShare').attr('href', 'https://www.linkedin.com/shareArticle?mini=true&url=' + url);


    });
    $("[data-toggle=popover]").popover({
        html: true,
        trigger: 'focus',
        content: function () {
            return $('.popover-body').html();
        }
    });


});