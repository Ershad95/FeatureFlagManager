// See https://aka.ms/new-console-template for more information

using FeatureFlag.Core;

Console.WriteLine("Start Test of Features");


const string pathOfFeatureJsonfile = "featureFlag.json";
var featureFlagManager = new CustomFeatureFlagManager(pathOfFeatureJsonfile);

var payAndGoIsEnabled = featureFlagManager.IsActiveFeatureWithName("PayAndGo");
var rentalIsEnabled =   featureFlagManager.IsActiveFeatureWithName("Rental");
var shippingIsEnabled = featureFlagManager.IsActiveFeatureWithName("Shipping");

Console.WriteLine(payAndGoIsEnabled ? "PayAndGo Is Enabled" : "PayAndGo Is Disabled");
Console.WriteLine(rentalIsEnabled ? "Rental Is Enabled" : "Rental Is Disabled");
Console.WriteLine(shippingIsEnabled ? "Shipping Is Enabled" : "Shipping Is Disabled");


Console.ReadLine();