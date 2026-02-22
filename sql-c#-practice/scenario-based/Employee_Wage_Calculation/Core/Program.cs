
// See https://aka.ms/new-console-template for more information
namespace Core ;
using Utilities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static async Task Main (string[] args)
    {
        // Menu menu = new Menu();
        IMenu menu = Factory<IMenu, Menu>.Create();
        await menu.StartAsync();
    }
}

