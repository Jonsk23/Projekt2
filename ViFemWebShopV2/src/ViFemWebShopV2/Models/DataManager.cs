﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViFemWebShopV2.ViewModels;

namespace ViFemWebShopV2.Models
{
    public class DataManager
    {
        UserAccountContext userAccountContext;
        ProductContext productContext;

        public DataManager(UserAccountContext context)
        {
            context = userAccountContext;
        }

        public DataManager(ProductContext context)
        {
            context = productContext;
        }

        public void AddUser(AddUserVM viewModel)
        {
            userAccountContext.Users.Add(new User
            {
                //ClientID = viewModel.ClientID,
                //BusinessAccount = viewModel.BusinessAccount,
                SocialSecurityNo = viewModel.SocialSecurityNo,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                DeliveryAddress = new Address { Street = viewModel.Street, City = viewModel.City, ZipCode = viewModel.ZipCode }
            });
            userAccountContext.SaveChanges();
        }

        public void AddProduct(AddProductVM viewModel)
        {

        }
    }
}
