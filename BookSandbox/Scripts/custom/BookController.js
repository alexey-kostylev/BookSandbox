/// <reference path="../jquery-1.10.2.min.js"

$(function () {
    getData();

    $("#addBook").submit(function () {
        $.post(
            "/api/books",
            $("#addBook").serialize(),
            function (value) {
                $("#bookTemplate").tmpl(value).appendTo("#books");
                $("#name").val("");
                $("#price").val("");
            },
            "json"
        );
        return false;
    });
    $(".removeBook").live("click", function () {
        $.ajax({
            type: "DELETE",
            url: $(this).attr("href"),
            context: this,
            success: function () {
                $(this).closest("li").remove();
            }
        });
        return false;
    });
    $("input[type=\"submit\"], .removeBook, .viewImage").button();
})

function getData()
{
    $.getJSON(
            "/api/books",
            function (data) {
                $.each(data,
                    function (index, value) {
                        $("#bookTemplate").tmpl(value).appendTo("#books");
                    }
                );
                $("#loader").hide();
                $("#addBook").show();
            }
        );
}

function find() {
    var id = $('#bookId').val();
    $.getJSON("/api/books/" + id,
        function (data) {
            var str = data.Name + ': $' + data.Price;
            $('#book').html(str);
        })
        .fail(
            function (jqXHR, textStatus, err) {
                $('#book').html('Error: ' + err);
            });
}