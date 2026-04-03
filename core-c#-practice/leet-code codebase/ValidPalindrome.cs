public class Solution {
    public bool IsPalindrome(string s) {
        // Leetcode - 125
        StringBuilder newString = new StringBuilder();
        foreach(var c in s)
        {
            if ((c >= '0' && c <= '9') || ((c >= 'a' && c <= 'z')) || ((c >= 'A' && c <= 'Z')))
            {
                newString.Append(c);
            }
        }
        
       
        string a = newString.ToString().ToLower();
        return a == new string(a.Reverse().ToArray());
    }
}
