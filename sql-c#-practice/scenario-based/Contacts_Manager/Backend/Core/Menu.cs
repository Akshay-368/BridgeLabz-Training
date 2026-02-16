namespace Core;

using System;
using System.Threading.Tasks;
using interfaces;
using Utilities;

public class Menu : IMenu
{
    public async Task StartAsync()
    {
        int choice = -1;

        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║          CONTACTS MANAGER SYSTEM           ║");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();

                Console.WriteLine();

                // ─── Contact Management ──────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  Contact Management");
                Console.ResetColor();

                PrintMenuItem("Add New Contact",          "1", ConsoleColor.Green);
                PrintMenuItem("View All Contacts",        "2", ConsoleColor.Green);
                PrintMenuItem("Search Contact By Name",   "3", ConsoleColor.Green);
                PrintMenuItem("Update Contact",           "4", ConsoleColor.Green);
                PrintMenuItem("Delete Contact",           "5", ConsoleColor.Green);

                Console.WriteLine();

                // ─── VIP & Audit ─────────────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  VIP & Audit");
                Console.ResetColor();

                PrintMenuItem("Mark / Unmark VIP",        "6", ConsoleColor.Yellow);
                PrintMenuItem("View VIP Contacts",        "7", ConsoleColor.Yellow);
                PrintMenuItem("View Audit Logs",          "8", ConsoleColor.Yellow);

                Console.WriteLine();

                // ─── Location And Undo Delete Features ───────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  Location Features");
                Console.ResetColor();

                PrintMenuItem("Undo Delete Contact",           "9",  ConsoleColor.Magenta);
                PrintMenuItem("Search By Address",             "10", ConsoleColor.Magenta);
                PrintMenuItem("Total Contacts ",               "11", ConsoleColor.Magenta);

                Console.WriteLine();

                // ─── Sorting ─────────────────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  Sorting");
                Console.ResetColor();

                PrintMenuItem("Sort By Name",            "12", ConsoleColor.Blue);
                PrintMenuItem("Sort By City/State/Zip",  "13", ConsoleColor.Blue);

                Console.WriteLine();

                // ─── File Operations ─────────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  File Operations");
                Console.ResetColor();

                PrintMenuItem("Export (CSV/JSON/TXT)",   "14", ConsoleColor.DarkGreen);
                PrintMenuItem("Import (CSV/JSON/TXT)",   "15", ConsoleColor.DarkGreen);

                Console.WriteLine();

                // ─── Database ────────────────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  Database");
                Console.ResetColor();

                PrintMenuItem("Sync With Database",      "16", ConsoleColor.DarkYellow);
                PrintMenuItem("Load From Database",      "17", ConsoleColor.DarkYellow);

                Console.WriteLine();

                // ─── System ──────────────────────────────────────
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  System");
                Console.ResetColor();

                PrintMenuItem("Exit",                     "0", ConsoleColor.Red);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   Enter your choice: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim() ?? "";

                if (!int.TryParse(input, out  choice))
                {
                    throw new Exception("Invalid Input");
                }

                switch (choice)
                {
                    case 1:
                        await new AddContact().AddContactAsync();
                        break;

                    case 2:
                        await new ViewContacts().ViewContactsAsync();
                        break;

                    case 3:
                        await new SearchContact().SearchContactAsync();
                        break;

                    case 4:
                        await new UpdateContact().UpdateContactAsync();
                        break;

                    case 5:
                        await new DeleteContact().DeleteContactAsync();
                        break;

                    case 6:
                        await new MarkUnmarkVip().MarkUnmarkVipAsync();
                        break;

                    case 7:
                        await new ViewVipContacts().ViewVipContactsAsync();
                        break;

                    case 8:
                        await new ViewAuditLogs().ViewAuditLogsAsync();
                        break;

                    case 9:
                        await new UndoDelete().UndoDeleteAsync();
                        break;

                    case 10:
                        await new SearchByAddress().SearchByAddressAsync();
                        break;

                    case 11:
                         await new CountContacts().CountAsync();
                        break;

                    case 12:
                        await new SortByName().SortAsync();
                        break;

                    case 13:
                        await new SortByLocation().SortAsync();
                        break;

                    case 14:
                        await new ExportData().ExportDataAsync();
                        break;

                    case 15:
                        await new ImportData().ImportDataAsync();
                        break;

                    case 16:
                        await new SyncDatabase().SyncAsync();
                        break;

                    case 17:
                        await new LoadFromDatabase().LoadAsync();
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n  Exiting Application... Goodbye ");
                        Console.ResetColor();
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n  Invalid Option. Try Again.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey(true);

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  Invalid input. Please enter a number.");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey(true);
            }

        } while (true);   // changed from choice != 0 → more common pattern with return inside
            }

    private static void PrintMenuItem(string text, string number, ConsoleColor color)
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("  [");
    Console.ForegroundColor = color;
    Console.Write(number.PadLeft(2));
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("] ");
    Console.ResetColor();
    Console.WriteLine(text);
}
}
