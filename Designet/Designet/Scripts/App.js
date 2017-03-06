function CustomerViewModel() {

    var self = this;
    self.Id = ko.observable("");
    self.Name = ko.observable("");

    var Customer = {
        Id: self.Id,
        Name: self.Name,
    };

    self.Customer = ko.observable();
    self.Customers = ko.observableArray();

    $.ajax({
        url: "api/Customer/",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        data: {},
        succes: function (data) {
            self.Customers(data);
        }
    });
}

var viewModel = new CustomerViewModel();
ko.applyBindings(viewModel);