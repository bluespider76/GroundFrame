using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.WTT;

namespace Horizon4.GF
{
    /// <summary>
    /// Structure to hold Year Month Day Values
    /// </summary>
    [Serializable]
    public struct YMDV
    {
        private DateTime _Date; //Private variable to hold the YMDV Date
        private int _Value; //Prviate variable to hold the YMDV

        /// <summary>
        /// Initialise a new instance of a YMDV based on the date
        /// </summary>
        /// <param name="Date"></param>
        public YMDV(DateTime Date)
        {
            this._Date = Date;
            this._Value = Date.GetYMDV();
        }

        /// <summary>
        /// Initialise a new instance of a YMDV based on the YMDV value
        /// </summary>
        /// <param name="YMDV"></param>
        public YMDV(int YMDV)
        {
            this._Value = YMDV;
            this._Date = YMDVTools.ConvertYMDVToDateTime(YMDV);
        }

        /// <summary>
        /// Gets the YMDV value
        /// </summary>
        public int Value { get { return this._Value; } set {this._Value = value; } }

        /// <summary>
        /// Gets the YMDV date
        /// </summary>
        public DateTime Date { get { return this._Date; } }

        /// <summary>
        /// Gets the WTTDay for the YMDV
        /// </summary>
        public WTTDays WTTDay { get { return GetWTTDay(); } }

        /// <summary>
        /// Gets the display date for the YMDV
        /// </summary>
        public string DisplayDate { get { return GetDisplayDate(); } }

        #region Methods
        
        /// <summary>
        /// Calculates the WTTDay for the YMDV
        /// </summary>
        /// <returns>WTTDays</returns>
        private WTTDays GetWTTDay()
        {
            DayOfWeek _Day = _Date.DayOfWeek;

            switch (_Day)
            {
                case DayOfWeek.Sunday:
                    return WTTDays.Sunday;
                case DayOfWeek.Monday:
                    return WTTDays.Monday;
                case DayOfWeek.Tuesday:
                    return WTTDays.Tuesday;
                case DayOfWeek.Wednesday:
                    return WTTDays.Wednesday;
                case DayOfWeek.Thursday:
                    return WTTDays.Thursday;
                case DayOfWeek.Friday:
                    return WTTDays.Friday;
                case DayOfWeek.Saturday:
                    return WTTDays.Saturday;
                default:
                    return WTTDays.Sunday;
            }
        }

        /// <summary>
        /// Returns the date in a display friendly format
        /// </summary>
        /// <returns></returns>
        private string GetDisplayDate()
        {
            if (_Value == 0)
            {
                return "Today";
            }
            else
            {
                return _Date.ToString("dd/MM/yyyy");
            }
        }

        #endregion Methods
    }

    public static class YMDVTools
    {
        /// <summary>
        /// Converts a YMDV value to a Date
        /// </summary>
        public static DateTime ConvertYMDVToDateTime(int YMDV)
        {
            if (YMDV == 0)
            {
                return new DateTime(1800, 1, 1);
            }
            else
            {
                return new DateTime(Convert.ToInt32(YMDV.ToString().Substring(0, 4)), Convert.ToInt32(YMDV.ToString().Substring(4, 2)), Convert.ToInt32(YMDV.ToString().Substring(6, 2)));
            }
        }
    }
}
