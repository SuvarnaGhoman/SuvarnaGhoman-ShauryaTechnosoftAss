using System;

namespace Model
{
    public class Vehicle
    {

        private int _vehicleNo;
        private string _vehicleType;
        private string _chasisNo;
        private string _engineNo;
        private int _manuYear;
        private int _loadCapacity;
        private string _makeofVehicle;
        private string _modelNo;
        private string _bodyType;
        private string _organizationName;
        private int _deviceId;
        private int _userId;

        public int VehicleNo
        {
            get { return _vehicleNo; }
            set { _vehicleNo = value; }
        }
        public string VehicleType
        {
            get { return _vehicleType; }
            set { _vehicleType = value; }
        }
        public string ChasisNo
        {
            get { return _chasisNo; }
            set { _chasisNo = value; }
        }

        public string EngineNo
        {
            get { return _engineNo; }
            set { _engineNo = value; }
        }
        public int ManuYear
        {
            get { return _manuYear; }
            set { _manuYear = value; }
        }
        public int LoadCapacity
        {
            get { return _loadCapacity; }
            set { _loadCapacity = value; }
        }
        public string MakeofVehicle
        {
            get { return _makeofVehicle; }
            set { _makeofVehicle = value; }
        }
        public string ModelNo
        {
            get { return _modelNo; }
            set { _modelNo = value; }
        }

        public string BodyType
        {
            get { return _bodyType; }
            set { _bodyType = value; }
        }

        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }

        public int DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
