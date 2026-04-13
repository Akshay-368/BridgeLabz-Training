<Query Kind="Program" />

using System.Text;
using System.Text.RegularExpressions;
public class Program {

   public static void Main() {
     int n = Convert.ToInt32(Console.ReadLine());
	 for (int i = 0 ; i < n ; i ++ ) {
	    string s = Console.ReadLine(); // to be validated and then transform
		if (smalllength(s) || ContainsSpace(s) || ContainsNum(s)|| ContainsSpecial(s) ) {
		      continue;
		}else {
		    // Convert string to lowercase
			string sl = s.ToLower() ;
			
			// Remove all even ascii characters
			string sn = Rascii(sl) ; // the only case where string can get null as this is the only one to involves removal
			if (empty(sn)) break ;
			string sn1 = reverse(sn) ;
			string ans = Upe(sn1) ;
			Console.WriteLine($"The generated key is - {ans}");
		}
		
	  }
   }
   
      public static bool smalllength(string s ) {
	  // string length mustbe greater than or equal to 6
	       if (s.Length < 6 ) {
		       Console.WriteLine("Invalid Input (length < 6)");
		       return true ; // length is less than 6 , so yes it's true that length is small
			}
			return false ; 
	  }
	  
	  public static bool Alphabets(string s ) {
	       
		   foreach ( char c in s ) {
		      if ( (c < 'a' && c > 'z' ) || ( c < 'A' && c > 'Z') ) {
			      return false ;  // means it is not a letter
			  } 
		   }
		  
		 return true ; // the last case after all the false conditions to reject the string has been rejected and thus the string is indeed only consists of alphabets
	  }
	  
	  public static bool ContainsSpace (string s ) {
	  
	         string pattern = @"\s"; // character for any kind of space , newline , whiteline , whatever
			 bool ans =  Regex.IsMatch(s , pattern) ;
			 if ( ans  ){
			  // Contains space
			  Console.WriteLine("Invalid Input (contains space)");
			  return true ;
			 }
			 return false ; // doesn't contain space
			 
	  
	  }
	  
	  public static bool ContainsNum (string s ) {
	     Regex r = new Regex (@"\d"); // does anywhere there is some number
		 bool ans = r.IsMatch(s ) ;
		 if ( ans ){
		  // This means true
		  Console.WriteLine ("Invalid Input (contains digits)");
		  return ans;
		 }
		 return false ; // no , it doesn't contains num
		 
	  }
	  
	  public static bool ContainsSpecial (string s ) {
	     
		 Regex r = new Regex (@"[^a-zA-Z0-9]");
		 // Not checking for spaces as that would have been already handled pre hand ,so now if it comes here so it can't be containing spaces
		 if ( r.IsMatch(s) ) {
		  // This means it contains special characters 
		  Console.WriteLine("Invalid Input (contains special character)");
		  return true; // does contains special character
		 }
		 return false ; // doesn't contain any special character
	  }
	  
	  public static bool empty (string s ) {
	      
	     if ( s.Length == 0  || string.IsNullOrEmpty(s) ) {
		   Console.WriteLine("Invalid Input (empty string)");
		   return true;
		 }
		 return false ;
	  }
	  
	    
		public static string Rascii( string s ) {
		    StringBuilder sb = new StringBuilder() ;
			foreach( char c in s  ) {
			  int i = (int) c; // converting characters of string s to ascii
			  if ( i % 2 != 0 ) {
			     sb.Append(c); // removing even acii characters
			   }
			}
			//Console.WriteLine(sb.ToString());
			return sb.ToString();
		}
		
		public static string reverse(string s ) {
		   char[] sa = s.ToCharArray();
		   // sa.Reverse(); This one is of linq and it doesn't reverse array in place , it returns as IEnumerable<char>
		   Array.Reverse(sa);
		   //Console.WriteLine(sa.ToString());
		   // return sa.ToString() ; Problem this doesn't return string on a char[]  it literally gives System.Char[] instead
		   // so use string constructor
		   return new string(sa) ;
		}
		public static string Upe(string s) {
		  StringBuilder sb = new StringBuilder () ;
		  for ( int i = 0 ; i < s.Length ; i ++ ) {
		      if ( i % 2 == 0 ) {
			    // Only turning the even indexed characters in uppercase
			    char c = char.ToUpper(s[i]);
				sb.Append(c);
			  }else {
			  // directly append in string builder
			  sb.Append(s[i]);
			  }
		   }
		   //Console.WriteLine(sb.ToString());
		   return sb.ToString();
		}
	  
	  
}