using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.CSharp;

namespace Directory_Toolbox;

/// <summary>
/// Executes scripts.
/// </summary>
internal static class ScriptExecutor {

    /// <summary>
    /// Runs a script
    /// </summary>
    /// <param name="s">    The script to run </param>
    /// <param name="prms"> Parameters for the operation </param>
    /// <returns> A <see cref="ScriptExecutionResult" /> struct with resultant information </returns>
    internal static ScriptExecutionResult RunScript( Script s, ScriptExecutionParams prms ) {
        if ( s == null )
            return new( 0, 0, "Operation Canceled", null );

        // --- Step 1: Compilation ---

        // - Substep 1: Compilation -
        CompilerResults Compilation = compileScript( s );

        // - Substep 2: Error checking
        if ( Compilation.Errors.Count > 0 ) {
            StringBuilder sb = new();
            foreach ( CompilerError error in Compilation.Errors ) {
                sb.AppendLine( error.ToString( ) );
            }
            sb.AppendLine( "Reload the script with the \"Edit\" button to continue editing (your script was saved.)" );
            return new ScriptExecutionResult( 0, 0, "Exception Encountered", new Exception( sb.ToString( ) ) );
        }

        // --- Step 2: Execution ---

        // - Substep 1: Setup -
        DirectoryInfo baseDir = new(prms.Path);
        string fmask = prms.FileMask;
        SearchOption recursion = prms.Recurse? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        DirectoryInfo[] dirs = baseDir.GetDirectories(fmask, recursion);
        FileInfo[] fils = baseDir.GetFiles(fmask, recursion);

        // - Substep 2: Reflection -
        Type compClass = Compilation.CompiledAssembly.GetType("SN.SC");

        MethodInfo initializeFunc = compClass.GetMethod("Initialize");
        MethodInfo processDirFunc = compClass.GetMethod("ProcessDirectory");
        MethodInfo processFileFunc = compClass.GetMethod("ProcessFile");
        MethodInfo finalizeFunc = compClass.GetMethod("Finalize");

        // - Substep 3: Verification -
        verifyFunctions( ref dirs, ref fils, processDirFunc, processFileFunc, initializeFunc, finalizeFunc );

        // - Substep 4: Execution -
        initializeFunc?.Invoke( null, new object[ ] { 7 } );

        int folders = processDirectories( dirs, processDirFunc);

        int files = processFiles( fils, processFileFunc);

        // - Substep 5: Finalization -
        finalizeFunc?.Invoke( null, new object[ ] { 7 } );

        //Return the result.
        return new ScriptExecutionResult( files, folders, "Finished", null );
    }

    /// <summary>
    /// Compiles a script
    /// </summary>
    /// <param name="s"> The script to compile </param>
    /// <returns> The results from the compiler </returns>
    private static CompilerResults compileScript( Script s ) {
        CompilerParameters Parameters = new() {
            GenerateExecutable = false,
            GenerateInMemory = true,
            IncludeDebugInformation = true
        };

        // - Substep 1: Assemblies -
        string[] Assemblies = Assembly.GetEntryAssembly()
            .GetReferencedAssemblies()
            .Where(x => x.FullName.Contains("System") || x.FullName.Contains("Rezuru"))
            .Select(x => x.Name + ".dll").OrderBy(x => x).ToArray();

        Parameters.ReferencedAssemblies.AddRange( Assemblies );

        // - Substep 2: Code preparation -
        CSharpCodeProvider cssp = new();
        string src = s.GetFullCode();

        // - Substep 3: Compilation
        CompilerResults Compilation = cssp.CompileAssemblyFromSource(Parameters, src);
        return Compilation;
    }

    private static int processDirectories( DirectoryInfo[ ] dirs, MethodInfo processDirFunc ) {
        int folders = 0;

        foreach ( var d in dirs ) {
            folders++;

            if ( !(bool) processDirFunc.Invoke( null, new object[ ] { d } ) ) {
                break;
            }
        }

        return folders;
    }

    private static int processFiles( FileInfo[ ] fils, MethodInfo processFileFunc ) {
        int files = 0;

        foreach ( var f in fils ) {
            files++;
            if ( !(bool) processFileFunc.Invoke( null, new object[ ] { f } ) ) {
                break;
            }
        }

        return files;
    }

    private static void verifyFunctions( ref DirectoryInfo[ ] dirs, ref FileInfo[ ] fils, MethodInfo processDirFunc, MethodInfo processFileFunc, MethodInfo initializeFunc, MethodInfo finalizeFunc ) {
        Type b = typeof(bool);

        if ( ( processDirFunc?.ReturnType ?? b ) != b ) {
            throw new InvalidScriptFunctionException( "The return type of ProcessDirectory was incorrect! (Should be bool)" );
        }
        if ( ( processFileFunc?.ReturnType ?? b ) != b ) {
            throw new InvalidScriptFunctionException( "The return type of ProcessFile was incorrect! (Should be bool)" );
        }

        if ( !( initializeFunc?.IsStatic ?? true ) ) {
            throw new InvalidScriptFunctionException( "The initialize function was not static!" );
        }

        if ( !( finalizeFunc?.IsStatic ?? true ) ) {
            throw new InvalidScriptFunctionException( "The finalize function was not static!" );
        }

        if ( !( processDirFunc?.IsStatic ?? true ) ) {
            throw new InvalidScriptFunctionException( "The processDirectory function was not static!" );
        }

        if ( !( processFileFunc?.IsStatic ?? true ) ) {
            throw new InvalidScriptFunctionException( "The processFile function was not static!" );
        }

        if ( processDirFunc is null ) {
            dirs = Array.Empty<DirectoryInfo>( );
        }

        if ( processFileFunc is null ) {
            fils = Array.Empty<FileInfo>( );
        }
    }
}
