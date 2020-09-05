using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using Microsoft.Extensions.Configuration;
using Models;

namespace DL
{
    public class UserDL
    {
        private IConfiguration configuration;
        private string dbConnection;

        public UserDL() { }
        public UserDL(IConfiguration _configuration)
        {
            configuration = _configuration;
            dbConnection = this.configuration.GetConnectionString("dbString");
        }


        public int SaveUser(User user)
        {
            int isCreated = 0;
            bool isUploaded = false;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(dbConnection);
                SqlCommand cmd = new SqlCommand("SaveUser", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                cmd.Parameters.AddWithValue("@organization", user.Organization);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
                cmd.Parameters.AddWithValue("@Location", user.Location);
                cmd.Parameters.AddWithValue("@Photopath", user.PhotoPath);

                sqlConnection.Open();
                    isCreated = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            if (isCreated > 1)
            {
                isUploaded = UploadPhotoToServer(user.UserId, user.PhotoPath);
            }

            return isCreated>1 && isUploaded ? 1 : 0;
        }

        public int UpdateUser(int userId, User user)
        {
            int isUpdated = 0;
            bool isUploaded = false;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(dbConnection);
                SqlCommand cmd = new SqlCommand("UpdateUser", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                cmd.Parameters.AddWithValue("@organization", user.Organization);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
                cmd.Parameters.AddWithValue("@Location", user.Location);
                cmd.Parameters.AddWithValue("@Photopath", user.PhotoPath);

                sqlConnection.Open();
                    isUpdated = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            if (isUpdated > 1)
            {
                isUploaded = UploadPhotoToServer(user.UserId, user.PhotoPath);
            }

            return isUpdated>1 && isUploaded ? 1 : 0;
        }

        public int UploadPhoto(int userId, string Photopath)
        {
            bool isUploaded = false;

            isUploaded = UploadPhotoToServer(userId, Photopath);

            return isUploaded? 1 : 0;
        }

        private bool UploadPhotoToServer(int userId, string PhotoPath)
        {
            bool isUploaded = false;
            string ftpurl = "ftpurl";
            string ftpusername = "ftpusername";
            string ftppassword = "ftppassword"; 

            try
            {
                string filename = Path.GetFileName(PhotoPath);
                string ftpfullpath = ftpurl;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(PhotoPath);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
                isUploaded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isUploaded;
        }
    }
}
