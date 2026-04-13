<Query Kind="Statements" />

using System;
using System.Collections.Generic;
using System.Linq;

class Version {
   // represents single file version
   public string Name ; // version name 
   public int Size ; // file size
   
   public Version (string n , int s ) {
      Name = n ;
	  Size = s;
   }
}

class Program {
   static Dictionary<string , List<Version>> d = new Dictionary<string , List<Version>>();
   
   public static void Main() {
      int n = Convert.ToInt32 ( Console.ReadLine());
	  for (int i = 0 ; i < n ; i++ ){
	    var parts = Console.ReadLine().Split(' ');
		switch (parts[0]) {
		   case "UPLOAD" :
		      Upload(parts[1] , parts[2] , int.Parse(parts[3]));
			  break ;
			case "FETCH":
			   Fetch(parts[1]);
			   break ;
			case "LATEST":
			    Latest(parts[1]);
				break;
		    case "TOTAL_STOARAGE":
			    Total(parts[1]);
				break;
		}
	  }
   }
   
   public static void Upload(string file ,string ver , int size ) {
   
      if (!d.ContainsKey(file)) d[file] = new List<Version>(); //does the key which is file name exists and if not then create the key for it which is the name of the file itself
	  // Checking for where the version of the file to be added doesn't exists in the file , only then add new version in it
	  if ( !d[file].Any(v => v.Name == ver )) d[file].Add(new Version(ver , size ) );
   }
   
   public static void Fetch(string file) {
     if (!d.ContainsKey(file)) {
	   Console.WriteLine("File Not Found");
	   return ;
	 }
	 List<Version> l = d[file].OrderBy(v => v.Size ).ThenBy(v => v.Name).ToList() ;
	 foreach( var e in l ) {
	    Console.WriteLine($"{file} {e.Name} {e.Size}");
	 }
   }
   
   public static void Latest(string file ) {
   
     if ( !d.ContainsKey(file)) {
	     Console.WriteLine("File Not Found");
		 return;
	   }
	 
	 Version v = d[file].Last(); 
	 // var f = d[file].First();
	 Console.WriteLine($"{file} {v.Name} {v.Size}");
	 
   }
   
   public static void Total ( string file ) {
      
	  if ( !d.ContainsKey(file)){
	    Console.WriteLine("FIle Not Found");
		return;
	  }
	  
	  int s = d[file].Sum(v => v.Size) ;
	  Console.WriteLine($"{file} {s}");
   
   }
   
}