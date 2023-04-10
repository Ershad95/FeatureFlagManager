using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace FeatureFlag.Core
{
    public class FeatureFlagManager
    {
        private readonly List<FeatureFagItem> _featureFagItems;

        public FeatureFlagManager(string path)
        {
            var jsonContent = File.ReadAllText(path);
            _featureFagItems = JsonConvert.DeserializeObject<List<FeatureFagItem>>(jsonContent);
        }

        public bool IsActive(string nameOfFeature)
        {
            if (string.IsNullOrEmpty(nameOfFeature))
                throw new InvalidDataException();
            
            var featureFagItem = _featureFagItems.FirstOrDefault(x =>
                string.Equals(x.Name, nameOfFeature, StringComparison.CurrentCultureIgnoreCase));
            if (featureFagItem == null)
                throw new InvalidDataException();
            
            return featureFagItem.Enabled;
        }
    }
}