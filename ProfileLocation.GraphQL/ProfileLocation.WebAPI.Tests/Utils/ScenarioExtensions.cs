// <copyright file="ScenarioExtensions.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using Alba;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileLocation.WebAPI.Tests
{
    public static class ScenarioExtensions
    {
        public static GraphQLExpectations GraphQL(this Scenario scenario)
        {
            return new GraphQLExpectations(scenario);
        }
    }
}
