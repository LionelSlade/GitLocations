using GeoLocations.BL.Net.DAO;
using GeoLocations.BL.Net.Enums;
using GeoLocations.BL.Net.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeoLocations.BL.Net.Services
{
    internal class ExecuteCapitals
    {

        private string _ConnectionString;
        private List<Exception> _errors = new List<Exception>();
        public bool hasErrors() { if (_errors.Count > 0) return true; return false; }
        CreateTable _ct = new CreateTable();

        public ExecuteCapitals()
        {
        }

        internal bool Execute(dynamic deserialized, string connectionString, out List<Exception> Errors)
        {
            _ConnectionString = connectionString;

            List<Capitals.Root> lstCapitals = new List<Capitals.Root>();
            foreach (var item in deserialized)
            {
                lstCapitals.Add(item);
            }
            InsertInDataBaseCapitals(lstCapitals);
            Errors = _errors;
            if (hasErrors()) { return false; }
            return true;
        }

        private bool InsertInDataBaseCapitals(List<Capitals.Root> lstCapitals)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);
            string createTableString = _ct.GetCreateTableString(enumJsonFileType.Capitals);
            string insertRecordsString = @"INSERT INTO [dbo].[Capitals]
            ([NAME], TLD, CCA2, CCN3, CCA3, CIOC, INDEPENDANT, STATUS, UN_MEMBER, CURRENCIES, IDD, CAPITAL, ALT_SPELLINGS, REGION, SUB_REGION, LANGUAGES, TRANSLATIONS, LAT_LONG, LANDLOCKED, BORDERS, AREA, FLAG, DEMONYMS)
                                            VALUES(@NAME, @TLD, @CCA2, @CCN3, @CCA3, @CIOC, @INDEPENDANT, @STATUS, @UN_MEMBER, @CURRENCIES, @IDD, @CAPITAL, @ALT_SPELLINGS, @REGION, @SUB_REGION, @LANGUAGES, @TRANSLATIONS, @LAT_LONG, @LANDLOCKED, @BORDERS, @AREA, @FLAG, @DEMONYMS)";

            try
            {
                connection.Open();

                SqlCommand createTable = new SqlCommand(createTableString, connection);

                try { createTable.ExecuteNonQuery(); }
                catch (Exception ex) { }
                finally { createTable.Dispose(); }

                foreach (Capitals.Root root in lstCapitals)
                {
                    SqlCommand insertCommand = new SqlCommand(insertRecordsString, connection);

                    var name = JsonConvert.SerializeObject(root.name);
                    insertCommand.Parameters.Add("@NAME ", SqlDbType.NVarChar).Value = name;
                    var tld = JsonConvert.SerializeObject(root.tld);
                    insertCommand.Parameters.Add("@TLD ", SqlDbType.NVarChar).Value = tld;
                    insertCommand.Parameters.Add("@CCA2 ", SqlDbType.NVarChar).Value = root.cca2;
                    insertCommand.Parameters.Add("@CCA3 ", SqlDbType.NVarChar).Value = root.cca3;
                    insertCommand.Parameters.Add("@CCN3 ", SqlDbType.NVarChar).Value = root.ccn3;
                    insertCommand.Parameters.Add("@CIOC ", SqlDbType.NVarChar).Value = root.cioc;
                    var i = root.independent ?? false;
                    insertCommand.Parameters.Add("@INDEPENDANT ", SqlDbType.NVarChar).Value = i;
                    insertCommand.Parameters.Add("@STATUS ", SqlDbType.NVarChar).Value = root.status;
                    insertCommand.Parameters.Add("@UN_MEMBER ", SqlDbType.NVarChar).Value = root.unMember;
                    insertCommand.Parameters.Add("@CURRENCIES ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.currencies);
                    insertCommand.Parameters.Add("@IDD ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.idd);
                    insertCommand.Parameters.Add("@CAPITAL ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.capital);
                    insertCommand.Parameters.Add("@ALT_SPELLINGS ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.altSpellings);
                    insertCommand.Parameters.Add("@REGION ", SqlDbType.NVarChar).Value = root.region;
                    insertCommand.Parameters.Add("@SUB_REGION ", SqlDbType.NVarChar).Value = root.subregion;
                    insertCommand.Parameters.Add("@LANGUAGES ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.languages);
                    insertCommand.Parameters.Add("@TRANSLATIONS ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.translations);
                    insertCommand.Parameters.Add("@LAT_LONG ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.latlng);
                    insertCommand.Parameters.Add("@LANDLOCKED ", SqlDbType.NVarChar).Value = root.landlocked;
                    insertCommand.Parameters.Add("@BORDERS ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.borders);
                    insertCommand.Parameters.Add("@AREA ", SqlDbType.NVarChar).Value = root.area;
                    insertCommand.Parameters.Add("@FLAG ", SqlDbType.NVarChar).Value = root.flag;
                    insertCommand.Parameters.Add("@DEMONYMS ", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(root.demonyms);

                    try { insertCommand.ExecuteNonQuery(); }
                    catch (Exception ex)
                    {
                        _errors.Add(ex);
                        return false;

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

            return true;
        }
    }
}