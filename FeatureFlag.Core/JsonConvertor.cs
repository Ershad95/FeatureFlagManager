using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FeatureFlag.Core
{
    public interface IJsonConvertor
    {
        List<FeatureFagItem> GetFeatureFagItems(string path);
    }
    public class JsonConvertor : IJsonConvertor
    {
        public List<FeatureFagItem> GetFeatureFagItems(string path)
        {
            var jsonContent = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<FeatureFagItem>>(jsonContent);
        }
    }
}