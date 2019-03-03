﻿using MarkLogic.Client.DataService.CodeGen;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices
{
    public class CodeGenTests
    {
        public CodeGenTests(ITestOutputHelper output)
        {
            Output = output;
        }

        private ITestOutputHelper Output { get; }

        public const string ValidEndpointDeclaration = @"
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

        [Fact]
        public void TestEndpointFromString()
        {
            var endpoint = Endpoint.FromString(ValidEndpointDeclaration);
            Assert.NotNull(endpoint);
            Assert.Equal("testEndpointName", endpoint.FunctionName);
            Assert.Equal(3, endpoint.Parameters.Count);
            Assert.NotNull(endpoint.ReturnValue);
            Assert.Equal("string", endpoint.ReturnValue.DataType);
        }

        public const string ValidServiceDeclaration = @"
        {
          ""endpointDirectory"": ""/path/to/endpoints/"",
          ""$javaClass"": ""com.mynamespace.MyService"",
          ""$netClass"": ""MyNamespace.MyService"",
          ""desc"": ""Service description.""
        }";

        [Fact]
        public void TestServiceFromString()
        {
            var service = Service.FromString(ValidServiceDeclaration);
            Assert.NotNull(service);
            Assert.Equal("/path/to/endpoints/", service.EndpointDirectory);
            Assert.Equal("com.mynamespace.MyService", service.JavaClass);
            Assert.Equal("MyNamespace.MyService", service.NetClass);
        }

        [Fact]
        public void TestServiceNames()
        {
            var service = Service.FromString(ValidServiceDeclaration);
            Assert.NotNull(service);
            Assert.Equal("MyService", service.ClassName);
            Assert.Equal("MyNamespace", service.Namespace);
            Assert.Equal(new[] { "MyNamespace", "MyService" }, service.ClassFullNameTokens);
        }

        public const string ValidServiceDeclarationNoNamespace = @"
        {
          ""endpointDirectory"": ""/path/to/endpoints/"",
          ""$netClass"": ""MyService"",
          ""desc"": ""Service description.""
        }";

        [Fact]
        public void TestServiceNameNoNamespace()
        {
            var service = Service.FromString(ValidServiceDeclarationNoNamespace);
            Assert.NotNull(service);
            Assert.Equal("MyService", service.ClassName);
            Assert.True(string.IsNullOrWhiteSpace(service.Namespace));
        }
    }
}
