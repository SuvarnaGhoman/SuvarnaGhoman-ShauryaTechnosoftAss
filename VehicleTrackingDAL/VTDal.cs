using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Model;

namespace VehicleTrackingDAL
{
    public class VTDal
    {
        private IConfiguration configuration;
        private string dbConnection;

        public VTDal() { }
        public VTDal(IConfiguration _configuration)
        {
            configuration = _configuration;
            dbConnection = this.configuration.GetConnectionString("dbString");
        }


        public List<Vehicle> SearchVehicles(Vehicle vehicle)
        {
            // SeachVehicles Sp will select all the records according the values we have passed using wild cards uding like and %
            List<Vehicle> lstVehicle = new List<Vehicle>();
            Vehicle veh = new Vehicle();

            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlConnection sqlConnection = new SqlConnection(dbConnection);
                SqlCommand cmd = new SqlCommand("SeachVehicles", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleNo", vehicle.VehicleNo);
                cmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType);
                cmd.Parameters.AddWithValue("@ChasisNo", vehicle.ChasisNo);
                cmd.Parameters.AddWithValue("@EngineNo", vehicle.EngineNo);
                cmd.Parameters.AddWithValue("@ManuYear", vehicle.ManuYear);
                cmd.Parameters.AddWithValue("@LoadCapacity", vehicle.LoadCapacity);
                cmd.Parameters.AddWithValue("@MakeofVehicle", vehicle.MakeofVehicle);
                cmd.Parameters.AddWithValue("@ModelNo", vehicle.ModelNo);
                cmd.Parameters.AddWithValue("@BodyType", vehicle.BodyType);
                cmd.Parameters.AddWithValue("@OrganizationName", vehicle.OrganizationName);
                cmd.Parameters.AddWithValue("@DeviceId", vehicle.DeviceId);
                cmd.Parameters.AddWithValue("@UserId", vehicle.UserId);

                da.SelectCommand = cmd;
                sqlConnection.Open();
                da.Fill(ds);
                sqlConnection.Close();

                if(ds.Tables != null && ds.Tables[0].Rows.Count>0)
                {
                    for(int i =0; i<ds.Tables[0].Rows.Count;i++)
                    {
                        veh = new Vehicle()
                        {
                            VehicleNo = Convert.ToInt32(ds.Tables[0].Rows[i]["VehicleNo"]),
                            VehicleType= Convert.ToString(ds.Tables[0].Rows[i]["VehicleType"]),
                            ChasisNo= Convert.ToString(ds.Tables[0].Rows[i]["ChasisNo"]),
                            EngineNo= Convert.ToString(ds.Tables[0].Rows[i]["EngineNo"]),
                            ManuYear= Convert.ToInt32(ds.Tables[0].Rows[i]["ManuYear"]),
                            LoadCapacity= Convert.ToInt32(ds.Tables[0].Rows[i]["LoadCapacity"]),
                            MakeofVehicle= Convert.ToString(ds.Tables[0].Rows[i]["MakeofVehicle"]),
                            ModelNo= Convert.ToString(ds.Tables[0].Rows[i]["ModelNo"]),
                            BodyType= Convert.ToString(ds.Tables[0].Rows[i]["BodyType"]),
                            OrganizationName= Convert.ToString(ds.Tables[0].Rows[i]["OrganizationName"]),
                            DeviceId= Convert.ToInt32(ds.Tables[0].Rows[i]["DeviceId"]),
                            UserId= Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"])
                        };
                        lstVehicle.Add(veh);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVehicle;
        }
    }
}
