namespace Utilities ;
using System;
using System.Collections.Generic;
using System.Text.Json;

public static class DumpExtensions
{
    /// <summary>
    /// This is the method that does the actual work
    /// Method inspired by the LINQPad's signature method that I got the itch to have in my own code.
    /// But since it is unique to LINQPad only , so i created my own mini version of the Dump() method
    /// It takes a generic type and returns the same type and can peek into the object and display it nicely in the console
    /// Similar to the Dump() method in LINQPad
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static T Dump<T> ( this T obj , string message = null)
    {
        if ( ! string.IsNullOrEmpty ( message ) ) Console.WriteLine($"{message}");
        if ( obj is string ) { Console.WriteLine(obj); return obj ; }
        var options = new JsonSerializerOptions {WriteIndented = true  , IncludeFields = true };
        Console.WriteLine ( JsonSerializer.Serialize (obj , options )); // here this serialize returns a json string for the obj with the formatting of the options provided.
        return obj;
    }
}
// Returning the obj even allows me to actually do the chanining of the methods.