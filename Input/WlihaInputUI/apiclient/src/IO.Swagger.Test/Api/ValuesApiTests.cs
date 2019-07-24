/* 
 * My API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing ValuesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ValuesApiTests
    {
        private ValuesApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ValuesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ValuesApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' ValuesApi
            //Assert.IsInstanceOfType(typeof(ValuesApi), instance, "instance is a ValuesApi");
        }

        /// <summary>
        /// Test ApiValuesGet
        /// </summary>
        [Test]
        public void ApiValuesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ApiValuesGet();
            //Assert.IsInstanceOf<List<string>> (response, "response is List<string>");
        }
        /// <summary>
        /// Test ApiValuesIdDelete
        /// </summary>
        [Test]
        public void ApiValuesIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //instance.ApiValuesIdDelete(id);
            
        }
        /// <summary>
        /// Test ApiValuesIdGet
        /// </summary>
        [Test]
        public void ApiValuesIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //var response = instance.ApiValuesIdGet(id);
            //Assert.IsInstanceOf<string> (response, "response is string");
        }
        /// <summary>
        /// Test ApiValuesIdPut
        /// </summary>
        [Test]
        public void ApiValuesIdPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //string body = null;
            //instance.ApiValuesIdPut(id, body);
            
        }
        /// <summary>
        /// Test ApiValuesPost
        /// </summary>
        [Test]
        public void ApiValuesPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string body = null;
            //instance.ApiValuesPost(body);
            
        }
    }

}
