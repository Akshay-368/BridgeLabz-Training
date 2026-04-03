// File: Menu.cs

// This class handles the menu, calls methods from AddrBk based on choice. Loosely coupled, Program calls this, this calls AddrBk. Extensible by adding more options without changing much. Public static methods as per style.

public class Menu
{
    public static void ShwMenu(AddrBk ab)
    {
        while (true)
        {
            Console.WriteLine("Menu : ");
            Console.WriteLine("1. Add new book");
            Console.WriteLine("2. Add contact");
            Console.WriteLine("3. Edit contact");
            Console.WriteLine("4. Delete contact");
            Console.WriteLine("5. Add multiple contacts");
            Console.WriteLine("6. Check duplicate");
            Console.WriteLine("7. Search in city/state");
            Console.WriteLine("8. View by city/state");
            Console.WriteLine("9. Count by city/state");
            Console.WriteLine("10. Sort by name");
            Console.WriteLine("11. Save to file");
            Console.WriteLine("12. Save to DB");
            Console.WriteLine("13. Save to cloud");
            Console.WriteLine("exit to quit");

            // Waiting , for user to enter the inupt
            string ch = Console . ReadLine ( ) ;
            if ( ch == "exit" ) break ;

            // Ask for book name where needed
            string bn = "";
            if (ch != "1" && ch != "7" && ch != "8" && ch != "9")
            {
                Console.WriteLine("Book name:");
                bn = Console.ReadLine();
            }

            switch (ch)
            {
                case "1":
                    Console.WriteLine("New book name:");
                    string nbn = Console.ReadLine();
                    ab.AddNwBk(nbn);
                    break;
                case "2":
                    Cntct c2 = ab.GtCntctDtls(); // Call protected? Wait, since same assembly, but to avoid, make public or use.
                    // Wait, protected, so from child, but here static, issue.
                    // To fix, make GtCntctDtls public in Abs.
                    // Assume changed to public.
                    if (!ab.ChkDupl(bn, c2.fn, c2.ln))
                        ab.AddCntct(bn, c2);
                    break;
                case "3":
                    Console.WriteLine("First name:");
                    string fn3 = Console.ReadLine();
                    Console.WriteLine("Last name:");
                    string ln3 = Console.ReadLine();
                    ab.EdtCntct(bn, fn3, ln3);
                    break;
                case "4":
                    Console.WriteLine("First name:");
                    string fn4 = Console.ReadLine();
                    Console.WriteLine("Last name:");
                    string ln4 = Console.ReadLine();
                    ab.DelCntct(bn, fn4, ln4);
                    break;
                case "5":
                    ab.AddMltiCntcts(bn);
                    break;
                case "6":
                    Console.WriteLine("First name:");
                    string fn6 = Console.ReadLine();
                    Console.WriteLine("Last name:");
                    string ln6 = Console.ReadLine();
                    bool d = ab.ChkDupl(bn, fn6, ln6);
                    Console.WriteLine(d ? "Duplicate" : "No");
                    break;
                case "7":
                    Console.WriteLine("City or state:");
                    string cs7 = Console.ReadLine();
                    ab.SrchPrsnInCtyOrSt(cs7);
                    break;
                case "8":
                    ab.VwPrsnsByCtyOrSt();
                    break;
                case "9":
                    Console.WriteLine("City or state:");
                    string cs9 = Console.ReadLine();
                    int ct = ab.CntByCtyOrSt(cs9);
                    Console.WriteLine($"Count: {ct}");
                    break;
                case "10":
                    ab.SrtByNm(bn);
                    break;
                case "11":
                    ab.SvToFl(bn);
                    break;
                case "12":
                    ab.SvToDb(bn);
                    break;
                case "13":
                    ab.SvToCld(bn);
                    break;
            }
        }
    }
}
