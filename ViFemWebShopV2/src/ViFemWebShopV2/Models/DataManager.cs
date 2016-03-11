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
                //ADD ERROR /THROW EXCEPTION SOMEHOW?

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
            if (context.Products.ToList().FindAll(o => o.ProductName.ToUpper() == viewModel.Name.ToUpper()).Count() > 0)
                throw new Exception("Error, this product name already exists");

            var thisCategory = context.Categories.ToList().Find(o => o.CategoryName.ToUpper() == viewModel.Category.ToUpper());

            if (thisCategory == null)
                throw new Exception("Error, category " + viewModel.Category + " does not exist");

            context.Products.Add(new Product
            {
                ProductName = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Stock = viewModel.Stock,
                CategoryID = thisCategory.CategoryID,
            });

            context.SaveChanges();
        }
    }
}
