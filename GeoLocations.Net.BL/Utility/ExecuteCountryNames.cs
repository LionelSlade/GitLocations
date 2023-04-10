using GeoLocations.Net.BL.DAO;
using GeoLocations.Net.BL.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
//using static GeoLocations.Net.BL.CountryNames;
using Newtonsoft.Json;

namespace GeoLocations.Net.BL.Utility
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
            InsertInDataBaseCountyName2(lstCountryOutline);            
            Errors = _errors;
            if (hasErrors()) { return false; }
            return true;
        }

        private void InsertInDataBaseCountyNames(List<CountryNames> lstCountyNames)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            string createTableString = _ct.GetCreateTableString(enumJsonFileType.CountryOutline);

            string insertRecordsString = @"INSERT INTO [dbo].[CountryNames]
                                            ([ID], [CODE2L], [CODE3L], [CENTER], [ENABLED], [NAME_OFFICAL],[NAME])
                                            VALUES(@ID, @CODE2L, @CODE3L, @CENTER, @ENABLED, @NAME_OFFICAL, @NAME)"; //, @NAMES)";

            try
            {
                connection.Open();

                SqlCommand createTable = new SqlCommand(createTableString, connection);

                try { createTable.ExecuteNonQuery(); }
                catch (Exception ex) { }
                finally { createTable.Dispose(); }

                foreach (var item in lstCountyNames)
                {
                    SqlCommand insertCommand = new SqlCommand(insertRecordsString, connection);

                    insertCommand.Parameters.Add("@ID ", SqlDbType.NVarChar).Value = item.ID;
                    insertCommand.Parameters.Add("@CODE2L ", SqlDbType.NVarChar).Value = item.CODE2L;
                    insertCommand.Parameters.Add("@CODE3L ", SqlDbType.NVarChar).Value = item.CODE3L;
                    insertCommand.Parameters.Add("@CENTER ", SqlDbType.NVarChar).Value = "";// item.CENTER;
                    insertCommand.Parameters.Add("@ENABLED ", SqlDbType.NVarChar).Value = item.ENABLED;
                    insertCommand.Parameters.Add("@NAME_OFFICAL ", SqlDbType.NVarChar).Value = item.NAME_OFFICAL;
                    insertCommand.Parameters.Add("@NAME ", SqlDbType.NVarChar).Value = item.NAME;
                    //insertCommand.Parameters.Add("@NAMES ", SqlDbType.NVarChar).Value = item.NAMES;

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

        private void InsertInDataBaseCountyName2(List<CountryName.Root> lstCountyNames){
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
