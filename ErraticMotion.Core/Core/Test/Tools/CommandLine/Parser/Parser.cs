// <copyright file="Parser.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System.Globalization;
    using System.Linq;

    internal class Parser
    {
        private readonly ArgumentMapManager mapManager;

        public Parser(ArgumentMapManager mapManager)
        {
            this.mapManager = mapManager;
        }

        public void ParseArguments(string[] args)
        {
            var map = this.mapManager.GetArgumentMap();
            var argumentDefinitionClassName = this.mapManager.ArgumentDefinition.GetType().Name;
            if (map.Count == 0)
            {
                throw new InvalidArgumentException(string.Format(
                    CultureInfo.CurrentCulture,
                    "No arguments were defined in {0}",
                    argumentDefinitionClassName));
            }

            var requiredList = map.Where(m => m.Attributes.Required)
                .Select(s => s.Attributes.LongName).ToList();

            foreach (var arg in args)
            {
                var argument = NameValueArgument.Parse(arg);
                var mapItem = map.FirstOrDefault(a =>
                    0 == string.Compare(a.Attributes.LongName, argument.Name, true, CultureInfo.CurrentCulture))
                    ?? map.FirstOrDefault(a => 
                        0 == string.Compare(a.Attributes.ShortName, argument.Name, true, CultureInfo.CurrentCulture));

                if (mapItem == null)
                {
                    throw new InvalidArgumentException(string.Format(
                        CultureInfo.CurrentCulture, 
                        "Argument '{0}' not defined in definition class {1}",
                        argument.Name, 
                        argumentDefinitionClassName));
                }

                requiredList.Remove(mapItem.Attributes.LongName);
                SetValue(mapItem, argument, this.mapManager.ArgumentDefinition);
            }

            if (requiredList.Count > 0)
            {
                throw new InvalidArgumentException(string.Format(
                    CultureInfo.CurrentCulture,
                    "Required arguments not specified: {0}", 
                    string.Join(", ", requiredList.ToArray())));
            }
        }

        private static void SetValue(ArgumentMap map, NameValueArgument argument, IArgumentDefinition arguments)
        {
            var property = map.Property;
            var type = property.PropertyType;
            if (property.Name == "Help")
            {
                property.SetValue(arguments, true, null);
            }
            else
            {
                property.SetValue(arguments, ArgumentValue.Parse(type, argument.Value.ToString(CultureInfo.CurrentCulture)), null);
            }
        }
    }
}
