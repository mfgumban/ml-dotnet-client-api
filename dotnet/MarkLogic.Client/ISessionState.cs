using System;

namespace MarkLogic.Client
{
    public interface ISessionState
    {
        string SessionId { get; }
    }
}