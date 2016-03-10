using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var BusinessAccount = 
                context.BusinessAccounts.ToList().Find(o => o.RegistrationNumber == viewModel.CompanyNumber);

            if(BusinessAccount == null)
            {
                Debug.WriteLine("Reg number not found");
                return; 
            }

            context.UserAccounts.Add(new User
            {
                AccountID = BusinessAccount.AccountId,
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
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
