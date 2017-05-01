$(function () {
    $("#datetimepicker1").datetimepicker();
});

$(".popup").click(function(e) {
    if (!$(".popup-inner").is(e.target) && $(".popup-inner").has(e.target).length === 0) {
        $(".popup").hide();
    }
});

$(function() {
    $("#DateTimeCheckbox").change(function () {
        $("#datetimepicker").toggle();
    });
})

