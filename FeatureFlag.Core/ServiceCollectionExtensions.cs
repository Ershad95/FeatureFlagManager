using Microsoft.Extensions.DependencyInjection;

namespace FeatureFlag.Core
{
    public static class ServiceCollectionExtensions
    {
        public static FeatureFilePath SetPathOfFeatureFlag(this IServiceCollection service,string path)
        {
            return new FeatureFilePath(path);
        }
        
        public static bool IsActiveFeatureWithName(this FeatureFilePath filePath,string nameOfFeature){
            return new FeatureFlagManager(filePath.Path,new JsonConvertor()).IsActiveFeatureWithName(nameOfFeature);
        }
    }

    public class FeatureFilePath
    {
        public string Path { get; }

        public FeatureFilePath(string path)
        {
            Path = path;
        }
    }
}