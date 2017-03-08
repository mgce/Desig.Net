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

    self.delete = function(Customer) {
        var id = Customer.Id;
        $.ajax({
            url: "api/Customer/" + id,
            type: "DELETE",
            dataType: "json",
            data: {},
            success: function() {
                self.Customers.remove(Customer);
            },
            error: function (xhr, textStatus, err) {
                alert(err);
                alert("error");
            }
        });
    }

    self.edit = function(Customer) {
        self.Customer(Customer);
    };

    self.update = function () {
        var Customer = self.Customer();
        var id = Customer.Id;

        $.ajax({
            url: "api/Customer/" + id,
            cache: false,
            type: "PUT",
            dataType: "json",
            async: false,
            contentType: "application/json; charset=utf-8",
            data: ko.toJSON(Customer),
            success: function (data) {
                self.getAll();
                self.Customer(null);
            }
        })
        .fail(
        function (xhr, textStatus, err) {
            alert(err);
        });
    }
}


$(document).ready(function() {
    var customerViewModel = new CustomerViewModel();
    ko.applyBindings(customerViewModel);
    customerViewModel.getAll();
});
