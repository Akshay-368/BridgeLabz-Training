// File: Program.cs

using System;
using System.IO;
using System.Threading;

// This is the entry point. It prints the welcome and calls Menu. All public static.

// Main method, entry
class Program
{
    public static void Main ( string [] args ) 
    {
/*
Ok so I have to build AddressBook System
The outcome is this
1. Ability to work with File Handles
2. Ability to work with Database
3. Ability to save to Cloud Server
4. Ability to use Multi Threading for IO or Network calls
Start with Displaying
Welcome to Address Book Program in AddressBookMain class on START Master Branch
and there are going to be 11 UCs
UC 1 :
Ability to create a Contacts in Address
Book with first and last names, address,
city, state, zip, phone number and
email...
- Program is written using IDE like Visual Studio
- Every UC is in a separate Git Branch and then merged with main
- Naming Convention, Indentation, etc Code Hygiene will be checked during
Review
- Git Check In Comments and Version History will be monitored
UC 2 :
Ability to add a new
Contact to Address Book
- Use Console to add person details from
AddressBookMain class
- Use Object Oriented Concepts to manage
relationship between AddressBook and Contact
Person
UC - 3
Ability to edit
existing contact
person using their
name
UC - 4
Ability to delete a
person using
person's name - Use Console to delete a person
UC - 5
Ability to add multiple
person to Address Book
- Use Console to add person details one at a time
- Use Collection Class to maintain multiple
contact persons in Address Book
UC - 6
Refactor to add multiple
Address Book to the
System. Each Address Book
has a unique Name - Use Console to add new Address Book - Maintain Dictionary of Address Book Name to
UC -7
Ability to ensure there is no
Duplicate Entry of the same
Person in a particular Address
Book - Duplicate Check is done on Person Name while
adding person to Address Book.
- Use Collection Methods to Search Person by Name
for Duplicate Entry
- Override equals method to check for Duplicate
UC - 8
Ability to search Person
in a City or State across
the multiple Address
Book - Search Result can show multiple person in the city or state
UC - 9
Ability to view Persons
by City or State
- Maintain Dictionary of City and Person as
well as State and Person
- Use Collection Library to maintain
Dictionary
UC - 10
Ability to get number
of contact persons
i.e. count by City or
State - Search Result will show count by city and by state
UC - 11
Ability to sort the entries in the
address book alphabetically by
Person’s name
- Use Console to sort person details by name
- Use Collection Library for Sorting
- Override toString method to finally Print Person Entry in
Concole
 
*/

        // Printing the welcome message as per UC
        Console . WriteLine ( "Welcome to Address Book Program in AddressBookMain class on START Master Branch" ) ;

        // Create instance, even though static-ish
        AddrBk ab = new AddrBk ( ) ;

        // Call menu
        Menu . ShwMenu ( ab ) ; // Menu class's ShwMenu method is called here, passing the ab object. This keeps Program simple, Menu handles logic, loose coupling.

        // Redundant print
        Console.WriteLine ( "Exited." ) ;
    }
}
