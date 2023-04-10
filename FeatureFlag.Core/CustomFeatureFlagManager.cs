using System;

namespace FeatureFlag.Core
{
    public class CustomFeatureFlagManager : FeatureFlagManager
    {
        public CustomFeatureFlagManager(string path) : base(path)
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