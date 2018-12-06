﻿using MarkLogic.Client.DataService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public interface ITestService
    {
        Task<DateTime> returnDateTime(DateTime value);

        Task<string> returnMultipleAtomic(string value1, int value2, DateTime value3);

        Task<IEnumerable<int>> returnMultiValue(IEnumerable<int> values);

        Task returnNone();
    }

    public class TestService : DataServiceBase, ITestService
    {
        protected TestService(IDatabaseClient dbClient) : base(dbClient, "/test/")
        {
        }

        public static TestService Create(IDatabaseClient dbClient)
        {
            return new TestService(dbClient);
        }

        public Task<JArray> returnArray(JArray value)
        {
            return CreateRequest("returnArray.xqy")
                .WithParameters(
                    new SingleParameter<JArray>("value", false, value, Marshal.JsonArray))
                .RequestSingle<JArray>(false, Unmarshal.JsonArray);
        }

        public Task<DateTime> returnDateTime(DateTime value)
        {
            return CreateRequest("returnDateTime.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.DateTime))
                .RequestSingle<DateTime>(false, Unmarshal.DateTime);
        }

        public Task<JObject> returnObject(JObject value)
        {
            return CreateRequest("returnObject.xqy")
                .WithParameters(
                    new SingleParameter<JObject>("value", false, value, Marshal.JsonObject))
                .RequestSingle<JObject>(false, Unmarshal.JsonObject);
        }

        public Task<string> returnMultipleAtomic(string value1, int value2, DateTime value3)
        {
            return CreateRequest("returnMultipleAtomic.xqy")
                .WithParameters(
                    new SingleParameter<string>("value1", false, value1, Marshal.String),
                    new SingleParameter<int>("value2", false, value2, Marshal.Integer),
                    new SingleParameter<DateTime>("value3", false, value3, Marshal.DateTime))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        public Task<IEnumerable<int>> returnMultiValue(IEnumerable<int> values)
        {
            return CreateRequest("returnMultiValue.xqy")
                .WithParameters(
                    new MultipleParameter<int>("values", false, values, Marshal.Integer))
                .RequestMultiple<int>(false, Unmarshal.Integer);
        }

        public Task returnNone()
        {
            return CreateRequest("returnNone.xqy")
                .RequestNone();
        }
    }
}
