# NabPeople
NAB question.

Notes last updated : 27/1/2019.
Author : Cameron Young.

To run the application execute NabPeople.ConsoleApp.
This is a C# console application.
To run in an IDE it is recommended to use Visual Studio 2017.
*** NOTE : the console application runs as an async. ***
To run this in the IDE you need to configure the console project in the IDE to run as async.
This functionality is new in .net core but is available in the latest minor version.
In the console project properties select Build->Advanced. 
Set the language version to "C# latest minor version (latest)"
See : https://blogs.msdn.microsoft.com/benwilli/2017/12/08/async-main-is-available-but-hidden/

Unit Testing frameword used : XUnit.

Note : the class PeopleReportCatsFull is not implemented.
It is a derived class included only to demonstrate the report extensibility.
The implemented report class is PeopleReportCatsSimple.

Logging of exceptions : Exceptions are rethrown to the process boundary.
The console application traps all exceptions in the Main method.
All exception logging can be run from the exception handling in this method.
Currently marked with 'TODO : Add logging here.'
