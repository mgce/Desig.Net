var shouter = new ko.subscribable();

var CustomerViewModel = function () {

    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Orders = ko.observableArray();

    self.cId = ko.observable().publishOn("customerId");

    var Customer = {
        Id: self.Id,
        Name: self.Name
    };

    self.Customer = ko.observable();
    self.Customers = ko.observableArray();

    self.selectedCustomer = ko.observable();
    self.selectCustomer = function(customer) {
        this.selectedCustomer(customer);
    }

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

    self.delete = function (Customer) {
        var id = Customer.Id;
        $.ajax({
            url: "api/Customer/Delete/" + id,
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

    self.update = function(Customer) {
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
                success: function(data) {
                    self.getAll();
                    self.Customer(null);
                }
            })
            .fail(
                function(xhr, textStatus, err) {
                    alert(err);
                });
    }

    self.test = function (Customer) {
        var id = Customer.Id;
        self.cId(id);
    }         
}

var OrderViewModel = function() {
    var self = this;

    self.Id = ko.observable();
    self.Description = ko.observable();
    self.Price = ko.observable();
    self.Created = ko.observable();
    self.Deadline = ko.observable();
    self.CustomerId = ko.observable();

    self.cId = ko.observable().subscribeTo("customerId");

    var Order = {
        Id: self.Id,
        Description: self.Description,
        Price: self.Price,
        Created: self.Created,
        Deadline: self.Deadline
    }

    self.Order = ko.observable();
    self.Orders = ko.observableArray();

    self.getOrders = function () {
        $.get("api/Order/GetByCustomer/" + self.cId(),
            function (data) {
                self.Orders("");
                self.Orders(data);
            });
    }

    self.create = function () {
        self.CustomerId = self.cId();
        $.ajax({
            url: "api/Order/",
            type: "POST",
            async: false,
            dataType: "json",
            data: ko.toJSON(self),
            contentType: "application/json",
            success: function (data) {
                self.Orders.push(data);
                self.Description("");
            },
            error: function (xhr, textStatus, err) {
                alert(err);
                alert("error");
            }
        });
    }

    self.deleteOrder = function (Order) {
        var id = Order.Id;
        $.ajax({
            url: "api/Order/Delete/" + id,
            type: "DELETE",
            dataType: "json",
            data: {},
            success: function () {
                self.Orders.remove(Order);
            },
            error: function (xhr, textStatus, err) {
                alert(err);
                alert("error");
            }
        });
    }

    self.showDetails = function(Order) {
        var Order = self.Order(Order);
        //$(".popup").css("display", "block");
        $(".popup").fadeIn(300, function() { $(this).focus(); });
    };

    self.close = function() {
        $(".popup").fadeOut();
    };

    self.update = function() {
        var Order = self.Order();

        $.ajax({
            url: "api/Order/" + Order.Id,
            type: "PUT",
            dataType: "json",
            data: ko.toJSON(Order),
            succes: function() {
                self.close();
            }
        });
    }
}


$(document).ready(function() {
    var customerViewModel = new CustomerViewModel();
    var orderViewModel = new OrderViewModel();
    ko.applyBindings(customerViewModel, document.getElementById("list-customer"));
    ko.applyBindings(orderViewModel, document.getElementById("list-order"));
    ko.applyBindings(orderViewModel, document.getElementById("editOrder"));
    customerViewModel.getAll();

    $("#customer-list").on("click", ".list", function (e) {
        orderViewModel.Orders.remove();
        orderViewModel.getOrders();
    });

    $("#order-list").on("click",
        ".list",
        function() {
            //orderViewModel.ShowDetails();
        });
});
