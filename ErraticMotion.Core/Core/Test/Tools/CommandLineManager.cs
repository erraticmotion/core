// <copyright file="CommandLineManager.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.IO;

    using CommandLine.Parser;

    /// <summary>
    /// Manages command line argument mapping.
    /// </summary>
    public static class CommandLineManager
    {
        /// <summary>
        /// Gets the command line arguments.
        /// </summary>
        /// <typeparam name="T">The argument definition.</typeparam>
        /// <param name="args">The arguments from the console app.</param>
        /// <returns>A populated argument definition.</returns>
        public static T GetCommandLineArguments<T>(string[] args)
            where T : IArgumentDefinition, new()
        {
            var definition = new T();
            var mapManager = new ArgumentMapManager(definition);
            var parser = new Parser(mapManager);
            parser.ParseArguments(args);
            return definition;
        }

        /// <summary>
        /// Gets the command line arguments.
        /// </summary>
        /// <typeparam name="T">The argument definition.</typeparam>
        /// <param name="args">The arguments from the console app.</param>
        /// <param name="output">The output to be written to. Console.Out for example.</param>
        /// <returns>A populated argument definition.</returns>
        /// <remarks>Error handling is handled by method. Pass Console.Out to write error messages to console window.</remarks>
        public static T GetCommandLineArguments<T>(string[] args, TextWriter output)
            where T : IArgumentDefinition, new()
        {
            var definition = new T();
            var mapManager = new ArgumentMapManager(definition);
            var parser = new Parser(mapManager);
            try
            {
                parser.ParseArguments(args);
            }
            catch (InvalidArgumentException ex)
            {
                definition.SetInvalid();
                output.WriteLine(ex.Message);
            }

            return definition;
        }
    }
}
