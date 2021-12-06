using AltranApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranApplication.Services
{
    public class UserServices
    {
        public User CheckUser(User user)
        {
            User currentUser;
            using (TodosDBEntities db = new TodosDBEntities())
            {

                currentUser = db.User.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();

            }

            return currentUser;
        }
    }
}