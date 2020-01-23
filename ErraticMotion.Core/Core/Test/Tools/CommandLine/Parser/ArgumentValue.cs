// <copyright file="ArgumentValue.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System;
    using System.Globalization;

    internal class ArgumentValue
    {
        public static object Parse(Type type, string value)
        {
            var message = new Lazy<string>(() =>
                string.Format(CultureInfo.CurrentCulture, "Failed to recognise type {0} supplied as a string with value of {1}", type.Name, value));

            if (type.IsEnum)
            {
                try
                {
                    return Enum.Parse(type, value);
                }
                catch (Exception ex)
                {
                    throw new InvalidArgumentException(message.Value, ex);
                }
            }

            try
            {
                return type == typeof(bool)
                    ? ParseBool(value)
                    : Convert.ChangeType(value, type, CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                throw new InvalidArgumentException(message.Value, ex);
            }
        }

        public static T Parse<T>(string value)
        {
            return Parse(typeof(T), value) is T
                ? (T)Parse(typeof(T), value)
                : default(T);
        }

        private static bool ParseBool(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            bool b;
            if (bool.TryParse(value, out b))
            {
                return b;
            }

            var i = Convert.ToInt32(value, CultureInfo.CurrentCulture);
            if (i < 0 || i > 1)
            {
                throw new FormatException("Invalid Boolean type. Must be 0 or 1.");
            }

            return Convert.ToBoolean(i);
        }
    }
}
