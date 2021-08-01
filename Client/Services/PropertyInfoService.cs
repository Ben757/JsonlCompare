using System;
using System.Collections.Generic;
using System.Linq;
using JsonlCompare.Client.Interfaces;
using JsonlCompare.Client.Models;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Services
{
    public class PropertyInfoService : IPropertyInfoService
    {
        private readonly IJsonContainer jsonContainer;

        public PropertyInfoService(IJsonContainer jsonContainer)
        {
            this.jsonContainer = jsonContainer;
        }

        public IEnumerable<JsonPropertyInfo> GetPropertyContainer()
        {
            var jsons = jsonContainer.Jsons;

            var maxJson = CombineJsons(jsons);

            return HandleJObject(maxJson);
        }

        private JObject CombineJsons(IReadOnlyList<JObject> jsons)
        {
            var maxJson = jsons.First();

            foreach (var json in jsons.Skip(1))
                maxJson.Merge(json, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Merge,
                    PropertyNameComparison = StringComparison.InvariantCultureIgnoreCase,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore
                });

            return maxJson;
        }

        private IReadOnlyList<JsonPropertyInfo> HandleJObject(JObject json)
        {
            return json.Children()
                .Select(HandleJToken)
                .ToList();
        }

        private JsonPropertyInfo HandleJToken(JToken jToken)
        {
            var jsonProperty = new JsonPropertyInfo();

            var prop = jToken as JProperty;

            switch (prop!.Value)
            {
                case JObject jObject:
                    SetPropertyNameAndPath(jToken, jsonProperty);
                    jsonProperty.Children = HandleJObject(jObject);
                    break;
                case JArray jArray:
                    SetPropertyNameAndPath(jToken, jsonProperty);
                    jsonProperty.Children = HandleJArray(jArray);
                    break;
                default:
                    SetPropertyNameAndPath(jToken, jsonProperty);
                    break;
            }

            return jsonProperty;
        }

        private static void SetPropertyNameAndPath(JToken jToken, JsonPropertyInfo jsonProperty)
        {
            jsonProperty.Name = jToken.Path.Split(".").Last();
            jsonProperty.Path = jToken.Path;
        }

        private List<JsonPropertyInfo> HandleJArray(JArray jArray)
        {
            var childrenList = new List<JsonPropertyInfo>();
            var index = 0;

            foreach (var token in jArray)
            {
                var childContainer = new JsonPropertyInfo
                {
                    Name = index.ToString(),
                    Path = token.Path
                };

                switch (token)
                {
                    case JObject objectToken:
                        childContainer.Children = HandleJObject(objectToken);
                        break;
                    case JArray arrayToken:
                        childContainer.Children = HandleJArray(arrayToken);
                        break;
                    //Default is a primitive type which shall not have any children
                }

                childrenList.Add(childContainer);

                index++;
            }

            return childrenList;
        }
    }
}