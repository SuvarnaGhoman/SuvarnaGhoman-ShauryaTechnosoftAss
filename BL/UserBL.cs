using DL;
using Models;
using System;

namespace BL
{
    public class UserBL
    {
        UserDL objUserDL = new UserDL();
        public int SaveUser(User user)
        {
            return  objUserDL.SaveUser(user);
        }

        public int UpdateUser(int userId, User user)
        {
            return objUserDL.UpdateUser(userId ,user);
        }

        public int UploadPhoto(int userId, string PhotoPath)
        {
            return objUserDL.UploadPhoto(userId, PhotoPath);
        }
    }
}
