# DirectoryToolbox
A tool to create and execute C# scripts on directories

### Requirements
To use DirectoryToolbox, you'll need .NET Framework 4.8. You can find it [on Microsoft's website](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48).

### Usage
To use DirectoryToolbox, simply run it. A sample script is automatically created.

Start by inserting your code into either `ProcessDirectory` or `ProcessFile`. 

As long as the function returns `true`, it will continue processing directories / files. 

If it returns `false`, execution stops for that type of item.

You can save your script with the 💾 button. Load it again with the 📝 button. Run it with ▶️, and delete it with 🗑️.

There are two functions that can be run before and after processing. These functions are `static void Initialize(object unused)` and `static void Finalize(object unused)`. You will need to define them yourself.

Keep in mind that the object parameters are required, not optional. They will be passed `(int)7` for now.

On the right, there is the Options panel. At the top is the Path Box, where you can define where processing starts.

There's a checkbox labeled "Recurse" which will traverse subdirectories.

Additionally, there's a checkbox "Mask" which shows the Mask box, where you can filter what files will be passed to `ProcessFile`. The mask is a standard Windows wildcard pattern.

### Contributing
Please open a Pull Request against the master branch.
