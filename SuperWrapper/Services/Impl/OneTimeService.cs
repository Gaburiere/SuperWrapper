using System;
using System.Collections.Generic;

namespace SuperWrapper.Services.Impl
{
    public class OneTimeService : IOneTimeService
    {
        private readonly List<Guid> _webViewsLifeCycles;
        public OneTimeService()
        {
            this._webViewsLifeCycles = new List<Guid>();
        }
        public bool IsIusPrimaeNoctis(Guid identifier)
        {
            return !this._webViewsLifeCycles.Contains(identifier);
        }

        public void Rape(Guid controlIdentifier)
        {
            this._webViewsLifeCycles.Add(controlIdentifier);
        }
    }
}