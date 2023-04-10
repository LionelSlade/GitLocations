using GeoLocations.Net.BL.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeoLocations.Net.BL.Services
{
    public class Configuration
    {
        public Dictionary<enumJsonFileType, string> Configurations= new Dictionary<enumJsonFileType, string>();// { get; set; }
       
        public Configuration() {
            
            //Configurations 
            Configurations.Add(enumJsonFileType.GeoLocations,JsonFilePathGeoLocations);
            Configurations.Add(enumJsonFileType.ConnectionSTR, ConnectionString);
            Configurations.Add(enumJsonFileType.CountryOutline, JsonFilePathCountryOutline);
            Configurations.Add(enumJsonFileType.CountryNames, JsonFilePathCountryNames);
            Configurations.Add(enumJsonFileType.Capitals, JsonFilePathCapitals);

            UpdateToLocalUserPath();

        }



        private void UpdateToLocalUserPath()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            string basepath = string.Empty;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
                //basepath = path.GetUntilOrEmpty("GeoLocations");
            }

            foreach (var cfg in Configurations.ToList())
            {

                //}
                //Configurations.for
                var value = cfg.Value;
                var key = cfg.Key;
                //var i = cfg.
                if (value != null)
                {
                    value = value.ToString().Replace("C:\\\\Users\\\\lione\\\\", path +"\\");
                    //cfg[cfg.Key()].Value=value;
                    Configurations[key] = value;
                }
            }
        }

        private string JsonFilePathCountryNames
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["JsonFilePathCountryNames"].ToString();

            }
        }
        private string JsonFilePathGeoLocations
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["JsonFilePathGeoLocations"].ToString();

            }
        }

        private string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionSTR"].ConnectionString;
            }
        }

        private string JsonFilePathCountryOutline
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["JsonFilePathCountryOutline"].ToString();
            }
        }

      
        private string JsonFilePathCapitals
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["JsonFilePathCapitals"].ToString();
            }
        }
    }
}
