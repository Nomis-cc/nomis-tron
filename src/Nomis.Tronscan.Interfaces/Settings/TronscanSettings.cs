using Nomis.Utils.Contracts.Common;

namespace Nomis.Tronscan.Interfaces.Settings
{
    /// <summary>
    /// Tronscan settings.
    /// </summary>
    public class TronscanSettings :
        ISettings
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://github.com/tronscan/tronscan-frontend/blob/dev2019/document/api.md"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }
    }
}