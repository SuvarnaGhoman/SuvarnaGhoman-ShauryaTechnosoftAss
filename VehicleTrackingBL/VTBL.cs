using Model;
using System;
using System.Collections.Generic;
using VehicleTrackingDAL;

namespace VehicleTrackingBL
{
    public class VTBL
    {
        VTDal objVTDal = new VTDal();
        public List<Vehicle> SearchVehicles(Vehicle vehicle)
        {
            return objVTDal.SearchVehicles(vehicle);
        }
    }
}