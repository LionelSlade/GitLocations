using GeoLocations.Net.BL.DAO;
using GeoLocations.Net.BL.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeoLocations.Net.BL.Utility
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

        //internal bool Execute(dynamic deserialized)
        //{
        //    List<CountryOutline> lstCountryOutline = new List<CountryOutline>();
        //    foreach (var item in deserialized.features)
        //    {
        //        lstCountryOutline.Add(new CountryOutline()
        //        {
        //            ADMIN = item.properties.ADMIN,
        //            ISO_A3 = item.properties.ISO_A3,
        //            coordinates = item.geometry.coordinates.ToString()
        //        });
        //    }

        //    InsertInDataBaseCountyOutlines(lstCountryOutline);
        //    return true;
        //}



        internal bool Execute(CountryOutline.Root CountryOutlineRoot)
        {   var result = false;

            //InsertInDataBaseCountyOutlines(deserialized);
            InsertInDataBaseCountyOutlines(CountryOutlineRoot);

            return result;
        }

        //private void InsertInDataBaseCountyOutlines(List<CountryOutline> lstGeoLocation)
        //{
        //    SqlConnection connection = new SqlConnection(_connectionString);

        //    string createTableString = _ct.GetCreateTableString((enumJsonFileType.CountryOutline));

        //    string insertRecordsString = @"INSERT INTO [dbo].[CountryOutline]
        //                                    ([ADMIN], [ISO_A3], [coordinates])
        //                                    VALUES(@ADMIN, @ISO_A3, @coordinates)";

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

        //            insertCommand.Parameters.Add("@ADMIN ", SqlDbType.NVarChar).Value = item.ADMIN;
        //            insertCommand.Parameters.Add("@ISO_A3 ", SqlDbType.NVarChar).Value = item.ISO_A3;
        //            insertCommand.Parameters.Add("@coordinates ", SqlDbType.NVarChar).Value = item.coordinates;

        //            try { insertCommand.ExecuteNonQuery(); }
        //            catch (Exception ex)
        //            {
        //                Errors.Add(ex);
        //            }
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