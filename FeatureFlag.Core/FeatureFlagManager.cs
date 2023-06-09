using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FeatureFlag.Core
{
    public class FeatureFlagManager : IFeatureFlagManager
    {
        private readonly List<FeatureFagItem> _featureFagItems;

        public FeatureFlagManager(string path,IJsonConvertor jsonConvertor)
        {
            _featureFagItems = jsonConvertor.GetFeatureFagItems(path);
        }

        public bool IsActiveFeatureWithName(string nameOfFeature)
        {
            if (string.IsNullOrEmpty(nameOfFeature))
                throw new InvalidDataException();
            
            var featureFagItem = _featureFagItems.FirstOrDefault(x =>
                string.Equals(x.Name, nameOfFeature, StringComparison.CurrentCultureIgnoreCase));
            if (featureFagItem == null)
                throw new InvalidDataException();
            
            return featureFagItem.Enabled && CustomAttributeValidation(featureFagItem);
        }
        
        protected virtual bool CustomAttributeValidation(FeatureFagItem input)
        {
            return true;
        }

        public FeatureFagItem GetFeatureFlagInfoWithName(string nameOfFeature)
        {
            if (string.IsNullOrEmpty(nameOfFeature))
                throw new InvalidDataException();
            
            var featureFlag = _featureFagItems.FirstOrDefault(x =>
                string.Equals(x.Name, nameOfFeature, StringComparison.CurrentCultureIgnoreCase));
            if (featureFlag == null)
                throw new InvalidDataException();

            return featureFlag;
        }
    }

  

    public interface IFeatureFlagManager
    {
        bool IsActiveFeatureWithName(string nameOfFeature);
        FeatureFagItem GetFeatureFlagInfoWithName(string nameOfFeature);
    }
}