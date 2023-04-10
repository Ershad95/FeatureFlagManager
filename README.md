# Feature Flag Manager

### Overview
Feature Flag Manager is a simple .NET library for managing feature flags in your application. It allows you to easily enable or disable specific features based on conditions, such as user roles, environment, or any other custom criteria.

### Getting Started
To use Feature Flag Manager in your .NET project, follow these steps:

1- Create a JSON file with your feature flags configuration. The JSON file should contain an array of feature flag items, each of which has a name, description, and a boolean value indicating whether the feature is enabled or disabled. You can also add custom attributes to each item to define additional criteria for enabling or disabling the feature.

2- Create an instance of the FeatureFlagManager class and pass the path to your JSON file and a <b>JsonConvertor</b> instance as parameters.

3- Use the <b>IsActiveFeatureWithName</b> method to check if a specific feature is enabled or disabled based on its name.

4- Use the <b>GetFeatureFlagInfoWithName</b> method to get information about a specific feature flag based on its name.

<pre>
// Example usage

// Create a JSON file with your feature flags configuration
// features.json
// [
//   {
//     "Name": "Feature A",
//     "Description": "This is feature A",
//     "Enabled": true
//   },
//   {
//     "Name": "Feature B",
//     "Description": "This is feature B",
//     "Enabled": false,
//     "CustomAttributes": {
//       "Environment": ["dev", "qa"]
//     }
//   }
// ]

// Create an instance of the FeatureFlagManager class
var featureFlagManager = new FeatureFlagManager("features.json", new JsonConvertor());

// Check if Feature A is enabled
bool isFeatureAEnabled = featureFlagManager.IsActiveFeatureWithName("Feature A");

// Get information about Feature B
FeatureFagItem featureBInfo = featureFlagManager.GetFeatureFlagInfoWithName("Feature B");

</pre>

### Custom Attribute Validation

You can define custom attributes for each feature flag item to enable or disable the feature based on specific criteria. To do this, you can override the CustomAttributeValidation method in your own implementation of the FeatureFlagManager class.

<pre>
public class CustomFeatureFlagManager : FeatureFlagManager
{
    public CustomFeatureFlagManager(string path, IJsonConvertor jsonConvertor) : base(path, jsonConvertor)
    {
    }

    protected override bool CustomAttributeValidation(FeatureFagItem input)
    {
        // Check custom attributes for input feature flag item
        // Return true if all criteria are met, otherwise return false
    }
}
</pre>

### Contributing
Contributions to Feature Flag Manager are welcome! If you'd like to contribute, please submit a pull request with your changes.
