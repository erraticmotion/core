// <copyright file="ArgumentDefinitionBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Acts as a base class for required and optional command line argument definitions.
    /// </summary>
    public abstract class ArgumentDefinitionBase : IArgumentDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentDefinitionBase"/> class.
        /// </summary>
        protected ArgumentDefinitionBase()
        {
            this.IsValid = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display usage syntax.
        /// </summary>
        /// <value>
        /// <c>true</c> if help; otherwise, <c>false</c>.
        /// </value>
        [Argument(ShortName = "?", LongName = "help", Description = "displays the syntax usage", Required = false)]
        public bool Help { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Gets the usage information for the console app.
        /// </summary>
        /// <value>Usage information.</value>
        public virtual string Usage
        {
            get
            {
                var mapManager = new ArgumentMapManager(this);
                var sb = new StringBuilder();
                sb.AppendLine(Environment.NewLine);
                sb.AppendLine("SYNTAX");
                sb.AppendLine(Environment.NewLine);
                foreach (var mapItem in mapManager.GetArgumentMap())
                {
                    sb.Append("    [-");
                    sb.Append(mapItem.Attributes.LongName);
                    sb.Append("(");
                    sb.Append(mapItem.Attributes.ShortName);
                    sb.Append("): <");
                    if (mapItem.Property.PropertyType.IsEnum)
                    {
                        var b = new StringBuilder();
                        var values = Enum.GetValues(mapItem.Property.PropertyType);
                        foreach (var value in values)
                        {
                            b.Append(value + ", ");
                        }

                        sb.Append(b.ToString().TrimEnd(',', ' '));
                    }
                    else
                    {
                        sb.Append(mapItem.Property.PropertyType.Name.ToLowerInvariant());
                    }

                    sb.Append(">]");

                    if (!string.IsNullOrWhiteSpace(mapItem.Attributes.Description))
                    {
                        sb.AppendLine();
                        sb.Append("      ");
                        sb.Append(mapItem.Attributes.Description);
                        sb.AppendLine(Environment.NewLine);
                    }
                }

                if (this.SampleUsage().Any())
                {
                    sb.AppendLine("SAMPLE USAGE");
                    sb.AppendLine(Environment.NewLine);
                    foreach (var usage in this.SampleUsage())
                    {
                        sb.AppendLine(usage);
                        sb.AppendLine(Environment.NewLine);
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Sets the argument definition to be in an invalid state.
        /// </summary>
        public void SetInvalid()
        {
            this.IsValid = false;
        }

        /// <summary>
        /// Extension point for sub-classes to provide a 
        /// collection of usage examples for this command line.
        /// </summary>
        /// <returns>
        /// A collection of samples that demonstrate 
        /// the usage of the command line.
        /// </returns>
        public virtual IEnumerable<string> SampleUsage()
        {
            return new string[0];
        }
    }
}
