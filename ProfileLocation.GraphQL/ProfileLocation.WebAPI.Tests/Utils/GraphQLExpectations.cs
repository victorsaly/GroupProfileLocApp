// <copyright file="GraphQLExpectations.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using Alba;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileLocation.WebAPI.Tests
{
    public class GraphQLExpectations
    {
        private readonly Scenario _scenario;

        public GraphQLExpectations(Scenario scenario)
        {
            _scenario = scenario;
        }

        public GraphQLExpectations ShouldBeSuccess(string result, bool ignoreExtensions = true)
        {
            _scenario.AssertThat(new SuccessResultAssertion(result, ignoreExtensions));
            return this;
        }
    }
}
