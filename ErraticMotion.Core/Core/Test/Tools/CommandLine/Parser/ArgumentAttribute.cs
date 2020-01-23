// <copyright file="ArgumentAttribute.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System;

    /// <summary>
    /// Required attribute to decorate derived type of <see cref="ArgumentDefinitionBase"/> to specify
    /// the arguments that are either required or optional in the command line.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ArgumentAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ArgumentAttribute"/> is required.
        /// </summary>
        public bool Required { get; set; }
    }
}
