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

        //internal bool Execute(dynamic deserialized)
        //{

        //    //InsertInDataBaseCountyOutlines(lstCountryOutline);
        //    //InsertIntoGeoLcations()
        //    return true;

        //}

        internal bool Execute(GeoLocation.Root GeoLocationRoot)
        {
            InsertIntoGeoLcations(GeoLocationRoot);
            return true;
        }

        //private bool InsertIntoGeoLcations(dynamic deserialized)
        //{
        //    //try
        //    //{
        //    List<GeoLocation> lstGeoLocation = new List<GeoLocation>();
        //    foreach (var item in deserialized.features)
        //    {
        //        lstGeoLocation.Add(new GeoLocation()
        //        {
        //            propertoes.GEO_ID = item.properties.GEO_ID,
        //            LSAD = item.properties.LSAD,
        //            NAME = item.properties.NAME,
        //            STATE = item.properties.STATE,
        //            COUNTY = item.properties.COUNTY,
        //            CENSUSAREA = item.properties.CENSUSAREA,
        //            coordinates = item.geometry.coordinates.ToString()
        //        });
        //    }

        //    InsertInDataBaseGeoLocation(lstGeoLocation);
        //    return true;

        //}
        private bool InsertIntoGeoLcations(GeoLocation.Root GeoLocationRoot)
        {
            try
            {
                //List<GeoLocation> lstGeoLocation = new List<GeoLocation>();
                //foreach (var item in GeoLocationRoot.features)
                //{
                //    lstGeoLocation.Add(new GeoLocation()
                //    {
                //        propertoes.GEO_ID = item.properties.GEO_ID,
                //        LSAD = item.properties.LSAD,
                //        NAME = item.properties.NAME,
                //        STATE = item.properties.STATE,
                //        COUNTY = item.properties.COUNTY,
                //        CENSUSAREA = item.properties.CENSUSAREA,
                //        coordinates = item.geometry.coordinates.ToString()
                //    });
                //}

                InsertInDataBaseGeoLocation(GeoLocationRoot);
                return true;
            }
            catch { return false; }
        }


        //public void InsertInDataBaseGeoLocation(List<GeoLocation> lstGeoLocation)
        //{
        //    SqlConnection connection = new SqlConnection(_connectionString);

        //    string createTableString = _ct.GetCreateTableString(enumJsonFileType.GeoLocations);

        //    string insertRecordsString = @"INSERT INTO [dbo].[GeoLocations]
        //                                    ([GEO_ID], [STATE], [COUNTY], [NAME], [LSAD], [CENSUSAREA], [coordinates])

        //                                    VALUES(@GEO_ID, @STATE, @COUNTY, @NAME, @LSAD, @CENSUSAREA, @coordinates)";

        //    try
        //    {
        //        connection.Open();

        //        SqlCommand createTable = new SqlCommand(createTableString, connection);

        //        try { createTable.ExecuteNonQuery(); }
        //        catch (Exception ex) { }
        //        finally { createTable.Dispose(); }

        //        foreach (var item in lstGeoLocation)
        //        {
        //            SqlCommand insertCommand = new SqlCommand(insertRecordsString, connection);

        //            insertCommand.Parameters.Add("@GEO_ID ", SqlDbType.NVarChar).Value = item.GEO_ID;
        //            insertCommand.Parameters.Add("@STATE      ", SqlDbType.NVarChar).Value = item.STATE;
        //            insertCommand.Parameters.Add("@COUNTY     ", SqlDbType.NVarChar).Value = item.COUNTY;
        //            insertCommand.Parameters.Add("@NAME       ", SqlDbType.NVarChar).Value = item.NAME;
        //            insertCommand.Parameters.Add("@LSAD       ", SqlDbType.NVarChar).Value = item.LSAD;
        //            insertCommand.Parameters.Add("@CENSUSAREA ", SqlDbType.NVarChar).Value = item.CENSUSAREA;
        //            insertCommand.Parameters.Add("@coordinates", SqlDbType.Text).Value = item.coordinates;

        //            try { insertCommand.ExecuteNonQuery(); }
        //            catch (Exception ex) { }
        //            finally { insertCommand.Dispose(); }
        //        }
        //    }
        //    catch (Exception) { }
        //    finally
        //    {
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //}

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