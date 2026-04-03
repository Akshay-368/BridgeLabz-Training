// File: AddrBk.cs

// This is the concrete class extending AbsAddrBk. It provides specific implementations for save methods. For now, dummy, but can be extended. Uses threads for IO as per requirement. This follows inheritance and polymorphism. For loose coupling, we can swap child classes. Extensible by adding more children for different storages.

public class AddrBk : AbsAddrBk
{
    public override void SvToFl(string bkNm)
    {
        // Dummy save to file, use thread
        Thread t = new Thread(() => 
        {
            // Simulate file write
            Console.WriteLine("Saving to file...");
            // In real, use FileStream, but verbose
            using (StreamWriter sw = new StreamWriter("addrbk.txt", true))
            {
                int idx = FndBkIdx(bkNm);
                for (int j=0; j<cntcts[idx].Length; j++)
                {
                    if (cntcts[idx][j].fn != null)
                        sw.WriteLine(cntcts[idx][j].ToString());
                }
            }
        });
        t.Start();
        t.Join(); // Wait, but threaded
    }

    public override void SvToDb(string bkNm)
    {
        // Dummy, assume SQL, threaded
        Thread t = new Thread(() => 
        {
            Console.WriteLine("Saving to DB...");
            // Real code would use SqlConnection, but no advance stuff for now , out of the concepts learnt so far
        });
        t.Start();
        t.Join();
    }

    public override void SvToCld(string bkNm)
    {
        // Dummy network call, threaded
        Thread t = new Thread(() => 
        {
            Console.WriteLine("Saving to cloud...");
            // Simulate network
        });
        t.Start();
        t.Join();
    }
}
