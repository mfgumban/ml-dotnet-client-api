using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkLogic.Client
{
    public class DataServiceRequestException : Exception
    {
        private DataServiceRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public string RequestUri { get; private set; }

        public string MessageCode { get; private set; }

        public string MessageDetailTitle { get; private set; }

        public string Status { get; private set; }

        public int StatusCode { get; private set; }

        public static DataServiceRequestException CreateFromResponse(Uri requestUri, string responseText, Exception innerException = null)
        {
            string message = "", messageCode = "", messageDetailTitle = "", status = "";
            int statusCode = 0;
            var errorJson = JsonConvert.DeserializeObject(responseText);
            if (errorJson != null && errorJson is JObject)
            {
                var errorResponse = ((JObject)errorJson).Value<JObject>("errorResponse");
                if (errorResponse != null)
                {
                    message = errorResponse.Value<string>("message");
                    messageCode = errorResponse.Value<string>("messageCode");
                    status = errorResponse.Value<string>("status");
                    statusCode = errorResponse.Value<int>("statusCode");
                    var messageDetail = errorResponse.Value<JObject>("messageDetail");
                    if (messageDetail != null)
                    {
                        messageDetailTitle = messageDetail.Value<string>("messageTitle");
                    }
                }
            }
            else
            {
                message = responseText;
            }

            return new DataServiceRequestException(message, innerException)
            {
                RequestUri = requestUri.ToString(),
                MessageCode = messageCode,
                MessageDetailTitle = messageDetailTitle,
                Status = status,
                StatusCode = statusCode
            };
        }
    }
}
