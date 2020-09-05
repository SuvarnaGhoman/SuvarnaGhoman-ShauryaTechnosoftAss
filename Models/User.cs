using System;

namespace Models
{
    public class User
    {
        private int _userId;
        private string _name;
        private string _mobileNumber;
        private string _organization;
        private string _address;
        private string _emailId;
        private string _location;
        private string _photoPath;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; }
        }

        public string Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string EmailId
        {
            get { return _emailId; }
            set { _emailId = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; }
        }

    }
}
