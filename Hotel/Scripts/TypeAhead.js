/// <reference path="bootstrap3-typeahead.min.js" />
var TypeAhead = {
    Customers: function (element, idElement) {
        $("#" + element).typeahead({
            source: function (query, process) {
                $.getJSON(
                "../Customer/GetCustomers",
                { name: query },
                function (data) {
                    process(data);
                });
            },

            displayText: function (item) {
                return item.Name + " " + item.Surname;
            },

            afterSelect: function (item) {
                $("#" + idElement).val(item.Id);
            }
        });
    }
};