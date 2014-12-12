﻿namespace Text
{
    /// <summary>Provides the interface for types that provide contextual information about their source data.</summary>
    public interface ITextContext
    {
        /// <summary>Gets the current position, relative to the beginning of the data source.</summary>
        int Offset { get; }
    }
}