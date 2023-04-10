using System;

namespace FeatureFlag.Core
{
    public partial class FeatureFagItem
    {
        public DateTime FeatureEnabledAfter { get; set; } = DateTime.MinValue;
    }
}