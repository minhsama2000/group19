using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using group19Web.Models;

namespace group19Web.DAO
{
    public class UserDAO
    {
        private CayCanhDB db = new CayCanhDB();

        public tbl_user findByName(string username)
        {
            var user = (from u in db.tbl_user where u.username == username select u).FirstOrDefault();
            return user;
        }

        public tbl_user findByEmail(string email)
        {
            var user = (from u in db.tbl_user where u.email == email select u).FirstOrDefault();
            return user;
        }

    }
}