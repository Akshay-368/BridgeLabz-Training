<Query Kind="Program" />


public class Program {
public class Passenger{
 public int ID {get ; set ;}
 public int SeatNumber {get ; set;}  
 public int status {get ; set ;}  // status 0 means confirmed
}

public  class  Flight{
   public string FlightName {get ; set ;}
   public int totalSeats {get ; set ;}
   public List<string> Waitlist {get ; set ;} // if status is 1 then they are in waitlist
   // Passenger p {get ; set ;} // booked passenger
   public List<Passenger> Passengers {get ; set;} = new();
}
static Dictionary<int , Flight> flight = new(); // where key is the int which is FlightID and value is Flight itself

public static void Create() 
{
flight[1] = new Flight {
       FlightName = "AI-202",
    totalSeats = 5,
    Passengers = new List<Passenger>
    {
        new Passenger{ID=101,SeatNumber=2,status=0},
        new Passenger{ID=102,SeatNumber=1,status=0},
        new Passenger{ID=103,SeatNumber=0,status=1},
        new Passenger{ID=104,SeatNumber=0,status=1},
        new Passenger{ID=105,SeatNumber=3,status=0}
    }
};
}
public static void Print(int FlightID ){
    Flight f = new Flight();
	f = flight[FlightID] ;
	// Now the task is to print the passenger ID order by their status being confirmed . And then after that print the waitlist passenger ID's sorted by seat Number
	// Do it with linq
	
	var confirmedPassenger = f.Passengers.Where(v => v.status == 0 ).OrderBy(v => v.SeatNumber).Select(v => v.ID).ToList();
	confirmedPassenger.Dump();
	Console.WriteLine(confirmedPassenger.GetType()); // it has to be list<int>
	
  }
  
  public static void Main(){
    Create();
     Print(1);
	 /*
	 string s = "hoedoe@gmail.com";
	 var a = s.Split('@');
	 string ans = "****";
	 ans = ans + a[1];
	 Console.WriteLine(a);
	 */
  }

}
