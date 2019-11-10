using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperWrapper.Services.Impl
{
    public class ConfigurationService : IConfigurationService
    {
        private IList<(AvailableContexts Context, Guid Identifier, string Source)> _configurations; 

        public void BuildIdentifiers()
        {
            
            this._configurations = new List<(AvailableContexts Context, Guid Identifier, string Source)>()
            {
                (AvailableContexts.Telegram, Guid.NewGuid(), "https://web.telegram.org/#/im"),
                (AvailableContexts.Whatsapp, Guid.NewGuid(), "https://web.whatsapp.com/"), 
                (AvailableContexts.Spotify, Guid.NewGuid(), "https://open.spotify.com"),
                (AvailableContexts.Gmail, Guid.NewGuid(), "https://mail.google.com/"),
                (AvailableContexts.Skype, Guid.NewGuid(), "https://web.skype.com/")
            };
        }

        public (AvailableContexts Context, Guid Identifier, string Source) GetConfiguration(
            AvailableContexts availableContexts)
        {
            var configuration = this._configurations.Single(conf => conf.Item1 == availableContexts);
            return configuration;
        }

        public (AvailableContexts Context, Guid Identifier, string Source) GetConfigurationBySource(string source)
        {
            var tryConfiguration = this._configurations.SingleOrDefault(conf => conf.Source == source);
            if (tryConfiguration == default)
            {
                var retryConfiguration = this.GetConfigurationBySourceLoosely(source);
                if (retryConfiguration == default)
                    throw new Exception($"Can't find configuration from source {source}");
                return retryConfiguration;
            }

            return tryConfiguration;
        }

        private (AvailableContexts Context, Guid Identifier, string Source) GetConfigurationBySourceLoosely(string source)
        {
            if (source.Contains("whatsapp"))
                return this._configurations.Single(config => config.Context == AvailableContexts.Whatsapp);
            if (source.Contains("telegram"))
                return this._configurations.Single(config => config.Context == AvailableContexts.Telegram);
            if (source.Contains("spotify"))
                return this._configurations.Single(config => config.Context == AvailableContexts.Spotify);
            if (source.Contains("gmail"))
                return this._configurations.Single(config => config.Context == AvailableContexts.Gmail);
            if (source.Contains("skype"))
                return this._configurations.Single(config => config.Context == AvailableContexts.Skype);
            return default;
        }
    }

    public enum AvailableContexts
    {
        Whatsapp,
        Telegram,
        Spotify,
        Gmail,
        Skype
    }
}