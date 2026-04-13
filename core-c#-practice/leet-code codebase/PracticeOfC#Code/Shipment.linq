<Query Kind="Program" />

using System;
using System.Globalization ;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq ;
class Program {

  public static void Main () {
     int n = Convert.ToInt32 ( Console.ReadLine());
	 for ( int i = 0 ; i < n ; i ++ ){
	    string s = Console.ReadLine();
		var parts = s.Split('|');
		var ship = parts[0] ;
		var date = parts[1];
		var mode = parts[2];
		var w= parts[3];
		var status = parts[4];
		if ( ValidDate(date) && ValidStatus(status ) && ValidMode(mode) &&ValidShip(ship) && validweight(w)) {
		    Console.WriteLine("COMPLIANT RECORD");
		}else {
		    Console.WriteLine("NON-COMPLIANT RECORD");
		  }
	  }
    
  }
   
   public static bool ValidDate(string s ) {
      string[] formats = {"yyyy-MM-dd"}; // for just in case if in future the formats can be more than one
	  bool validDate = DateTime.TryParseExact(s , formats , CultureInfo.InvariantCulture , DateTimeStyles.None , out DateTime confirmedDate);
	  // This alone can handle the following 
	  /*
	  Format YYYY-MM-DD	Yes	As long as your formats array contains "yyyy-MM-dd".
      Month Validation	Yes	It won't allow month 13 or month 0.
      30/31 Day Months	Yes	It will reject 2026-06-31 (June has 30 days).
      Leap Year Logic	Yes	It knows 2024-02-29 is valid but 2025-02-29 is not.
	  */
	  // The overload for this exact method is this 
	  // DateTime.TryParseExact ( string , string[] , IFormatProvider , DateTimeStyles , out DateTime )
	  // For making sure it is between 2000 to 2099 only
	  bool valid = validDate && confirmedDate.Year >= 2000 && confirmedDate.Year <= 2099;
	  return valid ;
   }
   
   public static bool ValidStatus (string s ) {
   
       string pattern = @"^(DELIVERED|CANCELLED|IN_TRANSIT)$";
	   bool ans = Regex.IsMatch(s , pattern ) ;
	   return ans ;
   }
   
   public static bool ValidMode(string s) {
      string pattern = @"^(AIR|SEA|ROAD|EXPRESS|FREIGHT)$";
	  bool ans = Regex.IsMatch(s , pattern ) ;
	  return ans ;
   }
   
   public static bool ValidShip(string s ) {
      var subparts = s.Split('-');
	  string pattern = @"^SHIP$";
	  string a = subparts[0] ;
	  string b = subparts[1] ;
	  bool ans1 = Regex.IsMatch(a , pattern ) ;
	  string p = @"^[1-9]{1}[0-9]{5}$";
	  // For basic check if the length is 6 and no leading 0
	  bool ans2 = Regex.IsMatch(b , p ) ;
	  bool ans3 = helpership(b) ;
	  bool result = ans1 && ans2 && ans3 ;
	  
	  return result ;
	  
	  
	  
   }
   
   public static bool helpership(string b ) {
        
	  int count = 1; 
	  for ( int i = 1 ; i < b.Length ; i ++ ) {
	      if (b[i] == b[i-1] ) {
		     count ++ ;
			 if ( count > 3 ) return false ;// more than 3 repeation consecutively
		  }else {
		     count = 1; // reset if the streak is broken
		  }
	  
	  }
	  return true ;
	    
   }
   
   public static bool validweight(string s) {
      if ( s.Length > 1 && s.StartsWith("0") && !s.StartsWith("0.")){
	     return false ;
	  }
	  // parsing string to a decimal 
	  if ( !decimal.TryParse (s , out decimal d ) ) {
	       return false ; //not a valid number at all
	    }
	  
	  // value must be postive 
	  if ( d < 0 ) return false ;
	  
	  // Maximum allowed value is 999999.99
	  if ( d > 999999.99m ) return false ;
	  
	  // up to  2 decimal places allowed
	  // we cam check that by multiplying with 100 if it leaves any remainder or more numbers
	  if ( ( d * 100 )% 1 != 0 ) {
	     return false ;
	  }
	  
	  return true ;
   }
   
}