using System;

public class soc 
{
    // node for user
    public struct us 
    {
        public int uid;
        public string nam;
        public int age;
        public int[] frnd; // array of friend ids , fixed size for simplicty
        public int fc; // friend count

        public us nxt;
    }

    public static us hed = null;

    // find user by id , return node
    public static us fndId(int id) 
    {
        us tmp = hed;
        while(tmp.nxt != null || tmp.uid == id) // stop if found or end
        {
            if(tmp.uid == id) return tmp;
            if(tmp.nxt == null) break;
            tmp = tmp.nxt;
        }
        if(tmp.uid == id) return tmp;
        return new us(); // empty if not found
    }

    public static void adUsr(int id,string n,int ag) 
    {
        us nw = new us();
        nw.uid = id;
        nw.nam = n;
        nw.age = ag;
        nw.frnd = new int[50]; // max 50 friends , simple
        nw.fc = 0;
        nw.nxt = null;

        if(hed == null)
        {
            hed = nw;
            return;
        }

        us tmp = hed;
        while(tmp.nxt != null)
        {
            tmp = tmp.nxt;
        }
        tmp.nxt = nw;
        // added new user at end
    }

    public static void adFrnd(int u1,int u2) 
    {
        us user1 = fndId(u1);
        us user2 = fndId(u2);

        if(user1.uid == 0 || user2.uid == 0)
        {
            Console.WriteLine("one or both users not found");
            return;
        }

        // add u2 to u1 friends
        if(user1.fc < 50)
        {
            user1.frnd[user1.fc] = u2;
            user1.fc++;
        }

        // add u1 to u2 friends , mutual
        if(user2.fc < 50)
        {
            user2.frnd[user2.fc] = u1;
            user2.fc++;
        }

        Console.WriteLine("friend connection added between "+u1+" and "+u2);
    }

    public static void remFrnd(int u1,int u2) 
    {
        us user1 = fndId(u1);
        us user2 = fndId(u2);

        if(user1.uid == 0 || user2.uid == 0)
        {
            Console.WriteLine("user not found cant remove");
            return;
        }

        // remove u2 from u1 list
        for(int i=0; i<user1.fc; i++)
        {
            if(user1.frnd[i] == u2)
            {
                user1.frnd[i] = user1.frnd[user1.fc-1];
                user1.fc--;
                break;
            }
        }

        // remove u1 from u2 list
        for(int i=0; i<user2.fc; i++)
        {
            if(user2.frnd[i] == u1)
            {
                user2.frnd[i] = user2.frnd[user2.fc-1];
                user2.fc--;
                break;
            }
        }

        Console.WriteLine("friend connection removed");
    }

    public static void mutFrnd(int u1,int u2) 
    {
        us user1 = fndId(u1);
        us user2 = fndId(u2);

        if(user1.uid == 0 || user2.uid == 0)
        {
            Console.WriteLine("users not found");
            return;
        }

        Console.WriteLine("Mutual friends:");
        bool has = false;
        for(int i=0; i<user1.fc; i++)
        {
            int fid = user1.frnd[i];
            if(fid == u2 || fid == u1) continue; // skip self

            for(int j=0; j<user2.fc; j++)
            {
                if(user2.frnd[j] == fid)
                {
                    Console.WriteLine("User ID: "+fid);
                    has = true;
                    break;
                }
            }
        }

        if(!has) Console.WriteLine("no mutual friends");
    }

    public static void disFrnd(int uid) 
    {
        us user = fndId(uid);
        if(user.uid == 0)
        {
            Console.WriteLine("user not found");
            return;
        }

        Console.WriteLine("Friends of "+user.nam+" (ID "+uid+"): ");
        if(user.fc == 0)
        {
            Console.WriteLine("no friends yet");
            return;
        }

        for(int i=0; i<user.fc; i++)
        {
            us fr = fndId(user.frnd[i]);
            if(fr.uid != 0)
                Console.WriteLine("ID: "+fr.uid+" Name: "+fr.nam);
            else
                Console.WriteLine("ID: "+user.frnd[i]+" (name not loaded)");
        }
    }

    public static void srchNam(string sn) 
    {
        us tmp = hed;
        bool fnd = false;
        Console.WriteLine("Users with name containing \""+sn+"\":");
        while(tmp.nxt != null || tmp.nam != null)
        {
            if(tmp.nam.ToLower().Contains(sn.ToLower()))
            {
                Console.WriteLine("ID: "+tmp.uid+" Name: "+tmp.nam+" Age: "+tmp.age);
                fnd = true;
            }
            if(tmp.nxt == null) break;
            tmp = tmp.nxt;
        }
        if(!fnd) Console.WriteLine("no user found");
    }

    public static void srchId(int sid) 
    {
        us user = fndId(sid);
        if(user.uid == 0)
        {
            Console.WriteLine("user not found");
            return;
        }
        Console.WriteLine("Found: ID "+user.uid+" Name "+user.nam+" Age "+user.age+" Friends count: "+user.fc);
    }

    public static void cntAll() 
    {
        if(hed == null)
        {
            Console.WriteLine("no users yet");
            return;
        }

        Console.WriteLine("Friend count for each user:");
        us tmp = hed;
        while(tmp.nxt != null || tmp.uid != 0)
        {
            Console.WriteLine("User "+tmp.nam+" (ID "+tmp.uid+") has "+tmp.fc+" friends");
            if(tmp.nxt == null) break;
            tmp = tmp.nxt;
        }
    }

    public static void Main(string[] args) 
    {
        /*
        7. Singly Linked List: Social Media Friend Connections
        Problem Statement: Create a system to manage social media friend connections using a singly linked list. Each node represents a user with User ID, Name, Age, and List of Friend IDs. Implement the following operations:

        * Add a friend connection between two users.

        * Remove a friend connection.

        * Find mutual friends between two users.

        * Display all friends of a specific user.

        * Search for a user by Name or User ID.

        * Count the number of friends for each user.
        */

        // first add some users manually for testing , or let user add
        adUsr(1,"raj",23);
        adUsr(2,"priya",21);
        adUsr(3,"amit",25);
        adUsr(4,"neha",22);
        adUsr(5,"vikas",24);

        int ch = 0;
        while(ch != 9)
        {
            Console.WriteLine("\nSocial Media Menu:");
            Console.WriteLine("1 Add friend connection");
            Console.WriteLine("2 Remove friend connection");
            Console.WriteLine("3 Find mutual friends");
            Console.WriteLine("4 Print friends of user");
            Console.WriteLine("5 Search user by name");
            Console.WriteLine("6 Search user by ID");
            Console.WriteLine("7 Print friend count all");
            Console.WriteLine("8 Add new user (for testing)");
            Console.WriteLine("9 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter first user id : ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second user id : ");
                int b = Convert.ToInt32(Console.ReadLine());
                adFrnd(a,b);
            }
            else if(ch == 2)
            {
                Console.Write("Enter first user id : ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second user id : ");
                int b = Convert.ToInt32(Console.ReadLine());
                remFrnd(a,b);
            }
            else if(ch == 3)
            {
                Console.Write("Enter first user id : ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second user id : ");
                int b = Convert.ToInt32(Console.ReadLine());
                mutFrnd(a,b);
            }
            else if(ch == 4)
            {
                Console.Write("Enter user id : ");
                int u = Convert.ToInt32(Console.ReadLine());
                disFrnd(u);
            }
            else if(ch == 5)
            {
                Console.Write("Enter name to search : ");
                string sn = Console.ReadLine();
                srchNam(sn);
            }
            else if(ch == 6)
            {
                Console.Write("Enter user id : ");
                int si = Convert.ToInt32(Console.ReadLine());
                srchId(si);
            }
            else if(ch == 7)
            {
                cntAll();
            }
            else if(ch == 8)
            {
                Console.Write("Enter new user id : ");
                int ni = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter name : ");
                string nn = Console.ReadLine();
                Console.Write("Enter age : ");
                int na = Convert.ToInt32(Console.ReadLine());
                adUsr(ni,nn,na);
            }
        }
    }
}
