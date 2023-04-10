using GeoLocations.BL.Net.DAO;
using GeoLocations.BL.Net.Enums;
using GeoLocations.BL.Net.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GeoLocations.BL.Net.Utility
{
    public class CreateJsonObjects
    {
        #region Local
        internal string _ConnectionString { get; set; }

        #endregion

        #region PUBLIC
        public List<Exception> Errors = new List<Exception>();

        public List<CountryName.Root> CountryNamesObject { get; private set; }
        public List<Capitals.Root> CapitalsObject { get; private set; }

        //public dynamic GeoLocationsObject = null;
        public GeoLocation.Root GeoLocationsObject { get; set; }
        public CountryOutline.Root GeoCountryOutlinesObject = null;
        #endregion

        #region INITIALISATION
        public CreateJsonObjects(enumJsonFileType jsonFileType)
        {
            var configuration = new Configuration();
            var configurations = configuration.Configurations;
            _ConnectionString = configurations[enumJsonFileType.ConnectionSTR].ToString();
            if (jsonFileType == enumJsonFileType.All)
            {
                configurations.Remove(enumJsonFileType.ConnectionSTR);
                foreach (var k in configurations.Keys)
                {
                    var value = configurations[k];
                    SetJsonObject(value, k);
                }
            }
            else {
                var value = configurations[jsonFileType];
                SetJsonObject(value, jsonFileType);
            }

        }
        #endregion

        internal bool SetJsonObject(string jsonFilePath, enumJsonFileType fileType)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(jsonFilePath);
            string content = file.ReadToEnd();
            file.Close();

            dynamic deserialized = JsonConvert.DeserializeObject(content);
            bool result = false;
            switch (fileType)
            {
                case (enumJsonFileType.GeoLocations):
                    result = SetGeoLocations(content); break;
                case (enumJsonFileType.CountryOutline):
                    result = SetCountryOutline(content); break;
                case (enumJsonFileType.CountryNames):
                    result = SetCountryNames(content); break;
                case (enumJsonFileType.Capitals):
                    result = SetCapitals(content); break;
                default:
                    var ex = new Exception();
                    Errors.Add(ex);
                    result = false;
                    break;
            }

            return result;
        }

        internal bool SetGeoLocations(string content)
        {
            GeoLocation.Root GeoLocationRoot = JsonConvert.DeserializeObject<GeoLocation.Root>(content);
            var executeGeoLocations = new Utility.ExecuteGeoLocations(_ConnectionString);
            var result = executeGeoLocations.Execute(GeoLocationRoot);
            GeoLocationsObject = GeoLocationRoot;
            return result;
        }

        internal bool SetCountryOutline(string content)
        {
            CountryOutline.Root CountryOutlineRoot = JsonConvert.DeserializeObject<CountryOutline.Root>(content);
            var executeCountryOutline = new ExecuteCountryOutlines(_ConnectionString);
            var result = executeCountryOutline.Execute(CountryOutlineRoot);
            GeoCountryOutlinesObject = CountryOutlineRoot;
            return result;

        }

        internal bool SetCountryNames(string content)
        {
            List<CountryName.Root> CountryNameRoot = JsonConvert.DeserializeObject<List<CountryName.Root>>(content);
            CountryNamesObject = CountryNameRoot;
            var executeCountryNames = new ExecuteCountryNames();
            var result = executeCountryNames.Execute(CountryNameRoot, _ConnectionString, out Errors);
            return result;
        }

        internal bool SetCapitals(string content)
        {
            List<Capitals.Root> CapitalsRoot = JsonConvert.DeserializeObject<List<Capitals.Root>>(content);
            CapitalsObject = CapitalsRoot;
            var executeCapitals = new ExecuteCapitals();
            var result = executeCapitals.Execute(CapitalsRoot, _ConnectionString, out Errors);
            return result;
        }
    }
}
