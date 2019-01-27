using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horizon4.GF.Build
{
    /// <summary>
    /// Structure to handle a response from the build process
    /// </summary>
    public struct BuildResponse
    {
        private DateTime _ResponseTime;
        private BuildResponseType _ResponseType;
        private string _ResponseMessage;

        /// <summary>
        /// Gets the Response Time
        /// </summary>
        public DateTime ResponseTime { get { return this._ResponseTime; } }

        /// <summary>
        /// Gets the Repsonse Type
        /// </summary>
        public BuildResponseType ReponseType { get { return this._ResponseType; } }
 
        /// <summary>
        /// Gets the Response Message
        /// </summary>
        public string ResponseMessage { get { return this._ResponseMessage;}}

        /// <summary>
        /// Initialises a new BuildRsponse struct
        /// </summary>
        /// <param name="Type">The reponse type</param>
        /// <param name="Message">Any message associated with the response</param>
        public BuildResponse(BuildResponseType Type, string Message)
        {
            this._ResponseTime = DateTime.UtcNow;
            this._ResponseType = Type;
            this._ResponseMessage = Message;
        }
    }
}
