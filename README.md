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
| An instance of a Stylist object can be created | "Betty Clark", "Colorist", "01/01/2019" | The type of the Stylist instance is correct | Verification that the Stylist constructor works |
| A new stylist can be added and saved in the database | "Betty Clark", "Colorist", "01/01/2019" | In MySQL, "SELECT * FROM stylists WHERE name = 'Betty Clark'" returns a row | Verification of the Save() method of the Stylist class |
| The value of each of the Stylist object's properties can be obtained successfully | "Colorist" | The Specialty property of an instance of a Stylist has the value of "Colorist" | Verification of the Specialty Getter method of the Stylist object |
| Properties of an instance of a Stylist can be updated | "Barber" | The updated Specialty property of a Stylist instance is "Barber" | Verification of the Specialty Setter method of the Stylist object |
| An entered stylist must have a value | Blank, ie, "" | "No stylist was entered" | Verification that a stylist was entered |
| An instance of a Client object can be created | "Sharon Smith", "Female" | The type of the Client instance is correct | Verification that the Client constructor works |
| A new client can be added and saved in the database (if there are stylists) | "Sharon Smith", "Female" | In MySQL, "SELECT * FROM clients WHERE name = 'Sharon Smith'" returns a row | Verification of the Save() method of the Client class |
| The value of each of the Client object's properties can be obtained successfully | "Sharon Smith" | The Name property of an instance of a Client has the value of "Sharon Smith" | Verification of the Name Getter method of the Client object |
| Properties of an instance of a Client can be updated | "Tom Jones" | The updated Name property of a Client instance is "Tom Jones" | Verification of the Name Setter method of the Client object |
| An entered client must have a value | Blank, ie, "" | "No client was entered" | Verification that a client was entered |
| A list of stylists can be viewed | N/A | A list of stylists is returned. | Verification that the GetAll() method for the Stylist class works correctly |
| The details for a stylist can be viewed | 1 | The selected stylist's Name, Specialty and Hire Date are returned. | Verification that the Find() method for the Stylist class works correctly |
| A list of all clients can be viewed | N/A | A list of all clients is returned. | Verification that the GetAll() method for the Client class works correctly |
| The details for a client can be viewed | 1 | The selected client's Name and Gender are returned. | Verification that the GetAll() method for the Client class works correctly |
| A client can be added to a specific stylist |
| The clients that belong to a stylist can be viewed | N/A | A list of clients who belong to a stylist are returned. | Verification that the GetClients() method of the Stylist class works correctly |

## Instructions
Download and install the following required software packages"
1. .NET Core 1.1.4 SDK
2. .NET Core Runtime 1.1.2
3. Mono

Create the databases and tables by connecting to MySQL and executing the SQL statements below:

    $ mysql -proot -uroot -P8889

    > CREATE DATABASE mark_strickland;
    > USE mark_strickland;
    > CREATE TABLE stylists (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                             name VARCHAR(255) NOT NULL,
                             specialty VARCHAR(255) NOT NULL,
                             hire_date DATETIME NOT NULL) ENGINE=InnoDB;

    > CREATE TABLE clients (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(255) NOT NULL,
                            gender enum ("Male", "Female", "Non-Binary"),
                            stylist_id INT NOT NULL) ENGINE=InnoDB;

    > CREATE DATABASE mark_strickland_test;
    > USE mark_strickland_test;
    > CREATE TABLE stylists (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                             name VARCHAR(255) NOT NULL,
                             specialty VARCHAR(255) NOT NULL,
                             hire_date DATETIME NOT NULL) ENGINE=InnoDB;

    > CREATE TABLE clients (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(255) NOT NULL,
                            gender enum ("Male", "Female", "non-binary"),
                            stylist_id INT NOT NULL) ENGINE=InnoDB;

Clone this repository as follows: $ git clone https://github.com/MarkStrickland562/HairSalon.Solution

To edit the project, open the project in your preferred text editor.

Install the required .NET packages:

    $ cd HairSalon.Solution/HairSalon
    $ dotnet restore
    $ cd ../HairSalon.tests
    $ dotnet restore

To run the program, navigate to the production directory and build and run the application:

    $ cd ../HairSalon   -- this is assuming that you were still in the HairSalon.Tests directory from above.
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
