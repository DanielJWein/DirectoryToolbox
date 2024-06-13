using System;
using System.Collections.Generic;

namespace Directory_Toolbox;

/// <summary>
/// Holds results from a script task
/// </summary>
public readonly struct ScriptExecutionResult : IEquatable<ScriptExecutionResult> {

    public ScriptExecutionResult( ) {
    }

    public ScriptExecutionResult( int filesProcessed, int directoriesProcessed, string status, Exception error ) {
        FilesProcessed = filesProcessed;
        DirectoriesProcessed = directoriesProcessed;
        Status = status;
        Error = error;
    }

    /// <summary>
    /// Holds the number of directories processed by the executor
    /// </summary>
    public int DirectoriesProcessed { get; } = 0;

    /// <summary>
    /// Holds the error that occured, if any. Null otherwise.
    /// </summary>
    public Exception? Error { get; } = null;

    /// <summary>
    /// Holds the number of files processed by the executor
    /// </summary>
    public int FilesProcessed { get; } = 0;

    /// <summary>
    /// Holds a status message to be displayed on the Status Label.
    /// </summary>
    public string Status { get; } = "";

    /// <inheritdoc />
    public static bool operator !=( ScriptExecutionResult left, ScriptExecutionResult right ) => !( left == right );

    /// <inheritdoc />
    public static bool operator ==( ScriptExecutionResult left, ScriptExecutionResult right ) => left.Equals( right );

    /// <inheritdoc />
    public override readonly bool Equals( object obj ) => obj is ScriptExecutionResult result && Equals( result );

    /// <inheritdoc />
    public readonly bool Equals( ScriptExecutionResult other ) => DirectoriesProcessed == other.DirectoriesProcessed && EqualityComparer<Exception>.Default.Equals( Error, other.Error ) && FilesProcessed == other.FilesProcessed && Status == other.Status;

    /// <inheritdoc />
    public override int GetHashCode( ) {
        int hashCode = 85276780;
        hashCode = hashCode * -1521134295 + DirectoriesProcessed.GetHashCode( );
        hashCode = hashCode * -1521134295 + EqualityComparer<Exception>.Default.GetHashCode( Error );
        hashCode = hashCode * -1521134295 + FilesProcessed.GetHashCode( );
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode( Status );
        return hashCode;
    }
}
