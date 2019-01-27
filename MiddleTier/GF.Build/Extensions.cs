using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Horizon4.GF.Build
{
    public static class Extensions
    {
        #region DateTime Extensions

        /// <summary>
        /// Gets YMDV for the date provided
        /// </summary>
        /// <param name="Value">Date to convert to YMDV</param>
        /// <returns></returns>
        public static int GetYMDV(this DateTime Value)
        {
            return ((Value.Year * 100 + Value.Month) * 100) + Value.Day;
        }

        #endregion DateTime Extensions

        #region SQLReader Extensions

        /// <summary>
        /// Gets the string value from a SQLDataReader item. If the DB value is NULL it returns an empty string
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Ordinal">The zero-based column ordinal</param>
        /// <returns></returns>
        public static string GetSafeString(this SqlDataReader Value, int Ordinal)
        {
            if (!Value.IsDBNull(Ordinal))
            {
                return Value.GetString(Ordinal);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the decimal value from a SQLDataReader item. If the DB value is NULL it returns 0.00
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Ordinal">The zero-based column ordinal</param>
        /// <returns></returns>
        public static decimal GetSafeDecimal(this SqlDataReader Value, int Ordinal)
        {
            if (!Value.IsDBNull(Ordinal))
            {
                return Value.GetDecimal(Ordinal);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the int value from a SQLDataReader item. If the DB value is NULL it returns 0
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Ordinal">The zero-based column ordinal</param>
        /// <returns></returns>
        public static Int32 GetSafeInt32(this SqlDataReader Value, int Ordinal)
        {
            if (!Value.IsDBNull(Ordinal))
            {
                return Value.GetInt32(Ordinal);
            }
            else
            {
                return 0;
            }
        }

        #endregion SQLReader Extensions

        #region Exception Extensions

        /// <summary>
        /// Gets an audit message from an exception
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Ordinal">The zero-based column ordinal</param>
        /// <returns></returns>
        public static string GetAuditMessage(this Exception Ex)
        {
            return string.Format(@"Source:- {0} | Base Exception:- {1} | Message:- {2}", Ex.Source, Ex.GetBaseException().GetCleanMessage(), Ex.GetCleanMessage());
        }

        /// <summary>
        /// Combines the Exception Message and Inner Exception message to return a unified message
        /// </summary>
        /// <returns></returns>
        public static string GetCleanMessage(this Exception Ex)
        {
            return Ex.InnerException == null ? Ex.Message : string.Format(@"{0} ({1})", Ex.Message, Ex.InnerException.Message);
        }

        #endregion Exception Extentions
    }
}
