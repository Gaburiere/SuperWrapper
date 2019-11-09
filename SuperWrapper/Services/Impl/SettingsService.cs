using System;
using System.Collections.Generic;

namespace SuperWrapper.Services.Impl
{
    public class SettingsService : ISettingsService
    {
        public Dictionary<AvailableContexts, Guid> Identifiers { get; set; } //todo cambiare in named tuple ed aggiungere l'url

        public void BuildIdentifiers()
        {
            this.Identifiers = new Dictionary<AvailableContexts, Guid>
            {
                {AvailableContexts.Telegram, Guid.NewGuid()},
                {AvailableContexts.Whatsapp, Guid.NewGuid()},
                {AvailableContexts.Spotify, Guid.NewGuid()}
            };
        }

        public Guid GetIdentifier(AvailableContexts availableContexts)
        {
            var got = this.Identifiers.TryGetValue(availableContexts, out Guid identifier);
            if(!got)
                throw new Exception($"Can't get identifier for {availableContexts}");
            return identifier;
        }
    }

    public enum AvailableContexts
    {
        Whatsapp,
        Telegram,
        Spotify
    }
}