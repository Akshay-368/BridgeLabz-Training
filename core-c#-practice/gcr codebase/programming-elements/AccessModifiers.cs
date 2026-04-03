using System;

namespace SocialMediaDemo
// Namespace to encapsulate the social media related classes . Basically a project to group similar classes together.
{
    // INTERNAL: accessible anywhere inside this project. But not outside the project/assembly.Yeah it's assembly and project are similar terms here. 
    // Though assembly is a compiled unit / output (like DLL or EXE) and thus deals with the "what actually exists at the runtime ? " and project is a source code unit and deals with " what are we building ? "

    internal class Userprofile
    {
        // PUBLIC: visible to everyone
        public string Username ;

        // PRIVATE: only this class can access it
        private string password ; // as this a sensitive info and thus only the account itself can see it

        // PROTECTED: accessible by this class and derived classes
        protected int followersCount ; // only the user and thier subclasses can see them , thus only allowed to verified profiles only

        // PROTECTED INTERNAL:
        // Accessible by derived classes OR any class in this project
        // Think of portectied internal as PROTECTED OR INTERNAL . It's very permissive comapred to private protected.
        protected internal string Email ; // only verified profiles or anyone inside this project can see the email address

        // PRIVATE PROTECTED:
        // Accessible only by derived classes within the SAME project
        // You can think of it as PRIVATE AND PROTECTED . It's the most restrictive access level when combining two modifiers.
        private protected string Phoneno ; //ofocurse maximum security for phone number out of any other info

        public Userprofile(string username, string password)
        {
            Username = username ;
            this.password = password ;
            followersCount = 0;
            Email = "hidden@email.com";
            Phoneno = "9999999999";
        }
        // This was the constructor method which are special methods .
        // this one initialises the profile of user with the default values ( as we provided them here as default already )
        // and we kept password and phoneno as private / protected , not exposed them to public

        public void DisplayPublicProfile()
        // info that anyone can see , visible to public
        {
            Console.WriteLine( $"Username: {Username}" ) ;
            Console.WriteLine( $"Followers: {followersCount}" ) ;
        }

        private bool CheckPassword(string input)
        // just a private helper method to verify passwords. Only for the use of class itself.
        // Also let me clarify that a helper method is a method that assists other methods in performing their tasks.
        {
            return password == input;
        }
    }

    // INHERITANCE to demonstrate protected access
    internal class Influencerprofile : Userprofile
    // as influencer profile inherits from Userprofile
    // because of inheritance ,
    // it can access followersCount ( which is protected in base class )
    // it can access Email ( which is protected internal in base class
    // It can also access Phoneno ( which is private protected in base class ) because both classes are in same project
    // Thus we can clearlyy see the modifers behaviour in subclasses.
    {
        public Influencerprofile( string username, string password ) : base( username, password )
        {
            followersCount = 1000; // PROTECTED access
            Email = "influencer@email.com" ; // PROTECTED INTERNAL
            Phoneno = "8888888888"; // PRIVATE PROTECTED (same project)
        }

        public void ShowinfluencerStats()
        {
            Console.WriteLine($"Influencer Followers: {followersCount}"); // PROTECTED access
            Console.WriteLine($"Contact Email: {Email}");
        }
    }

    class Program
    {
        static void Main()
        // now we create a normal user and an influencer
        // to show what can and cannot be accessed from outside the class
        {
            Userprofile user = new Userprofile("samuel", "secret123") ;
            user.DisplayPublicProfile();

            Influencerprofile influencer =
                new Influencerprofile( "evergreen" , "viralpass" ) ;

            influencer.ShowinfluencerStats() ;

            // These will NOT work due to access restrictions: so just in case you are wondering
            // what can't be accessed or what's a wrong way to access
            // user.password;
            // user.followersCount;
            // user.Phoneno;

            Console.WriteLine("Access Modifiers Demo Complete.");

            // Infact you can think of it as this way :
            // PRIVATE < PRIVATE PROTECTED < PROTECTED < INTERNAL < PROTECTED INTERNAL < PUBLIC
            // public = most open
            // private = most closed / sealed / restrictive
            // protected = open to inherited
            // internal = open within the same project
            // protected internal = open to inherited or same project , union ( basically OR ) of protected + internal
            // private protected = open to inherited within same project , intersection  ( basically AND) of private + protected ( most restrictive of the combined ones. )
        }
    }
}
