using System;
using SuperWrapper.Services.Impl;

namespace SuperWrapper.Services
{
    public interface IConfigurationService
    {
        void BuildIdentifiers();
        (AvailableContexts Context, Guid Identifier, string Source) GetConfiguration(
            AvailableContexts availableContexts);

        (AvailableContexts Context, Guid Identifier, string Source) GetConfigurationBySource(string source);
    }
}