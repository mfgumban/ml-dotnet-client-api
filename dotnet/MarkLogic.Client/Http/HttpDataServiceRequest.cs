using MarkLogic.Client.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarkLogic.Client.Http
{
    public class HttpDataServiceRequest : IDataServiceRequest
    {
        private readonly List<DataServiceParameter> _parameters = new List<DataServiceParameter>();
        private readonly HttpDatabaseClient _dbClient;
        
        internal HttpDataServiceRequest(HttpDatabaseClient dbClient, string servicePath, string moduleName)
        {
            _dbClient = dbClient;
            ServicePath = servicePath;
            ModuleName = moduleName;
            HttpMethod = HttpMethod.Post; // default
        }

        public string ServicePath { get; }

        public string ModuleName { get; }

        public HttpMethod HttpMethod { get; }

        public bool HasSession => Session != null;

        public ISessionState Session => HttpSession;

        internal HttpSessionState HttpSession { get; private set; }

        public IEnumerable<DataServiceParameter> Parameters => _parameters;

        public IDataServiceRequest WithSession(ISessionState session)
        {
            if (HttpSession == null)
            {
                HttpSession = null;
            }
            else if (!(session is HttpSessionState))
            {
                throw new InvalidOperationException("sessionState must be HttpSessionState."); // TODO: replace exception 
            }
            else
            {
                HttpSession = session as HttpSessionState;
            }
            return this;
        }

        public IDataServiceRequest WithParameters(params DataServiceParameter[] parameters)
        {
            _parameters.AddRange(parameters);
            return this;
        }

        private static List<HttpContent> BuildParameterHttpContent(DataServiceParameter parameter)
        {
            var contents = new List<HttpContent>();
            foreach(var marshal in parameter.GetMarshals())
            {
                var content = new StringContent(marshal.Value);
                content.Headers.ContentType = new MediaTypeHeaderValue(marshal.MediaType);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "\"" + parameter.Name + "\"" };
                contents.Add(content);
            }
            return contents;
        }

        private async Task<HttpResponseMessage> RequestAsync()
        {
            using (var request = new HttpRequestMessage(HttpMethod, $"{ServicePath}{ModuleName}"))
            {
                if (HasSession)
                {
                    HttpSession.PrepareRequest(request.RequestUri, request);
                }

                HttpContent content = null;
                if (_parameters.Count > 0)
                {
                    var requireMultipart = _parameters.SelectMany(p => p.GetMarshals()).FirstOrDefault(m => m.MediaType != Marshal.MediaTypes.Text) != null;
                    if (requireMultipart)
                    {
                        var multiPartContent = new MultipartFormDataContent();
                        _parameters.ForEach(p => BuildParameterHttpContent(p).ForEach(paramContent => multiPartContent.Add(paramContent, p.Name)));
                        content = multiPartContent;
                    }
                    else
                    {
                        var formContent = new FormUrlEncodedContent(_parameters
                            .SelectMany(p => p.GetMarshals(), (p, m) => new { param = p, marshal = m })
                            .Select(pm => new KeyValuePair<string, string>(pm.param.Name, pm.marshal.Value)));
                        content = formContent;
                    }
                }

                request.Content = content ?? request.Content;
                var response = await _dbClient.Http.SendAsync(request);
                response.EnsureSuccessStatusCode();

                if (HasSession)
                {
                    HttpSession.ProcessResponse(request.RequestUri, response);
                }

                content?.Dispose();

                return response;
            }
        }

        public async Task RequestNone()
        {
            var response = await RequestAsync();
        }

        public async Task<TResult> RequestSingle<TResult>(bool allowNull, Func<string, TResult> unmarshalValue)
        {
            var response = await RequestAsync();
            if (response.Content.IsMimeMultipartContent())
            {
                throw new InvalidOperationException("Expected content not multipart"); // TODO: replace exception
            }

            var value = unmarshalValue(await response.Content.ReadAsStringAsync());
            if (!allowNull && value == null)
            {
                throw new InvalidOperationException("Null return value not allowed"); // TODO: replace exception
            }
            response.Dispose();

            return value;
        }

        public async Task<IEnumerable<TResult>> RequestMultiple<TResult>(bool allowNull, Func<string, TResult> unmarshalValue)
        {
            var response = await RequestAsync();
            if (!response.Content.IsMimeMultipartContent())
            {
                throw new InvalidOperationException("Expected content to be multipart"); // TODO: replace exception
            }

            var contentStream = await response.Content.ReadAsMultipartAsync();
            var values = new List<TResult>();
            foreach (var content in contentStream.Contents)
            {
                // TODO: check custom header "X-Primitive" and validate against TResult
                var value = unmarshalValue(await content.ReadAsStringAsync());
                values.Add(value);
            }
            response.Dispose();

            return values;
        }
    }
}