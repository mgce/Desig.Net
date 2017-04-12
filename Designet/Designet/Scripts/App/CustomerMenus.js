/*Highlighting items on customer list */
$("#customer-list").on("click", ".list", function (e) {
    e.preventDefault();
    $(this).parents('#customer-list').find('.active').removeClass('active').end().end().addClass('active');
});