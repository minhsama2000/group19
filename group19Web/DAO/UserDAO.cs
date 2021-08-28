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


        public tbl_user test(string email)
        {
            var user = db.tbl_user.SqlQuery("Select * from webcaycanh.tbl_user where not(email = '" + email + "')").FirstOrDefault();
            return user;
        }

        public bool isEmail(string email)
        {

            var user = db.tbl_user.SqlQuery("Select * from webcaycanh.tbl_user where not(email = '" + email + "')").ToList() ;

            if (user != null)
                {
                foreach (var item in user)
                {
                    if (item.email.Equals(email))
                    {
                        return true;
                    }
                }                                          
                }
            return false;
        }

        public void updateUser(tbl_user user)
        {
            tbl_user tbl_UserFind = db.tbl_user.Where(u => u.id == user.id).FirstOrDefault();
            tbl_UserFind.fullname = user.fullname;
            tbl_UserFind.email = user.email;
            tbl_UserFind.address = user.address;
            tbl_UserFind.phone = user.phone;
            tbl_UserFind.updated_date = user.updated_date;
            db.SaveChanges();
        }

        public void updateUserImage(tbl_user user)
        {
            tbl_user tbl_UserFind = db.tbl_user.Where(u => u.id == user.id).FirstOrDefault();
            tbl_UserFind.avatar = user.avatar;

            db.SaveChanges();
        }
    }
}