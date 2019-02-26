using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;

namespace MarkLogic.Client.Http
{
    internal class HttpSessionState : ISessionState
    {
        private ThreadLocal<RNGCryptoServiceProvider> _idGenerator = new ThreadLocal<RNGCryptoServiceProvider>(() => new RNGCryptoServiceProvider());
        private readonly string _sessionId;
        private readonly CookieContainer _cookieJar;

        public HttpSessionState()
        {
            var idBytes = new byte[8];
            _idGenerator.Value.GetNonZeroBytes(idBytes);
            _sessionId = BitConverter.ToInt64(idBytes, 0).ToString();
            _cookieJar = new CookieContainer();
        }

        public string SessionId => _sessionId;

        internal void PrepareRequest(Uri requestUri, HttpRequestMessage request)
        {
            var cookies = _cookieJar.GetCookies(requestUri);
            if (cookies.Count > 0)
            {
            }
        }

        internal void ProcessResponse(Uri requestUri, HttpResponseMessage response)
        {
            IEnumerable<string> cookieHeaders;
            if (response.Headers.TryGetValues("Set-Cookie", out cookieHeaders))
            {
                foreach(var cookieHeader in cookieHeaders)
                {
                    _cookieJar.SetCookies(requestUri, cookieHeader);
                }
            }
        }
    }
}