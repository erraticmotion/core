// <copyright file="ArgumentMapManager.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ArgumentMapManager
    {
        public ArgumentMapManager(IArgumentDefinition argumentDefinition)
        {
            this.ArgumentDefinition = argumentDefinition;
        }

        public IArgumentDefinition ArgumentDefinition { get; }

        public List<ArgumentMap> GetArgumentMap()
        {
            var info = this.ArgumentDefinition.GetType().GetProperties();
            return (from property in info
                    let attrib = (ArgumentAttribute)Attribute.GetCustomAttribute(property, typeof(ArgumentAttribute), false)
                    where attrib != null
                    select new ArgumentMap(property, attrib)).ToList();
        }
    }
}
