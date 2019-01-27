using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF.Build
{
    public static partial class Build
    {
        /// <summary>
        /// Gets or sets the name of the SQL server the test database can be created on
        /// </summary>
        public static bool BuildAll(ref List<BuildResponse> Responses, string SourceFolder, string TargetFolder, string TestDBServerName, string TestDBName)
        {
            Responses.Add(new BuildResponse(BuildResponseType.Information, "Build started."));

            //Build SQL Element
            Build.BuildSQL(ref Responses, SourceFolder, TargetFolder, TestDBServerName, TestDBName);

            if (Responses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
            {
                Responses.Add(new BuildResponse(BuildResponseType.Information, "Build errored. Build aborted"));
                return false;
            }

            Responses.Add(new BuildResponse(BuildResponseType.Information, "Build complete."));
            return true;
        }
    }
}
