using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Data.SQL.SQLSystemUnitOfWork;
using System.Data;
using System.Data.SqlClient;

namespace Training.Workshop.Data.SQL
{
    public class BikeRepository : IBikeRepository
    {
        /// <summary>
        /// Save new bike in SQL Database
        /// </summary>
        /// <param name="bike"></param>
        public void Save(Bike bike)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "InsertBike";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Manufacturer", bike.Manufacturer);
                    command.Parameters.AddWithValue("Mark", bike.Mark);
                    command.Parameters.AddWithValue("BikeYear", bike.BikeYear);
                    command.Parameters.AddWithValue("ownerID", bike.OwnerID);
                    command.Parameters.AddWithValue("ConditionState", bike.ConditionState);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Delete all existing bikes with owner,mark from SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Delete(string mark, int ownerID)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "DeleteBike";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ownerID", ownerID);
                    command.Parameters.AddWithValue("mark", mark);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Find Only one bike by bikeID
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public Bike Find(int bikeID)
        {
            var bike = new Bike();
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "usp_FindBikebybikeID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("bikeID", bikeID);

                    var manufacturer = new SqlParameter("manufacturer", SqlDbType.VarChar);
                    manufacturer.Direction = ParameterDirection.Output;
                    manufacturer.Size = 30;
                    command.Parameters.Add(manufacturer);

                    var mark = new SqlParameter("mark", SqlDbType.VarChar);
                    mark.Direction = ParameterDirection.Output;
                    mark.Size = 50;
                    command.Parameters.Add(mark);

                    var bikeyear = new SqlParameter("bikeyear", SqlDbType.DateTime);
                    bikeyear.Direction = ParameterDirection.Output;
                    command.Parameters.Add(bikeyear);

                    var ownerid = new SqlParameter("ownerid", 0);
                    ownerid.Direction = ParameterDirection.Output;
                    command.Parameters.Add(ownerid);

                    var conditionstate = new SqlParameter("conditionstate", SqlDbType.VarChar);
                    conditionstate.Direction = ParameterDirection.Output;
                    conditionstate.Size = 30;
                    command.Parameters.Add(conditionstate);

                    command.ExecuteNonQuery();
                    //adding data from database to bike
                    bike.Manufacturer = command.Parameters["manufacturer"].Value.ToString();
                    bike.Mark = command.Parameters["mark"].Value.ToString();

                    if (command.Parameters["bikeyear"].Value.ToString() != "")
                    {
                        bike.BikeYear = Convert.ToDateTime(command.Parameters["bikeyear"].Value.ToString());
                        bike.OwnerID = int.Parse(command.Parameters["ownerid"].Value.ToString());
                    }
                    bike.ConditionState = command.Parameters["conditionstate"].Value.ToString();
                }

            }
            return bike;
        }
        /// <summary>
        /// Update existing bike with owner,mark in SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Update(string owner, string mark)
        {
        }
        /// <summary>
        /// Search all owner bikes by owner name
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public List<Bike> Search(string owner)
        {
            var OwnerBikes = new List<Bike>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "SearchBikesByOwner";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", owner);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        OwnerBikes.Add
                        (new Bike
                        {
                            Manufacturer = reader["Manufacturer"].ToString(),
                            Mark = reader["Mark"].ToString(),
                            OwnerID = int.Parse(reader["OwnerID"].ToString()),
                            BikeYear = Convert.ToDateTime(reader["BikeYear"].ToString()),
                            ConditionState = reader["ConditionState"].ToString()
                        }
                        );
                    }


                }
            }
            return OwnerBikes;
        }
        /// <summary>
        /// Return all bikes
        /// </summary>
        /// <returns></returns>
        public List<Bike> RetrieveAllBikes()
        {
            var allbikes = new List<Bike>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "RetrieveAllBikes";
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        allbikes.Add
                                    (new Bike
                                    {
                                        Manufacturer = reader["Manufacturer"].ToString(),
                                        Mark = reader["Mark"].ToString(),
                                        OwnerID = int.Parse(reader["OwnerID"].ToString()),
                                        BikeYear = Convert.ToDateTime(reader["BikeYear"].ToString()),
                                        ConditionState = reader["ConditionState"].ToString()
                                    }
                                    );
                    }
                }
            }
            return allbikes;
        }
        /// <summary>
        /// update condition of existing bike
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="ownerID"></param>
        /// <param name="condition"></param>
        public void UpdateCondition(string manufacturer, string mark, int ownerID, string condition, string newcondition)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText =


                    command.CommandText = "usp_UpdateBikeCondition";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("manufacturer", manufacturer);
                    command.Parameters.AddWithValue("mark", mark);
                    command.Parameters.AddWithValue("ownerID", ownerID);
                    command.Parameters.AddWithValue("condition", condition);
                    command.Parameters.AddWithValue("newcondition", newcondition);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
