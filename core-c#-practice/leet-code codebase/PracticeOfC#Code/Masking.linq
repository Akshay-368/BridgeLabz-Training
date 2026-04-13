<Query Kind="Statements" />

using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Collections.Generic;
class Program{
 
 public static void Masking(string s ) {
 
     string input = Regex.Replace(s , @"TKT-[A_Z]{4}[0-9]{4}" , "TKT-XXXX****");
	 
	 
  }
  
  public static void TelephoneMask(string s ) {
  
     string ans = Regex.Replace(s , @"TELE:([0-9]+)-([0-9]{3})-([0-9]{3})-(\d{4})" , m => "TELE:" + m.Groups[1].Value + "-" + "******" + m.Groups[4].Value );
  
  }
  
  public static void RepWordsMask(string s ) {
  
     string ans = Regex.Replace(s , @"\b(\w+)(\s+\1)+\b" , m => m.Groups[1].Value , RegexOptions.IgnoreCase );
  
  }
  
   public static void SymbolsMask(string s ) {
  
     string ans = Regex.Replace(s , @"([!?])\1{2,}$" , m => m.Groups[1].Value );
  
  }
  

}