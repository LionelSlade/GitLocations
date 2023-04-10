using GeoLocations.BL.Net.DAO;
using GeoLocations.BL.Net.Enums;
using GeoLocations.BL.Net.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeoLocations.BL.Net.Services
{
    public class InsertJsonToSql
    {
        private string _ConnectionString = string.Empty;
        private enumJsonFileType fileType = enumJsonFileType.Undefined;
        CreateTable _ct = new CreateTable();
        public List<Exception> Errors = new List<Exception>();

        public InsertJsonToSql()
        {

        }

        private bool InsertData(string jsonFilePath, enumJsonFileType fileType)
        {
            var result = false;


            return result;
        }


        //private void InsertInDataBaseCountyOutlines(List<CountryOutline> lstGeoLocation)
        //{
        //    SqlConnection connection = new SqlConnection(_ConnectionString);
            
        //    string createTableString =  _ct.GetCreateTableString(enumJsonFileType.CountryOutline);

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

        //            insertCommand.Parameters.Add("@ADMIN ", SqlDbType.NVarChar).Value = item.properties.ADMIN;
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
      
        public bool Execute(string jsonFilePath, enumJsonFileType fileType)
        {
            if (!(ValidateInputParamas(jsonFilePath, fileType))) { return false; }

            if (!(DoExecuteTask(jsonFilePath, fileType))) { return false; }

            return true;

        }

        private bool DoExecuteTask(string jsonFilePath, enumJsonFileType fileType)
        {
            try { InsertData(jsonFilePath, fileType); }
            catch (Exception ex)
            {
                createErrorLog(ex.Message);
                return false;
            }

            return true;
        }

        private bool ValidateInputParamas(string jsonFilePath, enumJsonFileType fileType)
        {
            //check a file type has been declared
            if (fileType == enumJsonFileType.Undefined)
            {
                var msg = "The filetype is not defined";
                createErrorLog(msg);
                return false;
            }

            //check the filePath is declared
            if ((jsonFilePath == null) || (jsonFilePath.Length == 0) || (jsonFilePath == string.Empty))
            {

                var msg = "The FilePath is not defined";
                createErrorLog(msg);
                return false;
            }

            //check the file exists
            if (!System.IO.File.Exists(jsonFilePath))
            {
                var msg = "The FilePath cannot be found ("+jsonFilePath+ "), ValidateInputParamas.";
                createErrorLog(msg);
                return false;
            }

            //check we have a valid connection string and DB connect
            var configuration = new Services.Configuration();
            var configurations = configuration.Configurations;            
            _ConnectionString = configurations[enumJsonFileType.ConnectionSTR];
            if ((_ConnectionString == null) || (_ConnectionString == string.Empty))
            {
                var msg = "The Database connection is not set";
                createErrorLog(msg);
                return false;
            }

            // validate the connection
            var canConnect = checkDB(_ConnectionString, fileType);
            if (!(canConnect))
            {
                var msg = "Cannot connect to the Database";
                createErrorLog(msg);
                return false;
            }
            return true;
        }

        private void createErrorLog(string msg)
        {
            var e = new Exception(msg);
            Errors.Add(e);
        }

        protected bool checkDB(string connString, enumJsonFileType fileType)
        {
            //var connString = @"Server=myServerName\myInstanceName;Database=myDataBase;Integrated Security=true;";
            string query;
            try
            {
                using (var con = new SqlConnection(connString))
                {
                    con.Open();

                    //see if the table exists
                    query = "Select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = '" + fileType.ToString() + "'";
                    using (var com = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = null;
                        reader = com.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        int numRows = dt.Rows.Count;
                        if (numRows == 0)
                        {
                            //CreateTable(fileType);
                            var ct = new CreateTable();
                            var res = ct.MakeNew(fileType, _ConnectionString, out Errors);
                            if (res == false) { return false; }
                        }
                    }

                    //TODO: add a setting to app.settings to control if overwrite = true
                    using (var com = new SqlCommand("SELECT Count(*) FROM " + fileType.ToString(), con))
                    {
                        int count = Convert.ToInt32(com.ExecuteScalar());
                        if (count > 0) //TODO: add a setting to app.settings to control if overwrite = true
                        {
                            //truncate the table                            
                            query = "TRUNCATE TABLE " + fileType.ToString();
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Errors.Add(ex);
                return false;
            }

        }


    }
}
