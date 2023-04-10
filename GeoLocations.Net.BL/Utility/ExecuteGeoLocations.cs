using GeoLocations.BL.Net.DAO;
using GeoLocations.BL.Net.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GeoLocations.BL.Net.Utility
{
    internal class ExecuteGeoLocations
    {

        string _connectionString;
        private CreateTable _ct = new CreateTable();

        public ExecuteGeoLocations(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }


        internal bool Execute(GeoLocation.Root GeoLocationRoot)
        {
            InsertIntoGeoLcations(GeoLocationRoot);
            return true;
        }
        private bool InsertIntoGeoLcations(GeoLocation.Root GeoLocationRoot)
        {
            try
            {
                InsertInDataBaseGeoLocation(GeoLocationRoot);
                return true;
            }
            catch { return false; }
        }

        public void InsertInDataBaseGeoLocation(GeoLocation.Root GeoLocationRoot)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string createTableString = _ct.GetCreateTableString(enumJsonFileType.GeoLocations);

            string insertRecordsString = @"INSERT INTO [dbo].[GeoLocations]
                                            ([GEO_ID], [STATE], [COUNTY], [NAME], [LSAD], [CENSUSAREA], [coordinates])

                                            VALUES(@GEO_ID, @STATE, @COUNTY, @NAME, @LSAD, @CENSUSAREA, @coordinates)";

            try
            {
                connection.Open();

                SqlCommand createTable = new SqlCommand(createTableString, connection);

                try { createTable.ExecuteNonQuery(); }
                catch (Exception ex) { }
                finally { createTable.Dispose(); }

                foreach (var item in GeoLocationRoot.features)
                {
                    SqlCommand insertCommand = new SqlCommand(insertRecordsString, connection);

                    insertCommand.Parameters.Add("@GEO_ID ", SqlDbType.NVarChar).Value = item.properties.GEO_ID;
                    insertCommand.Parameters.Add("@STATE      ", SqlDbType.NVarChar).Value = item.properties.STATE;
                    insertCommand.Parameters.Add("@COUNTY     ", SqlDbType.NVarChar).Value = item.properties.COUNTY;
                    insertCommand.Parameters.Add("@NAME       ", SqlDbType.NVarChar).Value = item.properties.NAME;
                    insertCommand.Parameters.Add("@LSAD       ", SqlDbType.NVarChar).Value = item.properties.LSAD;
                    insertCommand.Parameters.Add("@CENSUSAREA ", SqlDbType.NVarChar).Value = item.properties.CENSUSAREA;
                    insertCommand.Parameters.Add("@coordinates", SqlDbType.Text).Value = item.geometry.coordinates.ToString();

                    try { insertCommand.ExecuteNonQuery(); }
                    catch (Exception ex) { }
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