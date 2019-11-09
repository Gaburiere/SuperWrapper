using System;

namespace SuperWrapper.Services
{
    public interface IOneTimeService
    {
        bool IsIusPrimaeNoctis(Guid identifier);
        void Rape(Guid controlIdentifier);
    }
}