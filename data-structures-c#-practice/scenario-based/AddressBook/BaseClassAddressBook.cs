// File: AbsAddrBk.cs

// This is the abstract base class that implements the IAddrBk interface. It provides common implementations for methods that can be shared across different types of address books. For example, basic add, edit, delete logic using arrays since we can't use collections. This follows OOP with abstraction and inheritance. Common stuff like checking duplicates is here, and specific storage like file or db can be overridden in child classes. Encapsulation is used with private fields for data hiding. Polymorphism via override. For SOLID: Single Responsibility - this handles core logic; Open/Closed - extend via child classes without changing this; Liskov - child can substitute; etc. DRY by putting common code here.

public abstract class AbsAddrBk : IAddrBk
{
    private string[] bkNms = new string[10]; // Array for book names, initial size 10, we can resize if needed
    private Cntct[][] cntcts = new Cntct[10][]; // Array of arrays for contacts per book
    private int bkCnt = 0; // Count of books

    // Constructor, but since all static, maybe not used, but for OOP
    public AbsAddrBk()
    {
        for (int i=0; i<10; i++)
        {
            cntcts [ i ] = new Cntct [ 20 ] ; // Each book can have up to 20 contacts initially
        }
    }

    public void AddCntct(string bkNm, Cntct cnt)
    {
        // Find the book index
        int idx = FndBkIdx ( bkNm ) ;
        if ( idx == -1 )
        {
            Console.WriteLine ( "Book not found." ) ;
            return;
        }
        // Add to the contacts array, find empty slot
        for (int j=0; j<cntcts[idx].Length; j++ )
        {
            if ( cntcts [ idx ] [ j ] . fn == null ) // Check if empty
            {
                cntcts [ idx ] [ j ] = cnt ;
                Console . WriteLine ( "Contact added." ) ;
                return ;
            }
        }
        Console.WriteLine("Book full, can't add."); 
    }

    public void EdtCntct(string bkNm, string frstNm, string lstNm)
    {
        int bkIdx = FndBkIdx(bkNm);
        if (bkIdx == -1) return;
        for (int j=0; j<cntcts[bkIdx].Length; j++)
        {
            if (cntcts[bkIdx][j].fn == frstNm && cntcts[bkIdx][j].ln == lstNm)
            {
                // Edit, ask user for new values
                cntcts[bkIdx][j] = GtCntctDtls(); // Reuse method, DRY
                Console.WriteLine("Contact edited.");
                return;
            }
        }
        Console.WriteLine("Not found.");
    }

    public void DelCntct(string bkNm, string frstNm, string lstNm)
    {
        int bkIdx = FndBkIdx(bkNm);
        if (bkIdx == -1) return;
        for (int j=0; j<cntcts[bkIdx].Length; j++)
        {
            if (cntcts[bkIdx][j].fn == frstNm && cntcts[bkIdx][j].ln == lstNm)
            {
                cntcts[bkIdx][j] = new Cntct(); // Reset to default
                Console.WriteLine("Deleted.");
                return;
            }
        }
    }

    public void AddMltiCntcts(string bkNm)
    {
        // Add multiple, loop until user says stop
        while (true)
        {
            Console.WriteLine("Add contact? y/n");
            string ans = Console.ReadLine();
            if (ans == "n") break;
            Cntct c = GtCntctDtls();
            if (!ChkDupl(bkNm, c.fn, c.ln))
                AddCntct(bkNm, c);
            else
                Console.WriteLine("Duplicate, skipped.");
        }
    }

    public void AddNwBk(string bkNm)
    {
        // Check if exists
        for (int i=0; i<bkCnt; i++)
        {
            if (bkNms[i] == bkNm) return; // Already exists, redundant check
        }
        bkNms[bkCnt] = bkNm;
        bkCnt++;
        // Resize if needed, but for now assume <10
    }

    public bool ChkDupl(string bkNm, string frstNm, string lstNm)
    {
        int idx = FndBkIdx(bkNm);
        if (idx == -1) return false;
        for (int j=0; j<cntcts[idx].Length; j++)
        {
            if (cntcts[idx][j].fn == frstNm && cntcts[idx][j].ln == lstNm)
                return true;
        }
        return false;
    }

    public void SrchPrsnInCtyOrSt(string ctyOrSt)
    {
        // Search across all books
        for (int i=0; i<bkCnt; i++)
        {
            for (int j=0; j<cntcts[i].Length; j++)
            {
                if (cntcts[i][j].cty == ctyOrSt || cntcts[i][j].st == ctyOrSt)
                {
                    PrntCntct(cntcts[i][j]);
                }
            }
        }
    }

    public void VwPrsnsByCtyOrSt()
    {
        // Similar to search, but group by city/state
        Console.WriteLine("Enter city or state:");
        string val = Console.ReadLine();
        SrchPrsnInCtyOrSt(val); // Reuse, DRY
    }

    public int CntByCtyOrSt(string ctyOrSt)
    {
        int cnt = 0;
        for (int i=0; i<bkCnt; i++)
        {
            for (int j=0; j<cntcts[i].Length; j++)
            {
                if (cntcts[i][j].cty == ctyOrSt || cntcts[i][j].st == ctyOrSt)
                    cnt++;
            }
        }
        return cnt;
    }

    public void SrtByNm(string bkNm)
    {
        int idx = FndBkIdx(bkNm);
        if (idx == -1) return;
        // Sort the array using bubble sort, 
        for (int k=0; k<cntcts[idx].Length -1; k++)
        {
            for (int l=0; l<cntcts[idx].Length - k -1; l++)
            {
                if (string.Compare(cntcts[idx][l].fn + cntcts[idx][l].ln, cntcts[idx][l+1].fn + cntcts[idx][l+1].ln) > 0)
                {
                    Cntct tmp = cntcts[idx][l];
                    cntcts[idx][l] = cntcts[idx][l+1];
                    cntcts[idx][l+1] = tmp;
                }
            }
        }
    }

    protected int FndBkIdx(string bkNm)
    {
        for (int i=0; i<bkCnt; i++ )
        {
            if ( bkNms [ i ] == bkNm ) return i ;
        }
        return -1;
    }

    protected Cntct GtCntctDtls()
    {
        Cntct c = new Cntct();
        // Ask for each, with defaults if empty
        Console.WriteLine("First name:");
        c.fn = Console.ReadLine() ?? "default_fn";
        Console.WriteLine("Last name:");
        c.ln = Console.ReadLine() ?? "default_ln";
        Console.WriteLine("Address:");
        c.addr = Console.ReadLine() ?? "default_addr";
        Console.WriteLine("City:");
        c.cty = Console.ReadLine() ?? "default_cty";
        Console.WriteLine("State:");
        c.st = Console.ReadLine() ?? "default_st";
        Console.WriteLine("Zip:");
        c.zp = Console.ReadLine() ?? "00000";
        Console.WriteLine("Phone:");
        c.ph = Console.ReadLine() ?? "000-000-0000";
        Console.WriteLine("Email:");
        c.em = Console.ReadLine() ?? "default@email.com";
        return c;
    }

    protected void PrntCntct(Cntct c)
    {
        Console.WriteLine($"Name: {c.fn} {c.ln}, Addr: {c.addr}, City: {c.cty}, State: {c.st}, Zip: {c.zp}, Phone: {c.ph}, Email: {c.em}");
    }

    // Abstract methods for child to implement, like save to file, db, cloud
    public abstract void SvToFl(string bkNm); // Save to file
    public abstract void SvToDb(string bkNm); // To database
    public abstract void SvToCld(string bkNm); // To cloud
    // For multi-threading, child can override to use threads for IO
}
