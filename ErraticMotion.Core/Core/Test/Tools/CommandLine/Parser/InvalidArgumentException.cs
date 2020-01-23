// <copyright file="InvalidArgumentException.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.CommandLine.Parser
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Contains data indicating that an invalid argument has been supplied to the console application.
    /// </summary>
    [Serializable]
    public sealed class InvalidArgumentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArgumentException"/> class.
        /// </summary>
        public InvalidArgumentException()
            : base("Invalid argument")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidArgumentException(string message)
            : base(string.Format(CultureInfo.CurrentCulture, "Invalid argument: {0}", message))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArgumentException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null
        /// reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public InvalidArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private InvalidArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
