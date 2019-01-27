using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GFDataEditor
{
    public class CommonDataEditor
    {
        public static string GetApplicationName()
        {
            return Properties.Settings.Default.ApplicationName;
        }
    }
}
