using System;
using System.Reflection.Metadata.Ecma335;
namespace Sentence_Formatter ;

/*
Strings – Sentence Formatter
1. Scenario: A text editing tool receives poorly formatted input from users. Your task is to auto-correct
formatting by fixing spacing and capitalizing the first letter of each sentence.
Problem:
Write a method that takes a paragraph as input and returns a corrected version with:
● One space after punctuation,
● Capital letter after period/question/exclamation marks,
● Trimmed extra spaces.
Don't use any in-built string function to solve the problem scenarios . Try to create your own functions which will replicate the functionalities of the built-in's.
*/

public static class SentenceFormatter
{
    private static string paragraph ; // making it a field as a private staticso that it can be used by other processes without tossing it around
    // and also so that any change made in paragraph can be directly reflected to it in the whole program

    public static void  Run()
    {
        // First going to take user input for the program;
        Console.WriteLine(" Please enter the paragraph that you want to edit : " ) ;
        string input = Console.ReadLine() ;
        Console.WriteLine  ( " Please pay attention if the paragraph entered is empty then the default version will be used . So please make sure to enter your own.");
        paragraph = string.IsNullOrWhiteSpace(input) ? "simple        paragraph,to demonstrate the     program.please      don't!      rely    on   it    completely." : input ; // To check if the input paragraph is null or empty string

        // Now calling the trim function
        Trim_paragraph() ;

        // Now calling the Capitlize function
        Capitllize_paragraph() ;


        Console.WriteLine( " The paragraph you entered is : " + paragraph ) ;
        Console.WriteLine (" Now please wait while the process is running and auto-correcting it ... ");
        Console.WriteLine ( " The corrected paragraph is : " + paragraph ) ;

    }

    private static void Trim_paragraph()
    {
        if ( paragraph == null || paragraph == "" ) return ;// making sure we don't end up geting an empty string as an input from the user 
        // Though that would not be the case , but still placing it here just in case if i in future have to remove the default string from the paragraph 
        // as in that case i could actually get an empty string to  be ppassed in paragraph which would not make any sense .
        // Thus just future-proofing myself.

        // For trimming extra space. ( multiple spaces  will be reduced to single space and trailing spaces will be removed )

        // Now we are going to make a trim function for the given paragraph which we can execute and we will not be using any
        // built in function as we are constraint againt using it.
        string clean = "" ; // creating a string to store the clean paragraph and then update it in main paragrapph
        bool lastSpace = false ;
        // This bool here is to just keep track of if I just added a space ? if yes and i am seeing another space then just skip it as it is extra 
        // space and not needed at all.
        // if no , then it is safe to add one .
        // For example in the string "    hello   world" , here if we traverse through it and end up seeing a space then lastSpace will get true and
        // if it is true that means now we can just skip ahead
        // until we reach h and add it to our new clean string and then lastSpace will be false , as that means we did not just add a space but since
        // we are not dealing with a c = ' ' character thus we will simply go on to add it to our new clean string , while keeping lastSpace false as
        // we would have added a character which is not space

    // First we will just focus on removing multiple spaces and just skip any leadig spaces.
    foreach (char c in paragraph)
    {
        if (c == ' ')
        {
            // We are dealing with a space
            if (clean.Length > 0 && ! lastSpace )  // Only add space if not leading and not duplicating
            {
                // as we are checking the length of clean to make sure we are not just starting our new clean string with a space , as we have to remove leading spaces , not add them
                clean += ' '; // we are only adding one space if we have not seen a space and the char c is a space and then since wwe added a space we will
                // simply make the lastSpace true as we just added space to make sure to not end up adding extra spaces
            }
            lastSpace = true;
            // Basically we are adding space only if we are seeing a space from the main input paragraph string and if we have not added one space before ( that is lastSpace is false and hence !lastSpace is ture)
        }
        else
        {
            // Yay , this means we are not dealing with a space and can jsut simply add the character to the clean string of ours
            // annd make the lastSpace false as we would have just added a char instead of space last in the string
            clean += c ;
            lastSpace = false ;
        }
    }

    // Now we will  remove the  trailing space if any exists at all
    // as we in our original loop end up adding exactly one of the trailing spaces at our clean string
    // and we need to remove that last space as well from the string .
    // so main stuff that we can do is to striaght up remove the last character from the string clean, while making sure it's length is not zero as otherwise
    // if we end up using clean.Length - 1 which will throw an exception, because we can't remove any character from it's length as it's already zero or null or empty
    if ( clean.Length > 0 && clean [ clean.Length - 1 ] == ' ' )
    {
        clean = clean.Substring ( 0 , clean.Length - 1);
        // substring will just simply take all the characters from the starting index to last index we mentioned and return it as a string from our given string with the help of '.' operator
        // as Substring belongs to every instance of the class string.
    }

    // Now we will update the original static paragraph field directly to reflect the changes we make
    paragraph = clean;
    return ;

    }

    private static void Capitllize_paragraph()
    {
        // This method will captilize the first letter of every word in the paragraph string
        // and then update the original paragraph field directly to reflect the changes we make
        // without using ToUpper () method of the strings class
        // SO first i am planning to go through the paragraph for each character and if it's  a non space chaarcter then we will have to see if the previous character is a punctuation mark like - , , ? , ! .
        // if yes then i will simply make that character capitalize

        if ( paragraph == null || paragraph == "" )  return ;// making sure we don't end up geting an empty string as an input from the user 
        // Though that would not be the case , but still placing it here just in case if i in future have to remove the default string from the paragraph 
        // as in that case i could actually get an empty string to  be ppassed in paragraph which would not make any sense .
        // Thus just future-proofing myself.

        bool lastPunctuation = true ; // to track if the last character was a punctuation mark.
        string clean = "" ;
        foreach ( char c in paragraph)
        {
                if ( c != ' ' && lastPunctuation == true)
                {
                    // we know first character can't be a space as this function gets called after trim function
                    // Thus no leading spaces
                    clean += ' ' ; // because we have run trim function already to remove extra duplicate spaces and thus we can simply now check if after punctuation if the next character is a space or not ,
                    lastPunctuation = false; // adding that extra space

                }

                // We are dealing with a non space character
                if ( lastPunctuation && c >= 'a' && c <= 'z')
                {
                    // This means we just added a punctuation mark lastly in the cleans string
                    // We are dealing with a punctuation mark as the questions says we need to add a space after punctuation
                    // instead of doing it this way since we can't use built-ins : clean  += ' ' + char.ToUpper ( c ) ;
                    clean  = clean + (char)( c - 32 ) ; // to convert the lower case character to upper case by using ASCII conversions
                    lastPunctuation = false ;
                }
                else if ( lastPunctuation && c >= 'A' && c <= 'Z')
                {
                    clean = clean +  c ; // we can just directly add it in our clean string
                    lastPunctuation = false ;
                }else
                {
                    clean += c ; // it could be a number, punctuation at start — just adding it without any questions and
                    if ( c == '.' || c == '?' || c == '!'  )
                    {
                        // We are dealing with a punctuation mark
                        
                        lastPunctuation = true ;
                    }
                    
            }
        }

        // Now we will update the original static paragraph field directly to reflect the changes we make
        paragraph = clean;
        return ;
    }
}