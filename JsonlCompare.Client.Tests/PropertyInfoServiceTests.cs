using System.Collections.Generic;
using System.Linq;
using DeepEqual.Syntax;
using JsonlCompare.Client.Interfaces;
using JsonlCompare.Client.Models;
using JsonlCompare.Client.Services;
using Moq;
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
            var jsonContainerMock = new Mock<IJsonContainer>();
            var sut = new PropertyInfoService(jsonContainerMock.Object);

            jsonContainerMock
                .Setup(x => x.Jsons)
                .Returns(new List<JObject>
                {
                    JObject.Parse(
                        "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":false,\"ToDo\":\"Very crazy\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}"),
                    JObject.Parse(
                        "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\"}}\n"),
                    JObject.Parse(
                        "{\"PseudoOrderNumber\":\"d895e88000f04bc1a96130b9e8a08ec6\",\"DateOfOrder\":\"2021-05-27T22:00:00Z\",\"IsInternal\":true,\"ToDo\":\"Some very fine task\",\"MailAddress\":\"someone@mail.com\",\"Operator\":\"operator\",\"Machine\":{\"SerialNumber\":\"0066P00163\",\"OperatingHours\":120,\"Location\":\"Somewhere\",\"Customer\":{\"Name\":\"Someone\",\"CustomerId\":\"304960\"}}}\n")
                });

            // Act
            var result = sut.GetPropertyContainer().ToList();

            //Assert
            var template = new[]
            {
                new JsonPropertyContainer
                {
                    Name = "PseudoOrderNumber"
                },
                new JsonPropertyContainer
                {
                    Name = "DateOfOrder"
                },
                new JsonPropertyContainer
                {
                    Name = "IsInternal"
                },
                new JsonPropertyContainer
                {
                    Name = "ToDo"
                },
                new JsonPropertyContainer
                {
                    Name = "MailAddress"
                },
                new JsonPropertyContainer
                {
                    Name = "Operator"
                },
                new JsonPropertyContainer
                {
                    Name = "Customer",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "Name"
                        },
                        new JsonPropertyContainer
                        {
                            Name = "CustomerId"
                        }
                    }
                },
                new JsonPropertyContainer
                {
                    Name = "Machine",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "SerialNumber"
                        },
                        new JsonPropertyContainer
                        {
                            Name = "OperatingHours"
                        },
                        new JsonPropertyContainer
                        {
                            Name = "Location"
                        },
                        new JsonPropertyContainer
                        {
                            Name = "Customer",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "Name"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "CustomerId"
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
            var jsonContainerMock = new Mock<IJsonContainer>();
            var sut = new PropertyInfoService(jsonContainerMock.Object);

            jsonContainerMock
                .Setup(x => x.Jsons)
                .Returns(new List<JObject>
                {
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"Customers\": [\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\"\n\t    }\n\t]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"Customers\": [\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\"\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": null\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304961\"\n\t    }\n\t]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"Customers\": [\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\"\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": null\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\",\n\t        \"MoreProperties\": true\n\t    },\n\t    {\n\t        \"Name\": \"Someone\",\n\t        \"CustomerId\": \"304960\",\n\t        \"MoreProperties\": true,\n\t        \"AnotherProperty\": \"TestProperty\"\n\t    }\n\t]\n}")
                });

            // Act
            var result = sut.GetPropertyContainer().ToList();

            //Assert
            var template = new[]
            {
                new JsonPropertyContainer
                {
                    Name = "PseudoOrderNumber"
                },
                new JsonPropertyContainer
                {
                    Name = "Customers",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "0",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "Name"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "CustomerId"
                                }
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "1",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "Name"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "CustomerId"
                                }
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "2",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "Name"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "CustomerId"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "MoreProperties"
                                }
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "3",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "Name"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "CustomerId"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "MoreProperties"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "AnotherProperty"
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
            var jsonContainerMock = new Mock<IJsonContainer>();
            var sut = new PropertyInfoService(jsonContainerMock.Object);

            jsonContainerMock
                .Setup(x => x.Jsons)
                .Returns(new List<JObject>
                {
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerIds\": [\n\t    4,\n\t    7,\n\t    15,\n\t    48,\n\t    53,\n\t    1\n\t],\n\t\"CustomerNames\": [\n\t\t\"First\",\n\t\t\"Important\",\n\t\t\"Valuable\"\n\t]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerIds\": [\n\t    4,\n\t    7,\n\t    1\n\t],\n\t\"CustomerNames\": [\n\t\t\"Second\",\n\t]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerIds\": [\n\t    4,\n\t    7,\n\t    15,\n\t    48,\n\t    53,\n\t    1,\n\t    234,\n\t    35,\n\t    74\n\t],\n\t\"CustomerNames\": [\n\t\t\"First\",\n\t\t\"Important\",\n\t\t\"Valuable\",\n\t\t\"Others\",\n\t\t\"More\"\n\t]\n}")
                });

            // Act
            var result = sut.GetPropertyContainer().ToList();

            //Assert
            var template = new[]
            {
                new JsonPropertyContainer
                {
                    Name = "PseudoOrderNumber"
                },
                new JsonPropertyContainer
                {
                    Name = "CustomerIds",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "0"
                        },
                        new JsonPropertyContainer
                        {
                            Name = "1",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "2",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "3",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "4",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "5",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "6",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "7",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "8",
                        }
                    }
                },
                new JsonPropertyContainer
                {
                    Name = "CustomerNames",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "0"
                        },
                        new JsonPropertyContainer
                        {
                            Name = "1",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "2",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "3",
                        },
                        new JsonPropertyContainer
                        {
                            Name = "4",
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
            var jsonContainerMock = new Mock<IJsonContainer>();
            var sut = new PropertyInfoService(jsonContainerMock.Object);

            jsonContainerMock
                .Setup(x => x.Jsons)
                .Returns(new List<JObject>
                {
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[\"First\", \"Second\", \"Third\"],\n    \t[\"Fourth\", \"Five\", \"Six\"]\n    ]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[\"First\", \"Second\", \"Third\"],\n    \t[\"Fourth\", \"Five\", \"Six\"],\n    \t[\"Seven\", \"Eight\", \"Nine\"]\n    ]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[\"First\", \"Second\", \"Third\", \"Ten\", \"Eleven\"]\n    ]\n}")
                });

            // Act
            var result = sut.GetPropertyContainer().ToList();

            //Assert
            var template = new[]
            {
                new JsonPropertyContainer
                {
                    Name = "PseudoOrderNumber"
                },
                new JsonPropertyContainer
                {
                    Name = "CustomerArrays",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "0",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "0"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "1"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "2"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "3"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "4"
                                }
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "1",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "0"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "1"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "2"
                                }
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "2",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "0"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "1"
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "2"
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
            var jsonContainerMock = new Mock<IJsonContainer>();
            var sut = new PropertyInfoService(jsonContainerMock.Object);

            jsonContainerMock
                .Setup(x => x.Jsons)
                .Returns(new List<JObject>
                {
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[{\"Name\" : \"First\", \"Id\": 12}, {\"Name\" : \"Second\", \"Id\": 13}],\n    \t[{\"Name\" : \"Thirs\", \"Id\": 14}, {\"Name\" : \"Fourth\", \"Id\": 15}],\n    ]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[{\"Name\" : \"First\", \"Id\": 12}, {\"Name\" : \"Second\", \"Id\": 13}],\n    \t[{\"Name\" : \"Third\", \"Id\": 14}, {\"Name\" : \"Fourth\", \"Id\": 15}],\n    \t[{\"Name\" : \"Fivth\", \"Id\": 16}, {\"Name\" : \"Sixth\", \"Id\": 17}],\n    ]\n}"),
                    JObject.Parse(
                        "{\n    \"PseudoOrderNumber\": \"d895e88000f04bc1a96130b9e8a08ec6\",\n    \"CustomerArrays\": [\n    \t[{\"Name\" : \"First\", \"Id\": 12}, {\"Name\" : \"Second\", \"Id\": 13}, {\"Name\": \"Tenth\", \"Id\": 23}]\n    ]\n}")
                });

            // Act
            var result = sut.GetPropertyContainer().ToList();

            //Assert
            var template = new[]
            {
                new JsonPropertyContainer
                {
                    Name = "PseudoOrderNumber"
                },
                new JsonPropertyContainer
                {
                    Name = "CustomerArrays",
                    Children = new[]
                    {
                        new JsonPropertyContainer
                        {
                            Name = "0",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "0",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "1",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "2",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "1",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "0",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "1",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                            }
                        },
                        new JsonPropertyContainer
                        {
                            Name = "2",
                            Children = new[]
                            {
                                new JsonPropertyContainer
                                {
                                    Name = "0",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                                new JsonPropertyContainer
                                {
                                    Name = "1",
                                    Children = new []
                                    {
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Name"
                                        },
                                        new JsonPropertyContainer()
                                        {
                                            Name = "Id"
                                        }
                                    }
                                },
                            }
                        }
                    }
                }
            };

            result.ShouldDeepEqual(template);
        }
    }
}