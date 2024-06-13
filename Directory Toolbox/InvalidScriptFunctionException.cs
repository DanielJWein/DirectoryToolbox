using System;

namespace Directory_Toolbox;

[Serializable]
public class InvalidScriptFunctionException : Exception {
    public InvalidScriptFunctionException( ) { }
    public InvalidScriptFunctionException( string message ) : base( message ) { }
    public InvalidScriptFunctionException( string message, Exception inner ) : base( message, inner ) { }
    protected InvalidScriptFunctionException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
}
