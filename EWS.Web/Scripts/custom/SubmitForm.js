$(document).ready(function () {

    //Ajax Submit
    var DoAjaxSubmit = function () {

        var form = $("#SubmitForm");
        var ajaxURL = form.attr("action");
        var ajaxDATA = form.serialize();
        console.log(form);

        $.ajax({
            cache: false,
            type: 'POST',
            url: ajaxURL,
            dataType: 'json',
            data: ajaxDATA,
            async: false,
            success: function (data) {

            },
            error: function (xhr, textStatus, exceptionThrown) { alert((xhr.responseText)); }
        });
    };


    //Search Button Click
    $("#btnSubmit").click(function (event) {
        event.preventDefault();
        //$("#Spinner").toggleClass("hidden show");
        //$("#AutoList").empty();
        setTimeout(DoAjaxSubmit, 1000);
    });

});
