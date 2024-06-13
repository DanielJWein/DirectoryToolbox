using System;
using System.Collections.Generic;

namespace Directory_Toolbox;

/// <summary>
/// Holds parameters related to script execution
/// </summary>
public readonly struct ScriptExecutionParams : IEquatable<ScriptExecutionParams> {

    public ScriptExecutionParams( bool recurse, string fileMask, string path ) {
        Recurse = recurse;
        FileMask = fileMask;
        Path = path;
    }

    public ScriptExecutionParams( ) {
    }

    /// <summary>
    /// Holds the mask for the task
    /// </summary>
    public string FileMask { get; } = "*.*";

    /// <summary>
    /// Holds the base path for the task
    /// </summary>
    public string Path { get; } = "";

    /// <summary>
    /// If true, the executor will recurse into subfolders.
    /// </summary>
    public bool Recurse { get; } = false;

    /// <inheritdoc />
    public static bool operator !=( ScriptExecutionParams left, ScriptExecutionParams right ) => !( left == right );

    /// <inheritdoc />
    public static bool operator ==( ScriptExecutionParams left, ScriptExecutionParams right ) => left.Equals( right );

    /// <inheritdoc />
    public override readonly bool Equals( object obj ) => obj is ScriptExecutionParams @params && Equals( @params );

    /// <inheritdoc />
    public readonly bool Equals( ScriptExecutionParams other ) => FileMask == other.FileMask && Path == other.Path && Recurse == other.Recurse;

    /// <inheritdoc />
    public override int GetHashCode( ) {
        int hashCode = 1232205743;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode( FileMask );
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode( Path );
        hashCode = hashCode * -1521134295 + Recurse.GetHashCode( );
        return hashCode;
    }
}
