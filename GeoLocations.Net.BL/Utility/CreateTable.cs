using GeoLocations.BL.Net.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GeoLocations.BL.Net.Utility
{
    internal class CreateTable
    {
        private string _connectionString;
        private List<Exception> _errors;
        public bool hasErrors() { if (_errors.Count > 0) return true; return false; }

        internal string GetCreateTableString(enumJsonFileType fileType)
        {
            string createTableString = string.Empty;

            switch (fileType)
            {
                case (enumJsonFileType.GeoLocations):
                    createTableString = CreateTableGeoLocations();
                    break;
                case (enumJsonFileType.CountryOutline):
                    createTableString = CreateTableCountryOutline();
                    break;
                case (enumJsonFileType.CountryNames):
                    createTableString = CreateTableCountryNames();
                    break;
                case (enumJsonFileType.Capitals):
                    createTableString = CreateTableCapitals();
                    break;
            }

            return createTableString;
        }

        private string CreateTableCapitals()
        {
            return @"if not exists (select * from sysobjects where name='Capitals' 
                and xtype='U') CREATE TABLE [dbo].[Capitals]([NAME] [TEXT] NULL, [TLD] [TEXT] NULL, [CCA2] varchar(2) NULL, [CCN3] varchar(3) NULL, [CCA3] varchar(3) NULL, [CIOC] varchar(150) NULL,
                [INDEPENDANT] bit NULL, [STATUS] varchar(150) NULL, [UN_MEMBER] bit NULL, [CURRENCIES] [TEXT] NULL, [IDD] [TEXT] NULL, [CAPITAL] TEXT NULL, [ALT_SPELLINGS] TEXT NULL, 
                [REGION] VARCHAR(150) NULL, [SUB_REGION] VARCHAR (150), LANGUAGES TEXT NULL, [TRANSLATIONS] TEXT NULL, [LAT_LONG] TEXT NULL, [LANDLOCKED] BIT, [BORDERS] TEXT NULL, 
                [AREA] DECIMAL NULL, [FLAG] VARCHAR(150), [DEMONYMS] TEXT NULL)
                ON [PRIMARY]";
        }

        public bool MakeNew(enumJsonFileType fileType, string ConnectionString, out List<Exception> Errors)
        {
            _connectionString = ConnectionString; _errors = new List<Exception>();
            
            string createTableString = GetCreateTableString(fileType);
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();

                SqlCommand createTable = new SqlCommand(createTableString, connection);

                try { createTable.ExecuteNonQuery(); }
                catch (Exception ex) { }
                finally { createTable.Dispose(); }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                _errors.Add(ex);
                connection.Close();
                //return false;

            }
            finally
            {
                connection.Close();
            }

            Errors = _errors;
            if (hasErrors()) { return false; }
            return true;


        }
        /// <summary>
        /// Creates the table for the country name
        /// TODO: NAMES Field gets corrupted.  The RU/Arabic and Chinese names regular ASCII, DB needs to have its TypeChanged
        /// With hindsight, i can see just reading from the Json is just safer, less work and as easily manipluled as the DB .
        /// </summary>
        /// <returns></returns>
        private string CreateTableCountryNames()
        {
            return @"if not exists (select * from sysobjects where name='CountryNames' 
                and xtype='U')
                            CREATE TABLE [dbo].[CountryNames](
                            [ID] [INT] NULL,
                            [IDSTR] [varchar](150) NULL,
                            [CODE2L] [varchar](2) NULL,
                            [CODE3L] [varchar](3) NULL,
                            [ENABLED] BIT NULL,
                            [ENABLEDSTR] [varchar](5) NULL,
                            [NAME] [varchar](150) NULL,
                            [NAME_OFFICAL] [varchar](150) NULL,
                            [NAMES] [varchar](MAX) NULL,
                            [CENTER] [text] NULL) ON [PRIMARY]";
        }

        private string CreateTableCountryOutline()
        {
            return @"if not exists (select * from sysobjects where name='CountryOutline' 
                and xtype='U')
                            CREATE TABLE [dbo].[CountryOutline](	
                            [ADMIN] [varchar](150) NULL,	
                            [ISO_A3] [varchar](3) NULL,
                            [coordinates] [text] NULL) ON [PRIMARY]";
        }

        private string CreateTableGeoLocations()
        {
            return @"if not exists (select * from sysobjects where name='GeoLocations' and xtype='U')
                                                CREATE TABLE [dbo].[GeoLocations](	[GEO_ID] [varchar](100) NULL,	[STATE] [varchar](100) NULL,	[COUNTY] [varchar](100) NULL,	[NAME] [varchar](100) NULL,	[LSAD] [varchar](100) NULL,	[CENSUSAREA] [varchar](100) NULL,	[coordinates] [text] NULL) ON [PRIMARY]";
        }
    }
}
