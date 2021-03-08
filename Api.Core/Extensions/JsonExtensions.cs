using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Api.Core.Extensions
{
    public static class JsonExtensions
    {
        public static IMvcBuilder AddCustomJsonOptions(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return builder;
        }
    }
}
