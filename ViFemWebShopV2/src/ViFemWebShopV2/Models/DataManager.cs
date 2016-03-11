﻿using System;
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

        public ListProductVM[] ListProducts()
        {
            return context.Products
                .Select(p => new ListProductVM
                {
                    Name = p.ProductName,
                    //Category = context.Categories.ToList().Find(o=>o.CategoryID == p.CategoryID).CategoryName,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    Price = p.Price
                }).ToArray();
        }


        public void AddUser(AddUserVM viewModel)
        {
            var BusinessAccount =
                context.BusinessAccounts.ToList().Find(o => o.RegistrationNumber == viewModel.CompanyNumber);

            ///Make sure the business account exists and password is correct
            if (BusinessAccount == null)
                throw new Exception("ERROR This company number (" + viewModel.CompanyNumber + ") is not in the database");

            if (BusinessAccount.Password != viewModel.CompanyPassword)
                throw new Exception("ERROR Company Password is invalid");

            //Username needs to be unique in database
            if (context.UserAccounts.ToList().FindAll(o => o.UserName == viewModel.UserName).Count() > 0)
                throw new Exception("ERROR Username already exists in database");

            //Add an address record for this user
            var newAdress =
                context.Addresses.Add(new Address
                {
                    City = viewModel.City,
                    Street = viewModel.Street,
                    ZipCode = viewModel.ZipCode
                });

            context.SaveChanges();

            //User needs a valid address to create an account
            if (newAdress == null)
                throw new Exception("Error generating adress");
            else if (newAdress.Entity.AddressID < 0)
                throw new Exception("Error, address entity returned ID -1");

            //Add the user account
            context.UserAccounts.Add(new User
            {
                AccountID = BusinessAccount.AccountId,
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                DeliveryAddressID = newAdress.Entity.AddressID
            });

            context.SaveChanges();
        }

        public void AddProduct(AddProductVM viewModel)
        {
            if (context.Products.ToList().Find(o => o.ProductName.ToUpper() == viewModel.Name.ToUpper()) != null)
                throw new Exception("Error, the product name " + viewModel.Name + " already exists");

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
                ImageURL = viewModel.ImageURL,
                IsActive = true
            });

            context.SaveChanges();
        }
        static List<User> fakelist = new List<User>();
        static DataManager()
        {
            fakelist.Add(new User { UserName = "jens", Password = "p" });

        }
        public User Login(LoginVM viewModel)
        {
            try
            {
                return fakelist.Where(o => o.UserName == viewModel.UserName && o.Password == viewModel.Password).Single();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public void MyProfile(UserProfileVM viewModel)
        {
            var user = context.UserAccounts.Where(u => u.UserName == viewModel.addUser.UserName).Single();
            var address = context.Addresses.Where(a => a.AddressID == user.DeliveryAddressID).Single();
            //var orders = context.Orders.Where(o => o.ClientId == user.ClientID).ToList();

            viewModel.addUser.FirstName = user.FirstName;
            viewModel.addUser.LastName = user.LastName;
            viewModel.addUser.Email = user.Email;
            viewModel.addUser.Street = address.Street;
            viewModel.addUser.City = address.City;
            viewModel.addUser.ZipCode = address.ZipCode;

            //viewModel.orderHistory = 

        }
    }
}
