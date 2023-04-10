using GeoLocations.BL.Net.DAO;
using GeoLocations.BL.Net.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeoLocations.BL.Net.Utility
{
    internal class ExecuteCountryOutlines
    {
        private string _connectionString;
        private CreateTable _ct = new CreateTable();
        public List<Exception> Errors = new List<Exception>();

        public ExecuteCountryOutlines(string connectionString)
        {
            this._connectionString = connectionString;
        }

        internal bool Execute(CountryOutline.Root CountryOutlineRoot)
        {   
            var result = false;
            InsertInDataBaseCountyOutlines(CountryOutlineRoot);
            return result;
        }

        private void InsertInDataBaseCountyOutlines(CountryOutline.Root CountryOutlineRoot)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string createTableString = _ct.GetCreateTableString((enumJsonFileType.CountryOutline));

            string insertRecordsString = @"INSERT INTO [dbo].[CountryOutline]
                                            ([ADMIN], [ISO_A3], [coordinates])
                                            VALUES(@ADMIN, @ISO_A3, @coordinates)";

            try
            {
                connection.Open();

                SqlCommand createTable = new SqlCommand(createTableString, connection);

                try { createTable.ExecuteNonQuery(); }
                catch (Exception ex) { }
                finally { createTable.Dispose(); }

                foreach (var item in CountryOutlineRoot.features)
                {
                    SqlCommand insertCommand = new SqlCommand(insertRecordsString, connection);

                    insertCommand.Parameters.Add("@ADMIN ", SqlDbType.NVarChar).Value = item.properties.ADMIN;
                    insertCommand.Parameters.Add("@ISO_A3 ", SqlDbType.NVarChar).Value = item.properties.ISO_A3;
                    insertCommand.Parameters.Add("@coordinates ", SqlDbType.NVarChar).Value = item.geometry.coordinates.ToString();

                    try { insertCommand.ExecuteNonQuery(); }
                    catch (Exception ex)
                    {
                        Errors.Add(ex);
                    }
                    finally { insertCommand.Dispose(); }
                }

            }
            catch (Exception) { }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }
    }
}