$(document).ready(function () {

    //Ajax Search
    var DoAjaxSearch = function () {

        var form = $("#SearchForm");
        var ajaxURL = form.attr("action");
        var ajaxDATA = form.serialize();
        console.log(form);

        $.ajax({
            cache: false,
            type: 'POST',
            url: ajaxURL,
            dataType: 'html',
            data: ajaxDATA,
            success: function (html) {
                $("#AutoList").append(html);
                $("#Spinner").toggleClass("hidden show");
            },
            error: function (ex) {
                $("#AutoList").append("<b>Failed to communicate with server. The following error occured: " + ex + "</b>")
                $("#Spinner").toggleClass("hidden show");
            }
        });
    }


    //Search Button Click
    $("#btnSearch").click(function (event) {
        event.preventDefault();
        $("#Spinner").toggleClass("hidden show");
        $("#AutoList").empty();
        setTimeout(DoAjaxSearch, 1000);
    });

});
