
if (!Modernizr.inputtypes.date) {
    $(function () {

        var picker = $("input[type='date']");
        if (picker.length > 0) {
            picker.datepicker({ dateFormat: 'yy-mm-dd' });
        }
    });
}