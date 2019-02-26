using Microsoft.Net.Http.Headers;
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
        private readonly CookieContainer _cookieJar;

        public HttpSessionState()
        {
            var idBytes = new byte[8];
            _idGenerator.Value.GetNonZeroBytes(idBytes);
            SessionId = BitConverter.ToInt64(idBytes, 0).ToString();
            _cookieJar = new CookieContainer();
        }

        public string SessionId { get; }

        internal void PrepareRequest(Uri requestUri, HttpRequestMessage request)
        {
            var cookies = _cookieJar.GetCookies(requestUri);
            if (cookies.Count > 0)
            {
                _cookieJar.Add(requestUri, new Cookie(HeaderNames.Cookie, $"SessionID={SessionId}"));
                var cookieHeader = _cookieJar.GetCookieHeader(requestUri);
                request.Headers.Add(HeaderNames.Cookie, cookieHeader);
            }
        }

        internal void ProcessResponse(Uri requestUri, HttpResponseMessage response)
        {
            IEnumerable<string> cookieHeaders;
            if (response.Headers.TryGetValues(HeaderNames.SetCookie, out cookieHeaders))
            {
                foreach(var cookieHeader in cookieHeaders)
                {
                    _cookieJar.SetCookies(requestUri, cookieHeader);
                }
            }
        }

        public bool Equals(ISessionState other)
        {
            return other != null && SessionId == other.SessionId;
        }
    }
}