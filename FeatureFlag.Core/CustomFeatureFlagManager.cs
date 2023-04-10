using System;

namespace FeatureFlag.Core
{
    public class CustomFeatureFlagManager : FeatureFlagManager
    {
        public CustomFeatureFlagManager(string path,IJsonConvertor jsonConvertor) : base(path,jsonConvertor)
        {
        }

        protected override bool CustomAttributeValidation(FeatureFagItem input)
        {
            if (input.FeatureEnabledAfter == DateTime.MinValue)
            {
                return true;
            }
            return input.FeatureEnabledAfter >= DateTime.Now;
        }
    }
}