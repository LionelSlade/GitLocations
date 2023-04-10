using GeoLocations.BL.Net.DAO;
using GeoLocations.BL.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeoLocations.BL.Net.Utility
{
    internal class ExecuteCountryNames
    {
        private string _ConnectionString;
        private List<Exception> _errors = new List<Exception>();
        public bool hasErrors() { if (_errors.Count > 0) return true; return false; }
        CreateTable _ct = new CreateTable();

        internal bool Execute(dynamic deserialized, string connectionString, out List<Exception> Errors)
        {
            _ConnectionString = connectionString;

            List<CountryName.Root> lstCountryOutline = new List<CountryName.Root>();
            foreach (var item in deserialized)
            {   
                lstCountryOutline.Add(item);
            }
            InsertInDataBaseCountyName(lstCountryOutline);            
            Errors = _errors;
            if (hasErrors()) { return false; }
            return true;
        }

        private void InsertInDataBaseCountyName(List<CountryName.Root> lstCountyNames){
            SqlConnection connection = new SqlConnection(_ConnectionString);

            string createTableString = _ct.GetCreateTableString(enumJsonFileType.CountryOutline);

            string insertRecordsString = @"INSERT INTO [dbo].[CountryNames]
                                            ([ID], [IDSTR], [CODE2L], [CODE3L], [ENABLED], [ENABLEDSTR], [NAME_OFFICAL],[NAME],[NAMES], [CENTER] )
                                            VALUES(@ID, @IDSTR, @CODE2L, @CODE3L, @ENABLED, @ENABLEDSTR, @NAME_OFFICAL, @NAME, @NAMES, @CENTER)";

            try
            {
                connection.Open();

                SqlCommand createTable = new SqlCommand(createTableString, connection);

                try { createTable.ExecuteNonQuery(); }
                catch (Exception ex) { }
                finally { createTable.Dispose(); }

                foreach (DAO.CountryName.Root root in lstCountyNames)
                {
                    SqlCommand insertCommand = new SqlCommand(insertRecordsString, connection);

                    insertCommand.Parameters.Add("@ID ", SqlDbType.NVarChar).Value = Convert.ToInt32(root.id);
                    insertCommand.Parameters.Add("@IDSTR ", SqlDbType.NVarChar).Value = root.id;
                    insertCommand.Parameters.Add("@CODE2L ", SqlDbType.NVarChar).Value = root.code2l;
                    insertCommand.Parameters.Add("@CODE3L ", SqlDbType.NVarChar).Value = root.code3l;
                    insertCommand.Parameters.Add("@ENABLED ", SqlDbType.NVarChar).Value = Convert.ToBoolean(root.enabled);
                    insertCommand.Parameters.Add("@ENABLEDSTR ", SqlDbType.NVarChar).Value = root.enabled;
                    insertCommand.Parameters.Add("@NAME_OFFICAL ", SqlDbType.NVarChar).Value = root.name_official;
                    insertCommand.Parameters.Add("@NAME ", SqlDbType.NVarChar).Value = root.name;
                    var names = JsonConvert.SerializeObject(root.names);
                    insertCommand.Parameters.Add("@NAMES ", SqlDbType.NVarChar).Value = names;
                    var center = JsonConvert.SerializeObject(root.center);
                    insertCommand.Parameters.Add("@CENTER ", SqlDbType.NVarChar).Value = center;

                    try { insertCommand.ExecuteNonQuery(); }
                    catch (Exception ex)
                    {
                        _errors.Add(ex);
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
