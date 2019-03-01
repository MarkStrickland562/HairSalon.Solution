# _Curl Up and Dye Hair Salon_

#### _Date: 03/01/2019_
## Author
 _**Name:  Mark Strickland**_

 _**Email: markstrickland562@hotmail.com**_

## Description
**_This program provides a web-based interface for employees of the Curl Up and Dye Hair Salon._**

**_The program has these features:_**

## Features
| Feature                                                                                    |
| :-----------------------------------------------------------------------------------------:|
| See a list of stylists |
| Select a stylist and view their details |
| View a list of clients that belong to a stylist |
| Add new stylists to the system |
| Add new clients to a specific stylist (unless no stylists have been added) |

## Specifications
|   Behavior                  | Input Example  | Output Example | Explanation                |
| :--------------------------:| :-------------:| :-------------:| :-------------------------:|
| An instance of a Stylist object can be created | "Betty" | The type of the Stylist instance is correct | Simple verification that the Stylist constructor works |
| The value of each of the Stylist object's properties can be obtained successfully | "Colorist" | The Specialty property of an instance of a Stylist has the value of "Colorist" | Simple verification of the Speciality Getter method of the Stylist object |
| Properties of an instance of a Stylist can be updated | "Barber" | The updated Specialty property of a Stylist instance is "Barber" | Simple verification of the Specialty Setter method of the Stylist object |
| An entered stylist must have a value | Blank, ie, "" | "No stylist was entered" | Verification that a stylist was entered |



## Instructions
Download and install the following required software packages"
1. .NET Core 1.1.4 SDK
2. .NET Core Runtime 1.1.2
3. Mono

Clone this repository as follows: $ git clone https://github.com/MarkStrickland562/HairSalon.Solution

To edit the project, open the project in your preferred text editor.

Change into the work directory: $ cd HairSalon.Solution

To run the program, navigate to the production directory and build and run the application:

    $ cd HairSalon
    $ dotnet build
    $ dotnet run

Then navigate to the site in a browser with "http://localhost:5000".

To run the tests for this project, change back into the solution directory, HairSalon.Solution, then use these commands:

    $ cd HairSalon.Tests
    $ dotnet test

## Technologies Used
* _.NET Core 1.1.4 SDK_
* _.NET Core Runtime 1.1.2
* _Mono_
* _C#_
* _MSTesst_
* _MySQL_
* _ATOM_
* _Git_


## License

Copyright (c) 2019 **_Mark Strickland_**
