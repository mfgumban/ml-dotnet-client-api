using System;

namespace MarkLogic.Client
{
    public interface ISessionState : IEquatable<ISessionState>
    {
        string SessionId { get; }
    }
}