using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF
{
    public interface ISystemObject
    {
        string Name { get; set; }

        int ID { get; }

        string Description { get; set; }

        GFResponse SaveToDB();
    }

}
