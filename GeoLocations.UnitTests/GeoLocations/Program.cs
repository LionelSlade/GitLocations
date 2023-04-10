using GeoLocations.Net.BL.Enums;
using GeoLocations.Net.BL.Services;
using System;

namespace GeoLocations
{
    public class Program
    {       
        
        static void Main(string[] args)
        {
            //InsertJsonToSql()
            
            Console.WriteLine("Executing - ");
            var configuaration = new Configuration().Configurations;

            var ijTS = new InsertJsonToSql();
            //ijTS.Execute(configuaration["JsonFilePathGeoLocations"], enumJsonFileType.GeoLocations);
            var k = configuaration[enumJsonFileType.GeoLocations];
            //ijTS.Execute(configuaration[enumJsonFileType.GeoLocations enumJsonFileType.GeoLocations);
            ijTS.Execute(k.ToString(), enumJsonFileType.GeoLocations);


            Console.WriteLine("Completed Database Build");


        }

    }

    
}
