/// <reference path="../jquery-1.10.2.min.js"

$(function () {
    getData();

    $("#addBook").submit(function () {
        $("#loader").show();
        $.post(
            "/api/books",
            $("#addBook").serialize(),
            function (value) {
                $("#bookTemplate").tmpl(value).appendTo("#books");
                $("#name").val("");
                $("#price").val("");
                $("#loader").hide();
            },
            "json"
        );
        return false;
    });
    $(document).on("click", ".removeBook", function () {        
        var url = $(this).attr("href");
        var self = this;        
        $.ajax({
            type: "DELETE",
            url: url,
            //context: this,
            success: function () {                
                $(self).closest("li").remove();
            }
        });
        return false;
    });   
    
    //$("input[type=\"submit\"], .removeBook, .viewImage").button();

    $("#refreshButton").on("click", function () {
        refreshData();
    });
})

function refreshData() {    
    $("#books > li").remove();
    $("#loader").show();
    getData();
}

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
                //BindClick();
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