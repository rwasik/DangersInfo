'use strict';
var dangersService = function () {

    var getDangers = function () {
        $.ajax({
            type: "GET",
            url: "/dangers/get",
            dataType: "json",
            success: function (data) {
                var source = document.getElementById("dangers-template").innerHTML;
                var template = Handlebars.compile(source);
                var html = template(data);

                $("#dangers").append(html);
                $('#spinner').remove();
            },
            error: function () {
                window.location.href = "home/error";
            }
        });
    };

    return {
        getDangers: getDangers
    };
}();