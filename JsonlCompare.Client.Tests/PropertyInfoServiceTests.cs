using System.Collections.Generic;
using DeepEqual.Syntax;
using JsonlCompare.Client.Models;
using JsonlCompare.Client.Services;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace JsonlCompare.Client.Tests
{
    [TestFixture]
    public class PropertyInfoServiceTests
    {
        [Test]
        public void GetPropertyContainer_NestedObjects_MergeAndReturnContainer()
        {
            // Arrange
            var jsons = new List<JObject>
            {
                JObject.Parse(
                    "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Very crazy\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}"),
                JObject.Parse(
                    "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n"),
                JObject.Parse(
                    "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}}\n")
            };

            // Act
            var result = PropertyInfoService.PropertyInfos(jsons);

            //Assert
            var template = new[]
            {
                new JsonPropertyInfo
                {
                    Name = "PseudoOrderNumber",
                    Path = "PseudoOrderNumber"
                },
                new JsonPropertyInfo
                {
                    Name = "DateOfOrder",
                    Path = "DateOfOrder"
                },
                new JsonPropertyInfo
                {
                    Name = "IsInternal",
                    Path = "IsInternal"
                },
                new JsonPropertyInfo
                {
                    Name = "ToDo",
                    Path = "ToDo"
                },
                new JsonPropertyInfo
                {
                    Name = "MailAddress",
                    Path = "MailAddress"
                },
                new JsonPropertyInfo
                {
                    Name = "Operator",
                    Path = "Operator"
                },
                new JsonPropertyInfo
                {
                    Name = "Customer",
                    Path = "Customer",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "Name",
                            Path = "Customer.Name"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "CustomerId",
                            Path = "Customer.CustomerId"
                        }
                    }
                },
                new JsonPropertyInfo
                {
                    Name = "Machine",
                    Path = "Machine",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "SerialNumber",
                            Path = "Machine.SerialNumber"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "OperatingHours",
                            Path = "Machine.OperatingHours"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "Location",
                            Path = "Machine.Location"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "Customer",
                            Path = "Machine.Customer",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "Name",
                                    Path = "Machine.Customer.Name"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "CustomerId",
                                    Path = "Machine.Customer.CustomerId"
                                }
                            }
                        }
                    }
                }
            };

            result.ShouldDeepEqual(template);
        }

        [Test]
        public void GetPropertyContainer_ArraysWithObjects_MergeAndReturnContainer()
        {
            // Arrange
            var jsons = new List<JObject>
            {
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"Customers\": [\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\"\n\t    }\n\t]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"Customers\": [\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\"\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": null\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304961\"\n\t    }\n\t]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"Customers\": [\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\"\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": null\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\",\n\t        \"MoreProperties\": true\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\",\n\t        \"MoreProperties\": true,\n\t        \"AnotherProperty\": \"TestProperty\"\n\t    }\n\t]\n}")
            };

            // Act
            var result = PropertyInfoService.PropertyInfos(jsons);

            //Assert
            var template = new[]
            {
                new JsonPropertyInfo
                {
                    Name = "PseudoOrderNumber",
                    Path = "PseudoOrderNumber"
                },
                new JsonPropertyInfo
                {
                    Name = "Customers",
                    Path = "Customers",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "0",
                            Path = "Customers[0]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "Name",
                                    Path = "Customers[0].Name"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "CustomerId",
                                    Path = "Customers[0].CustomerId"
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "1",
                            Path = "Customers[1]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "Name",
                                    Path = "Customers[1].Name"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "CustomerId",
                                    Path = "Customers[1].CustomerId"
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "2",
                            Path = "Customers[2]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "Name",
                                    Path = "Customers[2].Name"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "CustomerId",
                                    Path = "Customers[2].CustomerId"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "MoreProperties",
                                    Path = "Customers[2].MoreProperties"
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "3",
                            Path = "Customers[3]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "Name",
                                    Path = "Customers[3].Name"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "CustomerId",
                                    Path = "Customers[3].CustomerId"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "MoreProperties",
                                    Path = "Customers[3].MoreProperties"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "AnotherProperty",
                                    Path = "Customers[3].AnotherProperty"
                                }
                            }
                        }
                    }
                }
            };

            result.ShouldDeepEqual(template);
        }

        [Test]
        public void GetPropertyContainer_ArraysWithPrimitives_MergeAndReturnContainer()
        {
            // Arrange
            var jsons = new List<JObject>
            {
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerIds\": [\n\t    4,\n\t    7,\n\t    15,\n\t    48,\n\t    53,\n\t    1\n\t],\n\t\"CustomerNames\": [\n\t\t\"First\",\n\t\t\"Important\",\n\t\t\"Valuable\"\n\t]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerIds\": [\n\t    4,\n\t    7,\n\t    1\n\t],\n\t\"CustomerNames\": [\n\t\t\"Second\",\n\t]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerIds\": [\n\t    4,\n\t    7,\n\t    15,\n\t    48,\n\t    53,\n\t    1,\n\t    234,\n\t    35,\n\t    74\n\t],\n\t\"CustomerNames\": [\n\t\t\"First\",\n\t\t\"Important\",\n\t\t\"Valuable\",\n\t\t\"Others\",\n\t\t\"More\"\n\t]\n}")
            };

            // Act
            var result = PropertyInfoService.PropertyInfos(jsons);

            //Assert
            var template = new[]
            {
                new JsonPropertyInfo
                {
                    Name = "PseudoOrderNumber",
                    Path = "PseudoOrderNumber"
                },
                new JsonPropertyInfo
                {
                    Name = "CustomerIds",
                    Path = "CustomerIds",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "0",
                            Path = "CustomerIds[0]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "1",
                            Path = "CustomerIds[1]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "2",
                            Path = "CustomerIds[2]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "3",
                            Path = "CustomerIds[3]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "4",
                            Path = "CustomerIds[4]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "5",
                            Path = "CustomerIds[5]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "6",
                            Path = "CustomerIds[6]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "7",
                            Path = "CustomerIds[7]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "8",
                            Path = "CustomerIds[8]"
                        }
                    }
                },
                new JsonPropertyInfo
                {
                    Name = "CustomerNames",
                    Path = "CustomerNames",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "0",
                            Path = "CustomerNames[0]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "1",
                            Path = "CustomerNames[1]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "2",
                            Path = "CustomerNames[2]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "3",
                            Path = "CustomerNames[3]"
                        },
                        new JsonPropertyInfo
                        {
                            Name = "4",
                            Path = "CustomerNames[4]"
                        }
                    }
                }
            };

            result.ShouldDeepEqual(template);
        }

        [Test]
        public void GetPropertyContainer_ArraysWithArraysOfPrimitives_MergeAndReturnContainer()
        {
            // Arrange
            var jsons = new List<JObject>
            {
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[\"First\", \"Second\", \"Third\"],\n    \t[\"Fourth\", \"Five\", \"Six\"]\n    ]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[\"First\", \"Second\", \"Third\"],\n    \t[\"Fourth\", \"Five\", \"Six\"],\n    \t[\"Seven\", \"Eight\", \"Nine\"]\n    ]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[\"First\", \"Second\", \"Third\", \"Ten\", \"Eleven\"]\n    ]\n}")
            };

            // Act
            var result = PropertyInfoService.PropertyInfos(jsons);

            //Assert
            var template = new[]
            {
                new JsonPropertyInfo
                {
                    Name = "PseudoOrderNumber",
                    Path = "PseudoOrderNumber"
                },
                new JsonPropertyInfo
                {
                    Name = "CustomerArrays",
                    Path = "CustomerArrays",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "0",
                            Path = "CustomerArrays[0]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "0",
                                    Path = "CustomerArrays[0][0]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "1",
                                    Path = "CustomerArrays[0][1]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "2",
                                    Path = "CustomerArrays[0][2]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "3",
                                    Path = "CustomerArrays[0][3]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "4",
                                    Path = "CustomerArrays[0][4]"
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "1",
                            Path = "CustomerArrays[1]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "0",
                                    Path = "CustomerArrays[1][0]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "1",
                                    Path = "CustomerArrays[1][1]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "2",
                                    Path = "CustomerArrays[1][2]"
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "2",
                            Path = "CustomerArrays[2]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "0",
                                    Path = "CustomerArrays[2][0]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "1",
                                    Path = "CustomerArrays[2][1]"
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "2",
                                    Path = "CustomerArrays[2][2]"
                                }
                            }
                        }
                    }
                }
            };

            result.ShouldDeepEqual(template);
        }

        [Test]
        public void GetPropertyContainer_ArraysWithArraysOfObjects_MergeAndReturnContainer()
        {
            // Arrange
            var jsons = new List<JObject>
            {
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[{\"Name\" : \"First\", \"Id\": 12}, {\"Name\" : \"Second\", \"Id\": 13}],\n    \t[{\"Name\" : \"Thirs\", \"Id\": 14}, {\"Name\" : \"Fourth\", \"Id\": 15}],\n    ]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[{\"Name\" : \"First\", \"Id\": 12}, {\"Name\" : \"Second\", \"Id\": 13}],\n    \t[{\"Name\" : \"Third\", \"Id\": 14}, {\"Name\" : \"Fourth\", \"Id\": 15}],\n    \t[{\"Name\" : \"Fifth\", \"Id\": 16}, {\"Name\" : \"Sixth\", \"Id\": 17}],\n    ]\n}"),
                JObject.Parse(
                    "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[{\"Name\" : \"First\", \"Id\": 12}, {\"Name\" : \"Second\", \"Id\": 13}, {\"Name\": \"Tenth\", \"Id\": 23}]\n    ]\n}")
            };

            // Act
            var result = PropertyInfoService.PropertyInfos(jsons);

            //Assert
            var template = new[]
            {
                new JsonPropertyInfo
                {
                    Name = "PseudoOrderNumber",
                    Path = "PseudoOrderNumber"
                },
                new JsonPropertyInfo
                {
                    Name = "CustomerArrays",
                    Path = "CustomerArrays",
                    Children = new[]
                    {
                        new JsonPropertyInfo
                        {
                            Name = "0",
                            Path = "CustomerArrays[0]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "0",
                                    Path = "CustomerArrays[0][0]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[0][0].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[0][0].Id"
                                        }
                                    }
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "1",
                                    Path = "CustomerArrays[0][1]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[0][1].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[0][1].Id"
                                        }
                                    }
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "2",
                                    Path = "CustomerArrays[0][2]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[0][2].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[0][2].Id"
                                        }
                                    }
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "1",
                            Path = "CustomerArrays[1]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "0",
                                    Path = "CustomerArrays[1][0]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[1][0].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[1][0].Id"
                                        }
                                    }
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "1",
                                    Path = "CustomerArrays[1][1]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[1][1].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[1][1].Id"
                                        }
                                    }
                                }
                            }
                        },
                        new JsonPropertyInfo
                        {
                            Name = "2",
                            Path = "CustomerArrays[2]",
                            Children = new[]
                            {
                                new JsonPropertyInfo
                                {
                                    Name = "0",
                                    Path = "CustomerArrays[2][0]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[2][0].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[2][0].Id"
                                        }
                                    }
                                },
                                new JsonPropertyInfo
                                {
                                    Name = "1",
                                    Path = "CustomerArrays[2][1]",
                                    Children = new[]
                                    {
                                        new JsonPropertyInfo
                                        {
                                            Name = "Name",
                                            Path = "CustomerArrays[2][1].Name"
                                        },
                                        new JsonPropertyInfo
                                        {
                                            Name = "Id",
                                            Path = "CustomerArrays[2][1].Id"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            result.ShouldDeepEqual(template);
        }
    }
}