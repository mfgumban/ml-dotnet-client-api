using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarkLogic.Client.Http
{
    public class HttpDataServiceRequestException : DataServiceRequestException
    {
        public HttpDataServiceRequestException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }

        public string RequestUri { get; private set; }

        public string MessageCode { get; private set; }

        public string MessageDetailTitle { get; private set; }

        public string Status { get; private set; }

        public int StatusCode { get; private set; }

        public static async Task<HttpDataServiceRequestException> CreateFromResponse(Uri requestUri, HttpResponseMessage response, Exception innerException = null)
        {
            string message = response.ReasonPhrase, messageCode = "", messageDetailTitle = "", status = "";
            int statusCode = Convert.ToInt32(response.StatusCode);

            var responseText = await response.Content.ReadAsStringAsync();

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

            return new HttpDataServiceRequestException(message, innerException)
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
