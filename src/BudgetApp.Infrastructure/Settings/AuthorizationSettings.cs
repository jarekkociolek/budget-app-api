using System.Collections.Generic;
using System.ComponentModel;

namespace BudgetApp.Infrastructure.Settings
{
    public class AuthorizationSettings
    {
        public string Authority { get; set; }
        public string AuthorizationUrl { get; set; }
        public string TokenEndpointUrl { get; set; }
        public Dictionary<string, string> Scopes { get; set; }
    }
}
