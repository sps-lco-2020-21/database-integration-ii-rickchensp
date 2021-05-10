# database-integration
 
## Note

As outlined in the file `MovieDatabase.cs` there is a bit of a well known bug with aspects of SQLite. 

There will be an [interop error](https://stackoverflow.com/a/41700451/2902)

* goto to the directory: DatabaseIntegration.Lib\bin\Debug 
* copy the two sub-directories `x86/` and `x64/` (each should have two files in them: `sqlite3.dll` and `SQLite.Interop.dll`) 
* go into the `bin/Debug` directories for the `CommandLine` and the `UI` projects and copy these two sub-directories (replacing any of the same names that are already there)


