using System;
using SuperWrapper.Services.Impl;

namespace SuperWrapper.Services
{
    public interface ISettingsService
    {
        void BuildIdentifiers();
        Guid GetIdentifier(AvailableContexts availableContexts);
    }
}