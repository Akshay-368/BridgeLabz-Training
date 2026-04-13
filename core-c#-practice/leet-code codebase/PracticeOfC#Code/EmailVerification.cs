namespace EmailVerification ;
using System;
using System.ComponentModel;
using System.Text;

public class EmailVerification
{
    StringBuilder lastname = new StringBuilder() ;
    StringBuilder num = new StringBuilder();

    public bool isEmailValid ( string email)
    {
        lastname.Clear();
        num.Clear();
        if ( email.Contains(' ' )) return false ;
        if (!email.Contains('@')) return false ;
        if ( email.Length < 3 ) return false;
        if ( Countof(email) > 1 ) return false ;
        String[] ar = email.Split('@');
        string firstpart = ar[0];
        string secondpart = ar[1] ;
        String[] namesandnumber = firstpart.Split('.');
        if ( namesandnumber.Length != 2 ) return false ;
        string firstname = namesandnumber[0];
        if (!isLowerCase(firstname)) return false ;
        // Now getting the lastname and number from the namesandnumber
        Subs(namesandnumber[1]);
        if ( lastname.ToString() == "" ) return false ;
        if ( ! isLowerCase(lastname.ToString())) return false ;
        if (!isNum(num.ToString())) return false ;

        // Now focusing on secondpart
        string[] depaCompCom = secondpart.Split('.');
        if ( depaCompCom.Length != 3 ) return false ;
        string department = depaCompCom[0];
        string company = depaCompCom[1];
        string domain = depaCompCom[2];
        if (!isDepartment(department)) return false ;
        if (!isCompany(company)) return false ;
        if (!isDomain(domain)) return false ;
        return true ;
    }

    public bool isLowerCase( string s)
    {
        if (s.Length < 3) return false ;
        foreach ( char c in s)
        {
            if ( c >='a' && c <= 'z')
            {
                return false ;
            }
            /*  if (char.IsUpper(c))
            {
                return true ;
            } this method of directly comparing char c with starting char of therange and last char of the range can also work */
        }
        return true ;
    }

    public bool isNum ( string s)
    {
        if ( s.Length < 4 ) return false ;
        foreach ( char c in s)
        {
            if (!char.IsDigit(c)) return false ;
        }
        return true ;
    }

    public int Countof ( string s)
    {
        int count = 0 ;
        foreach( char c in s)
        {
            if ( c == '@' ) count += 1 ;
        }
        return count ;
    }

    public void Subs(string s)
    {
        
        for ( int i = 0 ; i < s.Length ; i++)
        {
            int prev = i - 1 ;
            
            if (char.IsLetter(s[i]))
            {
                if ( prev == -1)
                {
                    // This means i is at 0 index. So let's make sure that first element of the string itself is a alphabet and not something else for the sake of the format
                    if (! char.IsLetter(s[i])) return ;
                    else lastname.Append(s[i]);
                    // This means the very first char was not valid since accepted format need lastname .
                }
                else if (char.IsLetter(s[prev]))lastname.Append(s[i]);
                // This is to make sure that no neighbour element of the string are not 'not-letter' which so happen just pass the first isLetter check becasue they happen to be a alpha ele , as a lastname should have alphabets in a cluster not scattered randomly which are just getting filetered here by the function adn gettng appended to lastname.
                else return ;
            }
            else 
            {
                // so that later on it can be validated that anything else that was inside the string was just number only and nothing else.
                num.Append(s[i]);
            }
        }
        
    }

    public bool isDepartment(string s)
    {
        if (s == "sales" || s == "IT" || s == "marketing" || s == "product") return true ;
        return false ;
    }

    public bool isDomain(string s)
    {
        if (s == "com" ) return true ;
        return false ;
    }

    public bool isCompany(string s)
    {
        if (s == "company" ) return true ;
        return false ;
    }
}