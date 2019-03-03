using Newtonsoft.Json.Serialization;

namespace Jxt.Sitefinity.Jobs.ViewModel.Serialization
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}