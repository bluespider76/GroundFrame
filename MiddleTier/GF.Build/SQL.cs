using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Horizon4.GF;

namespace Horizon4.GF.Build
{
    /// <summary>
    /// Handles the SQL element of the build
    /// </summary>
    public static partial class Build
    {
        private static string _BuildSQL; //Private variable to store the build SQL script
        private static string _TestSQLDBName; //Private variable to store the Test SQL DB Name
        private static string _TestSQLDBServer; //Private variable to store the Test SQL DB Server

        internal static void DeploySQL(ref List<BuildResponse> Responses, string TestDBServerName, string TestDBName)
        {
            Responses.Add(new BuildResponse(BuildResponseType.Information, "Executing SQL started."));

            //Build Connection
            string Connection = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", _TestSQLDBServer, TestDBName);

            using (SqlConnection conn = new SqlConnection(Connection))
            {
                try
                {
                    Server _Server = new Server(new ServerConnection(conn));
                    _Server.ConnectionContext.ExecuteNonQuery(_BuildSQL);
                }
                catch (Exception Ex)
                {
                    Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format("Deploying SQL Script to Database {0} on {1} has errored :- {2}", _TestSQLDBName, _TestSQLDBServer, Ex.GetCleanMessage())));
                    return;
                }
            }

            Responses.Add(new BuildResponse(BuildResponseType.Information, "Executing SQL completed."));
        }

        /// <summary>
        /// Gets or sets the name of the SQL server the test database can be created on
        /// </summary>
        internal static void BuildSQL(ref List<BuildResponse> Responses, string SourceFolder, string TargetFolder, string TestDBServerName, string TestDBName)
        {
            _TestSQLDBName = TestDBName;
            _TestSQLDBServer = TestDBServerName;

            //Start Build
            Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build started."));

            //Build SQL Files
            BuildSQLFiles(ref Responses, SourceFolder, TargetFolder, new string[] { "Schema", "Tables", "Functions", "Stored Procedures", "Data Population"});

            //Check for Error. If Found Quit.
            if (Responses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build errored. Build aborted"));
                return;
            }

            //Check to see if TestDB already exists
            bool DoesTestDatabaseAlreadyExists = CheckTestDatabaseExists(ref Responses);

            //Check for Error. If Found Quit.
            if (Responses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build errored. Build aborted"));
                return;
            }

            //If Test DB already exists then drop.
            if (DoesTestDatabaseAlreadyExists)
            {
                DeleteTestDatabase(ref Responses);

                //Check for Error. If Found Quit.
                if (Responses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
                {
                    Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build errored. Build aborted"));
                    return;
                }
            }

            //Create new Test DB
            CreateTestDB(ref Responses);

            //Check for Error. If Found Quit.
            if (Responses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build errored. Build aborted"));
                return;
            }

            //Deploy SQL to Test Database

            DeploySQL(ref Responses, _TestSQLDBServer, _TestSQLDBName);

            //Check for Error. If Found Quit.
            if (Responses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build errored. Build aborted"));
                return;
            }

            Responses.Add(new BuildResponse(BuildResponseType.Information, "SQL Build complete."));
            return;
        }

        private static void CreateTestDB(ref List<BuildResponse> Responses)
        {
            Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format("Creating Test Database {0} on {1} started.", _TestSQLDBName, _TestSQLDBServer)));

            string CreationSQL = string.Format(@"CREATE DATABASE [{0}] ON PRIMARY "
            + @"(NAME = N'MWB_REPORTING', FILENAME = N'E:\DATA\{0}.mdf' , SIZE = 4096KB , FILEGROWTH = 1024KB ) "
            + "LOG ON  "
            + @"(NAME = N'MWB_REPORTING_log', FILENAME = N'F:\LOGS\{0}_log.ldf' , SIZE = 8192KB , FILEGROWTH = 10%) "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET ANSI_NULL_DEFAULT OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET ANSI_NULLS OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET ANSI_PADDING OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET ANSI_WARNINGS OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET ARITHABORT OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET AUTO_CLOSE OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET AUTO_CREATE_STATISTICS ON "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET AUTO_SHRINK OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET AUTO_UPDATE_STATISTICS ON "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET CURSOR_CLOSE_ON_COMMIT OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET CURSOR_DEFAULT  GLOBAL "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET CONCAT_NULL_YIELDS_NULL OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET NUMERIC_ROUNDABORT OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET QUOTED_IDENTIFIER OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET RECURSIVE_TRIGGERS OFF "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET  DISABLE_BROKER "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF; "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET DATE_CORRELATION_OPTIMIZATION OFF; "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET PARAMETERIZATION SIMPLE; "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET  READ_WRITE; "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET RECOVERY FULL; "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET  MULTI_USER; "
            //+ "\nGO\n"
            //+ "ALTER DATABASE [{0}] SET PAGE_VERIFY CHECKSUM "
            //+ "\nGO\n"
            //+ "USE [{0}] "
            //+ "\nGO\n"
            //+ "IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [{0}] MODIFY FILEGROUP [PRIMARY] DEFAULT "
            //+ "\nGO\n"
            , _TestSQLDBName.ToUpper());

            string Connection = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=SSPI;", _TestSQLDBServer);

            using (SqlConnection conn = new SqlConnection(Connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CreationSQL, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex)
                {
                    Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format("Creating Test Database {0} on {1} has errored :- {2}", _TestSQLDBName, _TestSQLDBServer, Ex.Message)));
                    return;
                }
            }

            Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format("Creating Test Database {0} on {1} completed.", _TestSQLDBName, _TestSQLDBServer)));
        }

        /// <summary>
        /// Checks whether the Test Database exists on the server.
        /// </summary>
        /// <param name="Responses"></param>
        /// <returns>True = Exists | False = Does Not Exist</returns>
        private static bool CheckTestDatabaseExists(ref List<BuildResponse> Responses)
        {
            Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format("Checking existence of Test Database {0} on {1} started.", _TestSQLDBName, _TestSQLDBServer)));
                
            bool Result = false; //Holds result of check

            //Build SQL Statement
            string CheckDatabaseSQL = string.Format("IF EXISTS (SELECT 1 FROM sys.databases WHERE name = '{0}')"
            +"\nBEGIN"
            +"\nSELECT database_exists = CONVERT(BIT,1)"
            +"\nEND"
            +"\nELSE"
            +"\nBEGIN"
            +"\nSELECT database_exists = CONVERT(BIT,0)"
            +"\nEND", _TestSQLDBName);

            //Build Connection String
            string Connection = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=SSPI;", _TestSQLDBServer);

            using (SqlConnection conn = new SqlConnection(Connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CheckDatabaseSQL, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            Result = SQLReader.GetBoolean(SQLReader.GetOrdinal("database_exists"));
                        }
                    }

                    Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format("Checking existence of Test Database {0} on {1} completed.", _TestSQLDBName, _TestSQLDBServer)));
                    return Result;
                }
                catch (Exception Ex)
                {
                    Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format("Checking existence of Test Database {0} on {1} has errored :- {2}", _TestSQLDBName, _TestSQLDBServer, Ex.Message)));
                    return false;
                }
            }
        }

        private static void DeleteTestDatabase(ref List<BuildResponse> Responses)
        {
            Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format("Deleting Test Database {0} on {1} started.", _TestSQLDBName, _TestSQLDBServer)));

            //Build SQL String
            string DeleteDatabaseSQL = string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{0}];", _TestSQLDBName);
            //Build Connection String
            string Connection = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=SSPI;", _TestSQLDBServer);

            using (SqlConnection conn = new SqlConnection(Connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(DeleteDatabaseSQL, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex)
                {
                    Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format("Deleting Test Database {0} on {1} has errored :- {2}", _TestSQLDBName, _TestSQLDBServer, Ex.Message)));
                    return;
                }

                Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format("Deleting Test Database {0} on {1} completed.", _TestSQLDBName, _TestSQLDBServer)));
            }
        }

        /// <summary>
        /// Combines the individual SQL scripts into a master SQL file.
        /// </summary>
        /// <param name="Responses"></param>
        /// <param name="SourceFolder"></param>
        /// <param name="Target"></param>
        /// <param name="FolderBuildOrder"></param>
        private static void BuildSQLFiles(ref List<BuildResponse> Responses, string SourceFolder, string Target, string[] FolderBuildOrder)
        {
            _BuildSQL = string.Empty; //Holds the SQL as it's built up from the seperate SQL files

            Responses.Add(new BuildResponse(BuildResponseType.Information, "Build SQL files started."));

            //Check to see whether the source folder exists.
            if (!Directory.Exists(SourceFolder))
            {
                Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format("SQL Build Failed:- Source Folder {0} does not exist.", SourceFolder)));
                return;
            }

            //Get list of Directories in the Source Folder
            string[] Directories = Directory.GetDirectories(SourceFolder);

            //Loop around each Build Order Folder
            for (int f = 0; f < FolderBuildOrder.Length; f++)
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format(@"Building SQL Folder {0} started.", FolderBuildOrder[f])));

                //Now loop around each directory in the Source Folder
                for (int d = 0; d < Directories.Length; d++)
                {
                    //Get the name of the directory
                    string DirectoryName = Directories[d].Substring((Directories[d].LastIndexOf(@"\") + 1), Directories[d].Length - (Directories[d].LastIndexOf(@"\") + 1));

                    //If the directory name matches the current build folder build the SQL file
                    if (DirectoryName.ToLower() == FolderBuildOrder[f].ToLower())
                    {
                        try
                        {
                            BuildFolder(ref Responses, Directories[d]);
                        }
                        catch (Exception Ex)
                        {
                            Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format("SQL Build Failed building directory {0}:- {1}", Directories[d], Ex.Message)));
                            return;
                        }
                    }
                }

                Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format(@"Building SQL Folder {0} completed.", FolderBuildOrder[f])));
            }

            Responses.Add(new BuildResponse(BuildResponseType.Information, "Build SQL files completed."));

            return;
        }

        /// <summary>
        /// Reads each file in the Folder and concatenates the SQL into the Build SQL
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="BuildSQL"></param>
        private static void BuildFolder(ref List<BuildResponse> Responses, string Folder)
        {
            //Get a list of the SQL folders in the Folder
            string[] SQLFiles = Directory.GetFiles(Folder, "*.sql", SearchOption.AllDirectories);

            foreach (string SQLFile in SQLFiles.OrderBy(x => x))
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format(@"Building SQL File {0} started.", SQLFile)));
                try
                {
                    AppendSQLStatement(SQLFile);
                    Responses.Add(new BuildResponse(BuildResponseType.Information, string.Format(@"Building SQL File {0} completed..", SQLFile)));

                }
                catch (Exception Ex)
                {
                    Responses.Add(new BuildResponse(BuildResponseType.Error, string.Format(@"Building SQL File {0} failed :- {1}", SQLFile, Ex.Message)));
                }
            }
        }

        /// <summary>
        /// Appends a SQL file to the _BuildSQL variable
        /// </summary>
        /// <param name="File"></param>
        private static void AppendSQLStatement(string File)
        {
            StringBuilder Builder = new StringBuilder(_BuildSQL);
            Builder.AppendLine();
            Builder.Append("GO");
            Builder.AppendLine();
            Builder.AppendLine();
            Builder.Append(string.Format(@"--Source File - {0}", File));
            Builder.AppendLine();
            Builder.AppendLine();
            Builder.Append(ReadSQLFile(File));
            Builder.AppendLine();
            Builder.Append("GO");

            _BuildSQL = Builder.ToString();
        }

        /// <summary>
        /// Reads a SQL file, cleans up the result and parses it to test it's valid.
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        private static string ReadSQLFile(string File)
        {
            string SQL;

            using (StreamReader reader = new StreamReader(File))
            {
                SQL = reader.ReadToEnd();
            }

            //Parse SQL

            try
            {
                SQL = CleanUpSQL(SQL);
                ParseSQL(SQL);
                return SQL;
            }
            catch (Exception Ex)
            {
                throw new Exception(string.Format(@"Error Reading SQLFile {0} :- {1}", File, Ex.Message));
            }
        }

        /// <summary>
        /// Cleans up a SQL file.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        private static string CleanUpSQL(string SQL)
        {
            //Remove any trailing new line
            return SQL.TrimEnd(new char[] { '\r', '\n' });
        }
        
        /// <summary>
        /// Parses a SQL statement to ensure it's valud
        /// </summary>
        /// <param name="SQL"></param>
        private static void ParseSQL(string SQL)
        {
            if (!SQL.ToUpper().EndsWith("GO"))
            {
                throw new Exception (@"SQL statement must end with ""GO""");
            }

        }
    }
}
