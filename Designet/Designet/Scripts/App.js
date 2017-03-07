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

    self.create = function() {
        $.ajax({
            url: "api/Customer/",
            type: "POST",
            contentType: "Application/json charset=utf-8",
            data: ko.toJSON(Customer),
            succes: function(data) {
                self.Customer.push(data);
                self.Name();
            }
        }).fail(
            function(xhr, textStatus, err) {
                alert(err);
            });
    }
}


$(document).ready(function() {
    var customerViewModel = new CustomerViewModel();
    ko.applyBindings(customerViewModel);
    customerViewModel.getAll();
});
