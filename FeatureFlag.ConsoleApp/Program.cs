using FeatureFlag.Core;
Console.WriteLine("Start Test of Features");

var featureFlagManager = CreateFeatureFlagManager();
var payAndGoIsEnabled = featureFlagManager.IsActiveFeatureWithName("PayAndGo");
var rentalIsEnabled = featureFlagManager.IsActiveFeatureWithName("Rental");
var shippingIsEnabled = featureFlagManager.IsActiveFeatureWithName("Shipping");

Console.WriteLine(payAndGoIsEnabled ? "PayAndGo Is Enabled" : "PayAndGo Is Disabled");
Console.WriteLine(rentalIsEnabled ? "Rental Is Enabled" : "Rental Is Disabled");
Console.WriteLine(shippingIsEnabled ? "Shipping Is Enabled" : "Shipping Is Disabled");


Console.ReadLine();


CustomFeatureFlagManager CreateFeatureFlagManager()
{
    IJsonConvertor jsonConvertor = new JsonConvertor();
    const string pathOfFeatureJsonfile = "featureFlag.json";
    return new CustomFeatureFlagManager(pathOfFeatureJsonfile,jsonConvertor);
}