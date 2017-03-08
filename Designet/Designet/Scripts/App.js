var CustomerViewModel = function()  {

    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();

    var Customer = {
        Id: self.Id,
        Name: self.Name
    };

    self.Customer = ko.observable();
    self.Customers = ko.observableArray();

    self.getAll = function() {
        $.get("api/Customer/",
            function(data) {
                self.Customers(data);
            });
    }

    self.create = function () {
        $.ajax({
            url: "api/Customer/",
            type: "POST",
            async:false,
            dataType: "json",
            data: ko.toJSON(self),
            contentType: "application/json",
            success: function(data) {
                self.Customers.push(data);
                self.Name("");
            },
            error: function(xhr, textStatus, err) {
                alert(err);
                alert("error");
            }
        });
    }
}


$(document).ready(function() {
    var customerViewModel = new CustomerViewModel();
    ko.applyBindings(customerViewModel);
    customerViewModel.getAll();
});
