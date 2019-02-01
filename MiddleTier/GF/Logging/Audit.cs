using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Horizon4.GF.Logical;
using Horizon4.GF.WTT;

namespace Horizon4.GF
{
    /// <summary>
    /// Class to handle GroundFrame audit actions
    /// </summary>
    public static class Audit
    {
        /// <summary>
        /// Writes an entry to the log table in the GF Database
        /// </summary>
        /// <param name="Message"></param>
        public static GFResponse WriteLog(GFResponse Response, int ErrorNumber = 0, object ErrorObject = null)
        {
            //The Common.Application must be set before you can use the GroundFrame
            if (Common.Application == null)
            {
                throw new Exception("Cannot complete task as the application (Common.Application) has not been set");
            }

            //Get the SystemLocations from the Database
            using (SqlConnection conn = new SqlConnection(Common.SQLDBConn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("app.Usp_WRITE_AUDITLOG", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@application_itemno", (byte)Common.Application);
                        cmd.Parameters.AddWithValue("@audit_type_itemno", (byte)Response.Type);
                        cmd.Parameters.AddWithValue("@message", Response.Message);
                        cmd.Parameters.AddWithValue("@error_number", ErrorNumber);
                        cmd.Parameters.AddWithValue("@error_object_xml", ErrorObject == null ? (object)DBNull.Value : ErrorObject.Serialize().ToString());
                        SqlDataReader SQLReader = cmd.ExecuteReader();

                        //Parse the record returned by the reader
                        while (SQLReader.Read())
                        {
                            Response.AuditID = SQLReader.GetInt32(SQLReader.GetOrdinal("itemno"));
                        }
                    }

                    return Response;
                }
                catch (Exception Ex)
                {
                    return new GFResponse(AuditType.Fatal, @"Error trying to write a Repsonse to the GroundFrame audit log", Ex);
                }
            }
        }
    }
}
