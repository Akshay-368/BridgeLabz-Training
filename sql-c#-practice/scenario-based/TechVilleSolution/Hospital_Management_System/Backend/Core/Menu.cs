using System;
using Interfaces;
using Exceptions;
using Services;
using Utilities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace Core
{
    internal static class Menu
    {
        internal static int ShowRoleMenu()
        {
            Console.WriteLine("Select your role:");
            Console.WriteLine("1) Doctor");
            Console.WriteLine("2) Patient");
            Console.WriteLine("3) Nurse");
            Console.WriteLine("Enter role number:");

            return int.Parse(Console.ReadLine()!);
        }
    }


}
