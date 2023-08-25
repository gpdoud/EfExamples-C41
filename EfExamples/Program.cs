using EfExamples;

using System.ComponentModel;
using System.Threading.Channels;

var _context = new AppDbContext();

var custOrders = from c in _context.Customers
                 join o in _context.Orders
                    on c.Id equals o.CustomerId
                 join ol in _context.Orderlines
                    on o.Id equals ol.OrdersId
                 where c.Id == 1
                 select new {
                     OrderDate = o.Date,
                     o.Description,
                     Customer = c.Name,
                     ol.Product,
                     ol.Quantity,
                     ol.Price,
                     LineTotal = ol.Quantity * ol.Price, 
                 };

custOrders.ToList().ForEach(
    c => Console.WriteLine($"{c.OrderDate} | {c.Description} | {c.Customer} | {c.Product} | {c.Quantity} | {c.Price} | {c.LineTotal}")
);











//var customers = from c in _context.Customers
//                select c;

// get all customers
//foreach(var cust in _context.Customers.ToList()) {
//    Console.WriteLine(cust);
//}
// get by primary key
//Console.WriteLine(_context.Customers.Find(1));

// insert customer
//var newCust = new Customer() {
//    Id = 0, Code = "MTT", Name = "MAX", City = "Mason", State = "OH", Active = true
//};
//_context.Customers.Add(newCust);
//_context.SaveChanges();

// update customer
//var updCustomer =  _context.Customers.Find(42);
//if(updCustomer == null) return;
//updCustomer.Code = "MXT3";
//_context.SaveChanges();

// delete customer
//int id = 43;
//var delCust = _context.Customers.Find(id);
//if(delCust == null) return;
//_context.Remove(delCust);
//_context.SaveChanges();
