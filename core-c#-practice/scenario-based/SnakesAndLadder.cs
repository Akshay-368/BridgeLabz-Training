using System ;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
namespace Snake_And_Ladders ;

/*
Snake & Ladder – Problem Statement (Multiple Players | .NET 6+)
Objective

Build a console-based Snake & Ladder game using .NET 6 or above applying the fundamentals of C# programming,
including variables, data types, operators, conditions, loops, and collections.
You must follow proper programming hygiene and use Git/GitHub for version control.

🎯 Requirements
1. Game Description

Create a Snake & Ladder game with the following rules:

The board has 100 cells (1 to 100).

There are a set of fixed snakes and ladders.

A player starts at position 0.

Dice generates a random number between 1 and 6.

First player to reach exactly 100 wins.

If a dice roll goes beyond 100, the player skips the turn.

2. Multi-Player Rules

The game should support minimum 2 and maximum 4 players.

Each player takes turns one after another.

When a player lands on:

A ladder → move up to higher position.

A snake → slide down to lower position.

Display each turn details:

Player name

Dice value

Old position → New position

Snake/ladder message (if applied)

3. Technical Requirements
A. .NET Fundamentals
You must use the following concepts correctly:

✔ Variables, Literals, Primitive Data Types

(int, string, bool, etc.)

✔ Operators

(Arithmetic, assignment, comparison, logical)

✔ Logical Constructs

if–else

switch

ternary operator (?:) — use at least once

for, while, do-while, foreach — use at least two types of loops

✔ Jump Statements

break

continue

✔ Functions (methods)

Make the code modular using methods such as:

RollDice()

MovePlayer()

ApplySnakeOrLadder()

CheckWin()
*/

public static class Snake_And_Ladders
{
    private static int [] Players ; // Making the array so that it can be accessible to all in this class , as otherwise i would have to keep on pass it around
    private static int currentTurn ; // making it static as we want only one single currentTurn for any instance of the class.
    // Though even without that this would have run fine as still within this class and thus for one single instance of the class , it would still be only one. 
    // Though for multiple objects of the class there will be multiple such currentTurn and Players and all , which is quite right , but i am not going there yet.
    // After all the instructor said to not use oops concepts ( and yet technically in c# you still have to define classes adn stuff so yeah there is only so much that i can run away from oops here for this task )

    private static bool cancelrequest = false ;

    public static void Main()
    {
        
        int[] board = new int[100]; // Creating the board of the game where the players can play snake and ladders.
        // This means the game board has 100 cells , index ranging from 0 to 99 .( both included )
        
        // Thread thread = new Thread (ListenForExit());
        // We can't do it as this actually calls the method immediately on the current thread. without giving thread something to run after it is created first.
        // Thus by doing that we did not ven give thread time to get created and thus we could not listen for the exit command.
        // and other reason is that the return value of ListenForExit() (which is void) is then passed to the Thread constructor
        //  which doesn’t make sense, and will cause a compile-time error.
        // As Thread constructor expect a delegate which is a pointer or reference to the method it is supposed to call when it gets created
        // not the call of the method directly ( i.e. not the result of calling the method.)
        // Writing ListenForExit (without parentheses) gives the delegate.
        // Writing ListenForExit() (with parentheses) executes the method immediately


        Thread thread = new Thread (ListenForExit);
        thread.Start(); // consider this a helper thread as the only purpose is to listen for the exit command by player. NOt too important as even without that
        // code can terminate , but it just provides much more of a multi-tasking by cooperation of all the methods of the class to look for the exit command.
        // that otherwise would not have been possible without having a thread.

        Console.WriteLine("Welcome to the game of Snake and Ladders 😁👋. Hope you will enjoy your game-time . ");
        Console.WriteLine ( " Please enter the number of players you are : ") ;



        if ( ! int.TryParse ( Console.ReadLine() , out int playersCount ) )
        {
            playersCount = 2 ;
        }

        // Creating an array , as I am advised to use only the concepts covered in the class itself and not wander into oops yet.

        Players = new int[playersCount ];
        // Now we have the array for storing the info of each player
        // here basically each element of the array is going to be the position of the player in the game
        // and every index of the array represnet the player number here basically . ( though yeah i could do it as i + 1 for better readability of the player number )
        // Now now the players should all start from index 0 of the game board array which is the starting point of the game
        // ANd luckily since i used an array of type int, the by default value of each element after geting initialized is 0 in C#.
        // So all the players will start from the starting point of the game board

        Console.WriteLine (" Every player please pay notice that the turns will start from player 0 and then player 1 and then so on..." +
        "and until we reach the last player and after that the turn of the first player will come back to them and this cycle will keep going on ." );

        // Menu for the players
        Console.WriteLine ( " Here is the menu for the players : " ) ;

        string input ;
        

        do {
            Console.WriteLine ( " Press r to roll a dice " ) ;
            Console.WriteLine (" Press e to exit the game ") ;
            input = Console.ReadLine() ;
            input = string.IsNullOrWhiteSpace (input) ? "r" : input ; // this is to just take the input safely and make sure we have a default in place
            // here if the condition of is null or is empty gets true then ternary operator will assign the default value of "r" to input
            // otherwise the original will run as usual .

            if ( input == "r" )
            {
                var snakesAndLadders = ApplySnakesAndLadders(); // Placing the call to apply snakes and ladders here as we don't want to waste computation setting up snakes
                // and ladders and then printing them to showcase to user if they don't even wanted to play in the first place.

                currentTurn = 0 ; // To keep track of which player's turn it is currently
                moveAndUpdate( ref currentTurn , Players , snakesAndLadders) ; // making sure we pass the actual reference of the int turn variable instead of a copy.

                
            }else if ( input == "e" )
            {
                Console.WriteLine ( " Exiting the game ... " ) ;
                cancelrequest = true ; // adding this as well to make the program terminate as soon as user enters e and thus thread will end as well
                return ; // This return in a sense straight up makes the while loop below redundant as if the input gets e then program will terminate immediatley and not even while condition will get a chance to be chcecked at all.
                // but that's alright as i don't really care about that . because i have to end the program , doesn't matter if you plug out the chord or just hit Alt + F4 to stop the computer , if all you want is to stop
                // and user entering e is already a sign they want to quit . thus not using break here .
            }
        }while ( input != "e" || ! cancelrequest ) ;

        
    }

    private static Random random = new Random() ; // now only one shared private random resouce is available for the whole class which is not getting created again and again multiple times within same milliseconds.

    private static  int rolling ()
    {
        if ( cancelrequest ) return  0 ;

        // Random random = new Random () ; // Random is deterministic in nature especially when the seed is same. As such it will always generate the same sequence of numbers
        // thus if the random gets created here and it gets called multiple times within same milliseconds ( as if the seed is not provided then it uses local time as seed ) and thus the number can be same.
        return random.Next(1 , 7 ) ; //  A seed is the initial value that determines the sequence of pseudo‑random numbers.
        // You can think of it like a random shuffle squence and you can absoultely get the same result which is deterministic if the seed happens to be the same which is the initial starting point of the shuffling sequence
        // Returning the randomly generated number for the dice between 1 to 6 ( both inclusive )

        // Since i am kinda confused about what's the purpose here with making only one random resource available for the whole class and not creating new random resource for each method call.
        // I am going to do a experiment with a imaginary algorithm for random. I mean since random is deterministic and obviously giving same output for same input which is a time stamp of your local system if no input ( which is called a seed is given ), thus it must be doing some maths ( advance maths for sure but still just a sequence of operations )
        /*

        The AlgorithmAs per my  design: ( (  seed / 2) * 0.7 )+ ( seed * 0.10) to be the Random algo that it runs to give us the output each time .
        To visualise the plan we will need :
        The "Private Static" Approach: One shared seed that gets updated and remembers its state.
        The "Local Instance" Approach: A new seed is created every time, often based on the system clock.

        The Simulation
        Let's imagine we call this method 3 times very quickly (at the exact same timestamp, Time = 100).

        Scenario A: The "Local Variable" Problem (Bad)
        Here, we create a new generator every time inside the method. Because computers are fast,
        all three calls happen at Time = 100. Therefore, the "Seed" (based on time) is 100 for all of them.

        Call 1 (Time = 100):

        Seed starts at 100.

        Calculation: (100/2)×0.7+(100×0.10)

        50×0.7+10

        35+10

        Result: 45

        Call 2 (Time = 100):

        New generator is made. It looks at the clock. Time is still 100.

        Seed resets to 100.

        Calculation: Same math.

        Result: 45 (Duplicate!)

        Call 3 (Time = 100):

        New generator is made. Time is still 100.

        Seed resets to 100.

        Result: 45 (Duplicate!)

        Observation : Because the generator forgot the previous shuffle, it started from scratch using the same time-based seed.

        Scenario B: The "Private Static" Solution (Good)Here, the generator is static. It lives outside the method call.

        It is created once at the start (at Time = 100) and remembers the last number it generated to use as the seed for the next one.
        Initialization (Time = 100):Static Seed starts at 100.
        Call 1:
        Input: 100 and calculation will be the same as (100/2)×0.7+(100×0.10)

        50×0.7+10

        35+10 = 45
        Result: 45
        Update State: The Static Seed is now 45.

        Call 2:Input: 45 (It remembers!)
        Calculation: (45 / 2) * 0.7 + (45 * 0.10) = 22.5* 0.7 + 4.5 = 15.75 + 4.5
        Result: 20.25
        Update State: The Static Seed is now 20.25.

        Call 3:Input: 20.25
        Calculation: (20.25 / 2) * 0.7 + (20.25 * 0.10) = 10.125 * 0.7 + 2.025 = 7.0875 + 2.025
        Result: 9.1125
        Update State: The Static Seed is now 9.1125.

        Observation : Even though the calls happened instantly,
        the results were 45, 20.25, and 9.1125. We achieved distinct numbers because we maintained the "state" of the shuffle.

        The keyword static in programming means "belongs to the class, not the specific instance call."
        It essentially tells the computer: "Do not destroy this variable when the function finishes. Keep it alive in memory so we can use its value next time."

        By making Random static, we are ensuring that the shuffling process continues where it left off,
        rather than restarting the deck of cards back to the original order every time we want to draw a card.
        */
    }

    private static void moveAndUpdate( ref int currentTurn , int[] Players , in ( int[] snakes , int [] ladders) snakesAndLadders )
    {
        if ( cancelrequest ) return ; // To check for exit request


        Console.WriteLine ( " Rolling the dice ... Please Wait ... ");
        // Now let's create a dice for rolling and moving players ahead .
        int dice = rolling();
        Console.WriteLine ( " You rolled a " + dice + " on the dice " ) ;

        int position = Players[currentTurn] + dice ; // its just a local variable as it is only used for each person's turn to calculate their new position
        // Earlier while writing at first i just make simple plus operation of dice number with current position to advance in game but i figure out that
        // i also need to make sure it does not go index out of bound range as there are only 100  cells to play.
        // thus if by any chance the player happens to be at the index ( not lengh) of 98 and dice generated 6 , then the exception of index out of bound will be thrown
        // Thus i need to check for the end of the game as well before i assign the value here to position .
        if ( position == 99 )
        {
            Console.WriteLine ( $" Congratulations !! You , player {Players[currentTurn]} have won the game !! " ) ;
            Console.WriteLine ( " The rest of players position is as follows : " ) ;
            for ( int i = 0 ; i < Players.Length ; i++)
            {
                // Looping through players array to print their positions
                if ( i != currentTurn )
                {
                    // Making sure that we don't end up repeating the same player again by that if condition to not re-write the winner.
                    Console.WriteLine ( $" Player {Players[i]} is at position {Players[i]} " ) ;
                    // As players array contain the positions of all players in the game, so we just have to print them as it is
                    // The positions are stored at the respective players name which is just their index in the array - Players.
                }
            }
            cancelrequest = true ;
            return;
        } else if ( position > 99)
        {
            Console.WriteLine ( $" Oops !! Bad Luck , the dice gave you - the player number , {currentTurn},  the number {dice}  which will make your position - {position} go-out of range of the game and as per rules you can't move for this turn and you have to sit idle at your current position {Players[currentTurn]}");
            updateTurn ( ref currentTurn , Players ) ; // caling the helper function early now as the earlier player can't move so the next player have to take their turn
            return ; // return back to the menu and ask the next player to roll the dice by pressing r.
        }
        Console.WriteLine ( $" Your - player {currentTurn} 's current position is now : {position} " ) ;

        updatePlayerPosition ( ref position , Players , in currentTurn ) ; // calling the helper function to update the Position



        // Now going to call checkforsnakeorladder () method to check if the player has landed on a snake or a ladder
        Console.WriteLine ( " Checking if you have landed on a snake or a ladder . So please wait... ");
        checkforsnakeorladder(snakesAndLadders.snakes , snakesAndLadders.ladders , ref position) ; // passing them seperately as individual arrays as the actual function
        // has to work on the arrays individually and not really any need of a tuple , the tuple just worked to package them till here and hold them as a package
        // but while working on it , it's actually feels better to have them seperately. and once again they are reference types so any change will still be affected
        // until re-assigned. which is not possible until ref is used . ( which is not used here )
        // and we get the tuple till here with in for this method as we don't want this method to do any changes or modification or work on it
        // thus we make the tuple read-only for it with the use of 'in' keyword

        // And after that calling for the updateTurn() method to update the turn to the next player
        // and remember Turn is a variable of value type and hence everytime a method is called which takes Turn as an argument
        // gets a copy of its own to work with and doesn't affect the original version at all
        // so the possible solution is to use ref or out which tells c# to pass the reference instead of a copy
        // Infact for arrays which is already a reference type , if we use ref , we can safely re-assign the array to a new one
        // and it will stick around, while without ref the change would not persists .
        // SO basically - ref → read/write by reference
        //  in → read-only by reference
        //  out → write-only by reference (must assign before returning)


        updateTurn( ref currentTurn , Players ) ;
    }

    private static void updatePlayerPosition( ref int position , int[] Players , in int currentTurn )
    {
        if ( cancelrequest ) return ; // To check for exit request

        Players[currentTurn] = position ; // updating the position of the player whose turn has just happened
        Console.WriteLine ( $" After the update this is the new position of the player no : {currentTurn} : {Players[currentTurn]} ");
        // since arrays just like List<int> are reference types , so the value would have changed in the actual Players array as well
    }

    private static void checkforsnakeorladder(int[] snakes, int[] ladders , ref int position)
    {
        if ( cancelrequest ) return ; // To check for exit request

        // Now looping through the snakes and ladders arrays to look for snakes and if found we will send the player to new position accordingly
        
            if ( snakes[position] != 0 )
            {
                Console.WriteLine ( " Oops !! You have landed on a snake's mouth. And now you will be sent back to " + snakes[position] ) ;
                Console.WriteLine ( " Your position is being updated now ... " ) ;
                position = snakes[position] ;
                updatePlayerPosition (ref position , Players , in currentTurn) ;
                // Since i was facing issues with passing Players and currentTurn around as i would have to first transfer them till this function
                // and then further send them to another method and all , so i just decided to make a field which is available to all the methods of that class
                // And now a quick note on what is a field .
                // - A field is a variable that belongs to a class or struct, declared directly inside it but outside any method or property.
                // It represents part of the state of an object (or of the class itself if static).
                // Fields can be accessed by all methods in the class, depending on their access modifier (private, public, etc.)

            }
            else if ( ladders[position] != 0 )
            {
                Console.WriteLine ( " Yay !! You have landed on a ladder's base. And now you can climb to " + ladders[position] ) ;
                Console.WriteLine ( " Your position is being updated now ... " ) ;
                position = ladders[position] ;
                updatePlayerPosition (ref position , Players , in currentTurn ) ;
            }
        
    }

    private static void updateTurn( ref int currentTurn , int[] Players )
    {
        if ( cancelrequest ) return ; // To check for exit request

        currentTurn = (currentTurn + 1 ) % Players.Length  ;
        // But since we want the turn to keep on going in a cycle and back to player 0 after the last player we need a offset that can sent it back to that player
        // while not affecting the currentTurn sequence either . So that's why we need more than just a linear simple addition of +1
        // That's why we are putting a % operator there that will make sure the cycle keep going on
        // For example , currentTurn = 3 , Players.Length = 4 , then we get this 3 % 4 = 3 and if currentTurn is 4 ( which by the way would exceed the indexing of the players)
        // so 4 & 4 will be 0 ( yup the right player whose turn it is now .)
        // After all for % operator , if left side % right side , left side is smaller than right side , then we get the left side back and if left side == right side
        // then we get 0. so this is absolutely perfect to keep the cycle going without affecting anything.

        Console.WriteLine (" Now the turn is of the player no : " + currentTurn ) ;
    }

    private static (int [] snakes , int [] ladders ) ApplySnakesAndLadders()
    {
        if ( cancelrequest) return ( Array.Empty<int>() , Array.Empty<int>() ) ; // To check for exit request

        // Now let's apply some snakes and ladders to the board for difficulty and fun
        // For that I will use a simple board of actual snake and ladders to create the snake and ladders

        // First things first since we are using index from 0 to 100 that means numbers are from 0 to 99 only
        // thus the number 99 of actual board is 98 here and so on

        // SO let me create a  new array called snake that will contain the snakes at the required index of the board
        // each of it's element will be set to the position the snake will send them back to on the board
        // mirroring the actual board , so let's say if the snake array has a value which is not 0 at index 98 , then that means 
        // there is a snake at index 98 of the board and the value that index 98 of the snake array contains will be
        // the new position the player will be transfered back to if they landed there

        int[] snakes = new int[100] ;
        // snakes[indexOfBoard] = newPosition ( which will be a decrement always from where they landed);
        snakes[98] = 4 ; // here 99 means 100 and 4 means 5 on actual board from 1 to 100
        snakes[94] = 74 ;
        snakes[91] = 35 ;
        snakes[88] = 52 ;
        snakes[73] = 11 ;
        snakes[63] = 49 ;
        snakes[61] = 18 ;
        snakes[48] = 10 ;
        snakes[15] = 5 ;

        // Now similarly we will create a ladders array and that will also be like snakes just that it will increment the players' position instead of decrementing it.
        // ladders[indexOfBoard] = newPosition ( which will be an increment always from where they landed);
        int[] ladders = new int[100] ;
        ladders[1] = 37 ;
        ladders[6] = 13 ;
        ladders[7] = 30 ; // here since we are -1 on index comapred to actual board so 7 means 8 and 30 means 31 on actual board
        ladders[14] = 25 ;
        ladders[20] = 41 ;
        ladders[27] = 83 ;
        ladders[35] = 43 ;
        ladders[50] = 66 ;
        ladders[70] = 90 ;

        displaysnakesandladders( snakes , ladders ) ;
        
        return ( snakes , ladders ) ;
    }

    private static void displaysnakesandladders ( int [] snakes , int [] ladders )
    {
        if ( cancelrequest ) return ; // To check for exit request

        // Now we will display the snakes and ladders that we created to the players as in actual game players can always see the snakes and ladders

        for ( int i = 0 ; i < 100 ; i++ ) // I mean we know as a matter of fact that length will be 100 that's why keeping it like this.
        {
            // As an int type array by default has 0 value at each indexes and thus we can check if the value is 0 or not to find the snakes and ladders placement
            if ( snakes [i] != 0 )
            {
                Console.WriteLine ( " Snake is at location : " + i + " and will send the player back to : " + snakes[i] ) ;
            }
            
            if (ladders [i] != 0)
            {
                Console.WriteLine ( " Ladder is at the locations : " + i + " and will send the player to : " + ladders[i] ) ;
            }
        }
    }

    private static void ListenForExit()
    {
        // This method is private and hence only accessible by the class itself and returns void as its only purpose is to check if player wants to quit
        // Thus it will run on different thread.
        while ( ! cancelrequest) // this will run as long as cacelRequest is false
        {
            var enteredKeystroke = Console.ReadKey().KeyChar.ToString().ToLower() ; // this is to check if the entered keystroke is "e" or not
            if  (  enteredKeystroke == "e")
            {
                cancelrequest = true ;
            }
        }
    }
}
