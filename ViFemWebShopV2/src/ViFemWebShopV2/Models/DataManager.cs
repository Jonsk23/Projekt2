using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViFemWebShopV2.ViewModels;

namespace ViFemWebShopV2.Models
{
    public class DataManager
    {
        EshopContext context;

        public DataManager(EshopContext context)
        {
            this.context = context;
        }

        public void AddUser(AddUserVM viewModel)
        {
            context.UserAccounts.Add(new User
            {
                BusinessAccountId = 3,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                DeliveryAddressID = 3
            });

            context.SaveChanges();
        }

        public void AddProduct(AddProductVM viewModel)
        {
            context.Products.Add(new Product
            {
                Name = viewModel.Name,
                //ProductID = viewModel.ProductID,
                Price = viewModel.Price,
                Description = viewModel.Description,
                ItemsInStock = viewModel.ItemsInStock,
                Category = viewModel.Category
            });
            context.SaveChanges();
        }
    }
}
