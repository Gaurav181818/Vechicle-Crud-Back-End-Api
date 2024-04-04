using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;
using System.Data.SqlClient;

namespace DataAccessLayer.Repository
{
    public class VehicleRepository:IVehicleRepository
    {
        private readonly string _connectionString;

        public VehicleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VehicleDTO Create (VehicleDTO vehicle) 
        {
            using (var connection = new SqlConnection(_connectionString)) 

            {
                connection.Open();

                using (var cmdvehicle = new SqlCommand(

                    @"INSERT INTO Vehicles (CarModel, CarMaker, YearofMfg, BasePrice) 
                    OUTPUT INSERTED.ID 
                    VALUES (@CarModel, @CarMaker, @YearofMfg, @BasePrice)",
                    connection)) 
                {
                    cmdvehicle.Parameters.AddWithValue("@CarModel", vehicle.CarModel);
                    cmdvehicle.Parameters.AddWithValue("@CarMaker", vehicle.CarMaker);
                    cmdvehicle.Parameters.AddWithValue("@YearofMfg", vehicle.YearofMfg);
                    cmdvehicle.Parameters.AddWithValue("@BasePrice", vehicle.BasePrice);
                   

                    var newId = (Guid)cmdvehicle.ExecuteScalar();
                    vehicle.ID = newId;
                }




            }
            return vehicle;



        }

        public void DeleteById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                        @"DELETE FROM Vehicles WHERE ID = @Id",connection
                    ))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }


        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            List<VehicleDTO> vehicles = new List<VehicleDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    @"SELECT ID, CarModel, CarMaker, YearofMfg, BasePrice 
                    FROM Vehicles", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vehicle = new VehicleDTO
                            {

                                ID = reader.GetGuid(reader.GetOrdinal("ID")),
                                CarModel = reader.GetString(reader.GetOrdinal("CarModel")),
                                CarMaker = reader.GetString(reader.GetOrdinal("CarMaker")),
                                YearofMfg = reader.GetString(reader.GetOrdinal("YearofMfg")),
                                BasePrice = reader.GetString(reader.GetOrdinal("BasePrice"))
                            };
                            vehicles.Add(vehicle);
                        }
                    }
                }
            }
            return vehicles;
        }

        public VehicleDTO GetById(Guid id)
        {
            
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                {
                    using (var  command = new SqlCommand(
                         @"SELECT ID, CarModel, CarMaker, YearofMfg, BasePrice 
                    FROM Vehicles WHERE ID = @Id", connection
                   ))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VehicleDTO
                                {
                                    ID = reader.GetGuid(reader.GetOrdinal("ID")),
                                    CarModel = reader.GetString(reader.GetOrdinal("CarModel")),
                                    CarMaker =reader.GetString(reader.GetOrdinal("CarMaker")),
                                    YearofMfg=reader.GetString(reader.GetOrdinal("YearofMfg")),
                                    BasePrice=reader.GetString(reader.GetOrdinal("BasePrice"))


                                };
                            }
                            else
                            {
                                return null; 
                            }



                        }




                    }
                }
                

            }
        }

        public VehicleDTO Update(VehicleDTO vehicle)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Vehicles 
                    SET CarModel = @CarModel, 
                        CarMaker = @CarMaker, 
                        YearofMfg = @YearofMfg, 
                        BasePrice = @BasePrice
                    WHERE ID = @Id";



                    command.Parameters.AddWithValue("@Id", vehicle.ID);
                    command.Parameters.AddWithValue("@CarModel", vehicle.CarModel);
                    command.Parameters.AddWithValue("@CarMaker", vehicle.CarMaker);
                    command.Parameters.AddWithValue("@YearofMfg", vehicle.YearofMfg);
                    command.Parameters.AddWithValue("@BasePrice", vehicle.BasePrice);

                    command.ExecuteNonQuery();
                }
            }
            return vehicle;
        }
    }
}
