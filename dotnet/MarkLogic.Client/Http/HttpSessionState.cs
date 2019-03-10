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
        private readonly List<Cookie> _cookieJar;

        public HttpSessionState()
        {
            var idBytes = new byte[8];
            _idGenerator.Value.GetNonZeroBytes(idBytes);
            SessionId = BitConverter.ToUInt64(idBytes, 0).ToString("X").ToLower();
            _cookieJar = new List<Cookie>();
        }

        public string SessionId { get; }

        internal void PrepareRequest(Uri requestUri, HttpRequestMessage request)
        {
            var cookies = new CookieContainer();
            foreach(var cookie in _cookieJar)
            {
                cookies.Add(cookie);
            }
            if (!_cookieJar.Any(c => 
                c.Name.Equals("SessionID", StringComparison.InvariantCultureIgnoreCase) && 
                c.Domain.Equals(requestUri.Host, StringComparison.InvariantCultureIgnoreCase)))
            {
                cookies.Add(new Cookie("SessionID", SessionId, "/", requestUri.Host));
            }
            var cookieHeader = cookies.GetCookieHeader(requestUri);
            request.Headers.Add(HeaderNames.Cookie, cookieHeader);
        }

        internal void ProcessResponse(Uri requestUri, HttpResponseMessage response)
        {
            IEnumerable<string> setCookieHeaders;
            if (response.Headers.TryGetValues(HeaderNames.SetCookie, out setCookieHeaders))
            {
                var cookies = new CookieContainer();
                foreach(var setCookieHeader in setCookieHeaders)
                {
                    cookies.SetCookies(requestUri, setCookieHeader);
                }
                foreach(Cookie cookie in cookies.GetCookies(requestUri))
                {
                    var existingCookie = _cookieJar.FirstOrDefault(c =>
                        c.Name.Equals(cookie.Name, StringComparison.InvariantCultureIgnoreCase) &&
                        c.Domain.Equals(requestUri.Host, StringComparison.InvariantCultureIgnoreCase));
                    if (existingCookie != null)
                    {
                        _cookieJar.Remove(existingCookie);
                    }
                    _cookieJar.Add(cookie);
                }
            }
        }

        public bool Equals(ISessionState other)
        {
            return other != null && SessionId == other.SessionId;
        }
    }
}