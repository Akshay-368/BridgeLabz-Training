<Query Kind="Program" />

public class Program{

    public static void Main(){
	   int n = Convert.ToInt32(Console.ReadLine()) ; // number of times to runthe program or no. of test cases
	   for ( int i = 0 ; i < n ; i ++ ) {
	       string e = Console.ReadLine(); // email
	       bool ans = ValidateEmail(e);
	       if ( ans ) {
		      Console.WriteLine("Access Granted" );
		   }else {
		      Console.WriteLine("Access Denied");
		   }
	  }
	   
	   }
	   
	   public static bool ValidateEmail(string e ) {
	   
	      // format : FName+LName+digits@department.company.com
		  var nd = e.Split('@');
		  Regex regex = new Regex(@"^[a-z]{3,}\.[a-z]{3,}[0-9]{4,}$"); // for first part that comes before @
		  Regex regex2 = new Regex(@"(sales|marketing|IT|product)\.(company.com)"); // for the second part that comes after @
		  bool ans1 = regex.IsMatch(nd[0] ) ;
		  bool ans2 = regex2.IsMatch(nd[1]) ;
		  if ( ans1 != true || ans2 != true){
		     return false ;
		  }
		  return true; // the last case if everything else if valid adn not false
	   }
   
}