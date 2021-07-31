﻿using System;
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

        public IEnumerable<JsonPropertyContainer> GetPropertyContainer()
        {
            var jsons = jsonContainer.Jsons;

            var maxJson = CombineJsons(jsons);

            return HandleJObject(maxJson);
        }

        private JObject CombineJsons(IReadOnlyList<JObject> jsons)
        {
            var maxJson = jsons.First();

            foreach (var json in jsons.Skip(1))
            {
                maxJson.Merge(json, new JsonMergeSettings()
                {
                    MergeArrayHandling = MergeArrayHandling.Merge,
                    PropertyNameComparison = StringComparison.InvariantCultureIgnoreCase,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore
                });
            }

            return maxJson;
        }

        private IReadOnlyList<JsonPropertyContainer> HandleJObject(JObject json)
        {
            var jsonProperties = new List<JsonPropertyContainer>();
            
            foreach (var property in json.Children())
            {
                jsonProperties.Add(HandleJToken(property));
            }

            return jsonProperties;
        }

        private JsonPropertyContainer HandleJToken(JToken jToken)
        {
            var jsonProperty = new JsonPropertyContainer();

            var prop = jToken as JProperty;

            switch (prop.Value)
            {
                case JObject jObject:
                    jsonProperty.Name = jToken.Path.Split(".").Last();
                    jsonProperty.Children = HandleJObject(jObject);
                    break;
                case JArray jArray:
                    jsonProperty.Name = jToken.Path.Split(".").Last();
                    jsonProperty.Children = HandleJArray(jArray);
                    break;
                default:
                    jsonProperty.Name = jToken.Path.Split(".").Last();
                    break;
            }

            return jsonProperty;
        }

        private List<JsonPropertyContainer> HandleJArray(JArray jArray)
        {
            var childrenList = new List<JsonPropertyContainer>();
            var index = 0;
            foreach (var token in jArray)
            {
                var childContainer = new JsonPropertyContainer() {Name = index.ToString()};
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