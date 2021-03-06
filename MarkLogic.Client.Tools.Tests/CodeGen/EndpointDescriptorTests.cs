﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tools.Tests.CodeGen
{
    public class EndpointDescriptorTests
    {
        public EndpointDescriptorTests(ITestOutputHelper output)
        {
            Output = output;
        }

        private ITestOutputHelper Output { get; }

        public const string ValidEndpointDescriptor = @"
        {
          ""functionName"": ""testEndpointName"",
          ""desc"": ""The endpoint's declaration."",
          ""params"": [{
            ""name"": ""value1"",
            ""desc"": ""The first parameter."",
            ""datatype"": ""string"",
            ""nullable"": false,
            ""multiple"": false
          }, {
            ""name"": ""value2"",
            ""datatype"": ""int"",
            ""multiple"": true,
            ""nullable"": false
          }, {
            ""name"": ""value3"",
            ""datatype"": ""dateTime"",
            ""nullable"": true,
            ""$javaClass"": ""java.time.LocalDateTime""
          }],
          ""return"": {
            ""datatype"": ""string"",
            ""desc"": ""The return value."",
            ""nullable"": false,
            ""multiple"": false
          },
          ""errorDetail"": ""return""
        }";

        public const string EndpointDescriptorWithSession = @"
        {
          ""functionName"": ""testEndpointWithSession"",
          ""desc"": ""The endpoint's declaration."",
          ""params"": [{
            ""name"": ""value1"",
            ""desc"": ""The first parameter."",
            ""datatype"": ""string"",
            ""nullable"": false,
            ""multiple"": false
          }, {
            ""name"": ""value2"",
            ""datatype"": ""int"",
            ""multiple"": true,
            ""nullable"": false
          }, {
            ""name"": ""session"",
            ""datatype"": ""session"",
            ""nullable"": true
          }],
          ""return"": {
            ""datatype"": ""string"",
            ""desc"": ""The return value."",
            ""nullable"": false,
            ""multiple"": false
          },
          ""errorDetail"": ""return""
        }";

        public static IEnumerable<object[]> EndpointDescriptorData()
        {
            return new[]
            {
                new object[] { ValidEndpointDescriptor, "testEndpointName", ModuleType.XQuery, 3, true, false, false },
                new object[] { EndpointDescriptorWithSession, "testEndpointWithSession", ModuleType.XQuery, 3, true, true, true },
                new object[] { ValidEndpointDescriptor, "testEndpointName", ModuleType.SJS, 3, true, false, false },
                new object[] { EndpointDescriptorWithSession, "testEndpointWithSession", ModuleType.SJS, 3, true, true, true }
            };
        }

        [Theory]
        [MemberData(nameof(EndpointDescriptorData))]
        public void EndpointFromString(string endpointDesc, string expectedName, ModuleType moduleType, int expectedParamCount, bool hasReturnValue, bool hasSession, bool nullableSession)
        {
            var endpoint = EndpointDescriptor.FromString(endpointDesc, moduleType);
            Assert.NotNull(endpoint);
            Assert.Equal(expectedName, endpoint.FunctionName);

            string moduleName = expectedName + "." + (moduleType == ModuleType.SJS ? "sjs" : "xqy");
            Assert.Equal(moduleName, endpoint.ModuleName);

            Assert.Equal(expectedParamCount, endpoint.Parameters.Count);
            if (hasReturnValue)
            {
                Assert.NotNull(endpoint.ReturnValue);
            }
            else
            {
                Assert.Null(endpoint.ReturnValue);
            }
            Assert.Equal(hasSession, endpoint.HasSession);
            if (hasSession)
            {
                Assert.Equal(nullableSession, endpoint.Session.Nullable);
                Assert.Null(endpoint.ParametersNoSession.FirstOrDefault(p => p.DataType.EqualsIgnoreCase("session")));
            }
        }
    }
}
