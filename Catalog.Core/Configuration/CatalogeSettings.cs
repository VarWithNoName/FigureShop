using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Configuration
{
    public class CatalogSettings
    {
        public string ApplicationName { get; set; }
        public string PicBaseUrl { get; set; }

        public string EventBusConnection { get; set; }

        public bool UseCustomizationData { get; set; }
        public bool AzureStorageEnabled { get; set; }
    }
}
