﻿using System.Collections.Generic;
using System.Linq;
using JsonlCompare.Client.Interfaces;
using Newtonsoft.Json.Linq;

namespace JsonlCompare.Client.Services
{
    public class JsonDummyContainer : IJsonContainer
    {
        public JsonDummyContainer()
        {
            Jsons = JsonLinesDummy.Split("\n")
                .Select(JObject.Parse)
                .ToList();
        }

        public IReadOnlyList<JObject> Jsons { get; }
        public void Add(JObject json)
        {
        }

        public void Clear()
        {
        }

        public string JsonLinesDummy => "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Other task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"111111\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Very crazy\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"There\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Tough task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":null,\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"Operator\":\"mario\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":231,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Here\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":240,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}, \"ItemCounts\": [13, 14, 85, 93]}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Other task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"111111\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Very crazy\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"There\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Tough task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":null,\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"Operator\":\"mario\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":231,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Here\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":240,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}, \"ItemCounts\": [13, 14, 85, 93]}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Other task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"111111\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Very crazy\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"There\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Tough task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":null,\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"Operator\":\"mario\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":231,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Here\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":240,\"Location\":\"Somewhere\"}}\n{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n{\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"ViP\",\"CustomerId\":\"304960\"},\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}, \"ItemCounts\": [13, 14, 85, 93]}";
    }
    
    public class JsonContainer : IJsonContainer
    {
        private readonly List<JObject> jsons = new();

        public IReadOnlyList<JObject> Jsons => jsons;

        public void Add(JObject json)
        {
            jsons.Add(json);
        }

        public void Clear()
        {
            jsons.Clear();
        }
    }
}