// <copyright file="IArgumentDefinition.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    /// <summary>
    /// Specifies the console applications argument properties and methods.
    /// </summary>
    public interface IArgumentDefinition
    {
        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        bool IsValid { get; }

        /// <summary>
        /// Gets the usage information for the console app.
        /// </summary>
        /// <value>Usage information.</value>
        string Usage { get; }

        /// <summary>
        /// Sets the argument definition to be in an invalid state.
        /// </summary>
        void SetInvalid();
    }
}
