﻿using BulkyBook.DataAccess.Data;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer (UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex)
            {

            }

            try
            {
                //create roles if they are not created
                //if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
                //{
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

                //    //if roles are not created, then we will create user admin as well
                //    _userManager.CreateAsync(new ApplicationUser
                //    {
                //        UserName = "admin@gmail.com",
                //        Email = "admin@gmail.com",
                //        Name = "Carmen (Admin)",
                //        PhoneNumber = "1234567890",
                //        StreetAddress = "Ipoh Rd",
                //        State = "KL",
                //        PostalCode = "51200",
                //        City = "KL"
                //    }, "P@ssw0rd1234").GetAwaiter().GetResult();

                //    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                //    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                //}
            }
            catch (Exception ex)
            {
                string exMsg = ex.Message;
            }

            return;
        }
    }
}