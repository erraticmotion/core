// <copyright file="ArgumentMap.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System.Reflection;

    internal class ArgumentMap
    {
        public ArgumentMap(PropertyInfo property, ArgumentAttribute attributes)
        {
            this.Attributes = attributes;
            this.Property = property;
        }

        public ArgumentAttribute Attributes { get; }

        public PropertyInfo Property { get; }
    }
}
