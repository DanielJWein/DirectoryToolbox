using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Toolbox;

public class Script {

    /// <summary>
    /// Holds the base path for scripts
    /// </summary>
    public static readonly string BasePath = "C:/ProgramData/DanielWein/DirectoryToolbox/Scripts/";

    /// <summary>
    /// Holds the standard script boilerplate
    /// </summary>
    private static readonly string scriptBoilerplate = @"
{ADDL_USINGS}
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SN {
    class CancelException : Exception {
        public CancelException() : base(""The operation was cancelled."") {
        }
        public CancelException(string message) : base(message) {
        }
    }

    class SC {
{CONTENT}
    }
}";

    public Script( ) {
    }

    /// <summary>
    /// Reads a script from a directory
    /// </summary>
    /// <param name="dirpath"> The directory to read from </param>
    public Script( string dirpath ) => Read( dirpath );

    /// <summary>
    /// Holds the content of the script
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Holds the name of the script
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Creates a new script
    /// </summary>
    /// <param name="Name">    The name of the script </param>
    /// <param name="Content"> The content of the script </param>
    /// <returns> The created script </returns>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown if <paramref name="Name" /> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// Thrown if <paramref name="Name" /> contains invalid file name characters. (see <see cref="Path.GetInvalidFileNameChars()" />)
    /// </exception>
    public static Script New( string Name, string Content = "" ) {
        if ( Name is null ) {
            throw new System.ArgumentNullException( nameof( Name ) );
        }

        if ( string.IsNullOrEmpty( Name ) || Path.GetInvalidFileNameChars( ).Any( x => Name.Contains( x ) ) ) {
            throw new System.ArgumentException( "The file name contained invalid characters!", nameof( Name ) );
        }

        Directory.CreateDirectory( BasePath + Name );
        File.WriteAllText( BasePath + Name + "/script.cs", Content );

        Script s = new( ) {
            Name = Name,
            Content = Content
        };
        return s;
    }

    /// <summary>
    /// Reads all scripts
    /// </summary>
    /// <returns> The list of scripts found </returns>
    /// <exception cref="DirectoryNotFoundException">
    /// Thrown if <see cref="BasePath" /> did not exist.
    /// </exception>
    public static List<Script> ReadAll( ) {
        if ( !Directory.Exists( BasePath ) ) {
            throw new DirectoryNotFoundException( "The base path directory does not exist!" );
        }
        DirectoryInfo[] dirs = new DirectoryInfo(BasePath).GetDirectories();
        return dirs.Select( x => new Script( x.FullName ) ).ToList( );
    }

    /// <summary>
    /// Deletes the script
    /// </summary>
    public void Delete( ) {
        Directory.Delete( BasePath + Name, true );
        Content = Name = null;
    }

    /// <summary>
    /// Gets the full code for the script
    /// </summary>
    /// <returns> The script's code </returns>
    public string GetFullCode( ) {
        int idxRefStart = Content.IndexOf("#@");
        string refPart = Content.Contains("#@")
            ? Content.Substring(idxRefStart + 2, Content.IndexOf("@#", idxRefStart) - idxRefStart - 2)
            : "";

        return scriptBoilerplate
            .Replace( "{CONTENT}", Content )
            .Replace( "{ADDL_USINGS}", refPart )
            .Replace( "#@" + refPart + "@#", "" );
    }

    /// <summary>
    /// Reads script data
    /// </summary>
    /// <param name="DirPath"> The path to the script directory </param>
    public void Read( string DirPath ) {
        DirectoryInfo di = new(DirPath);
        Name = di.Name;
        Content = File.ReadAllText( di.FullName + "/script.cs" );
    }

    /// <summary>
    /// Saves the script
    /// </summary>
    public void Save( ) {
        Directory.CreateDirectory( BasePath + Name );
        File.WriteAllText( BasePath + Name + "/script.cs", Content );
    }
}
