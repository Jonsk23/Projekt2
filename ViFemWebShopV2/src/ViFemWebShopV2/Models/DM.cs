using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViFemWebShopV2.ViewModels;

namespace ViFemWebShopV2.Models
{
    public class DM
    {
        static List<Product> products = new List<Product>();
        static List<Order> orders = new List<Order>();
        static List<User> users = new List<User>();
        static List<Address> addresses = new List<Address>();
        static List<Category> categories = new List<Category>();
        static List<ShopCartItemVM> cart = new List<ShopCartItemVM>();

        static DM()
        {
            products.Add(new Product { ProductName = "Super pen", CategoryID = 1, ProductID = 1,
                Description = "Super cool pen", IsActive = true, Price = 25,
                Stock = 150, ImageURL = "http://images.google.de/imgres?imgurl=http%3A%2F%2Fd15bv9e9f3al6i.cloudfront.net%2Fimgs%2Fproducts%2Fcp%2F950_constW%2FPD00634~Porsche-Design-TecFlex-P3110-Steel-Ballpoint-Pen_P1.jpg&imgrefurl=https%3A%2F%2Fwww.cultpens.com%2F&h=495&w=495&tbnid=C4IRuYjA6n95hM%3A&docid=yzErK7FvBGRUEM&ei=N9TjVr_tM8nb6QSbmqC4Cw&tbm=isch&iact=rc&uact=3&dur=1546&page=1&start=0&ndsp=37&ved=0ahUKEwj_5MSn3rrLAhXJbZoKHRsNCLcQrQMITjAJ" });

            orders.Add(new Order { ClientId = 1, CreatedDate = DateTime.Now, OrderId = 3, Status = "Pending" });
            orders.Add(new Order { ClientId = 1, CreatedDate = DateTime.Now.AddDays(-5), OrderId = 2, Status = "Shipping" });
            orders.Add(new Order { ClientId = 1, CreatedDate = DateTime.Now.AddMonths(-1), OrderId = 1, Status = "Deliverd" });

            users.Add(new User { AccountID = 1, ClientID = 1, DeliveryAddressID = 1, Email = "j@jens.se",
                FirstName = "Jens", LastName = "Jensa", Password = "jens", UserName = "Jensa"});

            users.Add(new User { AccountID = 1, ClientID = 2, DeliveryAddressID = 2, Email = "k@jens.se",
                FirstName = "Karl", LastName = "Karlsson", Password = "karl", UserName = "Kalle"});

            addresses.Add(new Address { AddressID = 1, City = "Byhagen", Street = "Åkersorksvägen 3", ZipCode = "12345" });

            categories.Add(new Category { CategoryID = 1, CategoryName = "Pens & Pencils" });
        }

        public ListProductVM[] ListProducts()
        {
            return products
                .Select(p => new ListProductVM
                {
                    Name = p.ProductName,
                    //Category = context.Categories.ToList().Find(o=>o.CategoryID == p.CategoryID).CategoryName,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    Price = p.Price
                }).ToArray();
        }


        //public void AddUser(AddUserVM viewModel)
        //{
        //    var BusinessAccount =
        //        context.BusinessAccounts.ToList().Find(o => o.RegistrationNumber == viewModel.CompanyNumber);

        //    ///Make sure the business account exists and password is correct
        //    if (BusinessAccount == null)
        //        throw new Exception("ERROR This company number (" + viewModel.CompanyNumber + ") is not in the database");

        //    if (BusinessAccount.Password != viewModel.CompanyPassword)
        //        throw new Exception("ERROR Company Password is invalid");

        //    //Username needs to be unique in database
        //    if (context.UserAccounts.ToList().FindAll(o => o.UserName == viewModel.UserName).Count() > 0)
        //        throw new Exception("ERROR Username already exists in database");

        //    //Add an address record for this user
        //    var newAdress =
        //        context.Addresses.Add(new Address
        //        {
        //            City = viewModel.City,
        //            Street = viewModel.Street,
        //            ZipCode = viewModel.ZipCode
        //        });

        //    context.SaveChanges();

        //    //User needs a valid address to create an account
        //    if (newAdress == null)
        //        throw new Exception("Error generating adress");
        //    else if (newAdress.Entity.AddressID < 0)
        //        throw new Exception("Error, address entity returned ID -1");

        //    //Add the user account
        //    context.UserAccounts.Add(new User
        //    {
        //        AccountID = BusinessAccount.AccountId,
        //        UserName = viewModel.UserName,
        //        Password = viewModel.Password,
        //        FirstName = viewModel.FirstName,
        //        LastName = viewModel.LastName,
        //        Email = viewModel.Email,
        //        DeliveryAddressID = newAdress.Entity.AddressID
        //    });

        //    context.SaveChanges();
        //}

        public void AddProduct(AddProductVM viewModel)
        {
            if (products.ToList().Find(o => o.ProductName.ToUpper() == viewModel.Name.ToUpper()) != null)
                throw new Exception("Error, the product name " + viewModel.Name + " already exists");

            var thisCategory = categories.ToList().Find(o => o.CategoryName.ToUpper() == viewModel.Category.ToUpper());

            if (thisCategory == null)
                throw new Exception("Error, category " + viewModel.Category + " does not exist");

            products.Add(new Product
            {
                ProductName = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Stock = viewModel.Stock,
                CategoryID = thisCategory.CategoryID,
                ImageURL = viewModel.ImageURL,
                IsActive = true
            });

            //context.SaveChanges();
        }
        public User Login(LoginVM viewModel)
        {
            try
            {
                return users.Where(o => o.UserName == viewModel.UserName && o.Password == viewModel.Password).Single();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public UserProfileVM MyProfile(string username)
        {
            var userProfileVM = new UserProfileVM();
            var user = users.Where(u => u.UserName == username).Single();
            var address = addresses.Where(a => a.AddressID == user.DeliveryAddressID).Single();
            var userOrders = orders.Where(o => o.ClientId == user.ClientID).ToList();
            var orderVms = new List<OrderVM>();
            foreach (var item in orders)
            {
                orderVms.Add(new OrderVM { Ordernumber = item.OrderId, OrderDate = item.CreatedDate.ToString("yyyyMMdd"), Status = item.Status });
            }
            var addUser = new AddUserVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = address.City,
                Street = address.Street,
                ZipCode = address.ZipCode,
                UserName = user.UserName
            };

            userProfileVM.addUser = addUser;

            userProfileVM.orders = orderVms.ToArray();
            //userProfileVM.addUser.Street = address.Street;
            //userProfileVM.addUser.City = address.City;
            //userProfileVM.addUser.ZipCode = address.ZipCode;

            return userProfileVM;
            //viewModel.orderHistory = 
        }

        public void AddToCart(string name, string username)
        {
            if(cart.Where(o=>o.UserName == username && o.ProductName == name).Count() > 0)
            {
                cart.Where(o => o.UserName == username && o.ProductName == name)
                    .Single().Quantity++;
            }
            else
            {
                var product = GetProductByName(name, username);
                cart.Add(product);
            }
        }

        public List<ShopCartItemVM> GetCart(string username)
        {
            return cart.Where(o=>o.UserName == username).ToList();
        }

        ShopCartItemVM GetProductByName(string name, string username)
        {
            return products.Where(o => o.ProductName == name).Select(o => new ShopCartItemVM
            {
                ProductName = o.ProductName,
                Price = o.Price,
                Quantity = 1,
                UserName = username
            }).Single();
        }
    }
}
