# database-integration
 
In the accompanying solution there are three projects: 
1. A Lib containing some library functions to create a connection to a database. (The database is with the .exe project and will be copied to the bin directory, you can amend the `app.config` and refer to a single version that you already have somewhere on your machine.)
1. A CommandLine app which will run a simple query and display some details to the console 
1. A UI app which will bind a DataTable to a control to show the power of data binding - this a rich seam to mine, definitely one that might make your UIs easier, if that's ever needed. 

## Note

As outlined in the comments in the file `MovieDatabase.cs` there is a bit of a well known bug with aspects of SQLite. 

Once you've cloned the repo to your local machine you will need to build the solution first, to ensure that the various bin directories have been created. 

There will be an [interop error](https://stackoverflow.com/a/41700451/2902)

* goto to the directory: DatabaseIntegration.Lib\bin\Debug 
* copy the two sub-directories `x86/` and `x64/` (each should have two files in them: `sqlite3.dll` and `SQLite.Interop.dll`) 
* go into the `bin/Debug` directories for the `CommandLine` and the `UI` projects and copy these two sub-directories (replacing any of the same names that are already there)


