// <copyright file="NameValueArgument.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System.Globalization;

    internal class NameValueArgument
    {
        public static NameValueArgument Parse(string value)
        {
            string argument;
            if (value.StartsWith("/", true, CultureInfo.CurrentCulture) 
                || value.StartsWith("-", true, CultureInfo.CurrentCulture))
            {
                argument = value.Substring(1, value.Length - 1);
            }
            else
            {
                throw new InvalidArgumentException(value);
            }

            var result = new NameValueArgument();
            var vals = argument.Split(':');
            for (var i = 0; i < vals.Length; i++)
            {
                if (i == 0)
                {
                    result.Name = vals[i];
                }
                else
                {
                    result.Value += vals[i];
                    if (i < vals.Length - 1)
                    {
                        result.Value += ":";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(result.Value))
            {
                result.Value = result.Value.Trim('"');
            }

            return result;
        }

        private NameValueArgument()
        {
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}-{1}", this.Name, this.Value);
        }
    }
}
