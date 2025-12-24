public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        // Leetcode  217.
        // So for this question we can use a set (for seen or visited numbers in the array ) 
        // which contains only unique values by default
        // and thus if we find any value that is in the set already then yes duplicate exits

        HashSet<int> s = new HashSet<int> (); // a set for seen numbers
        // otherwise just simply do var s = new HashSet<int>(); to let
        // compiler do the work
        for (int i = 0 ; i < nums.Length ; i ++ ){
            if (s.Contains(nums[i])){
                // This is to check if the s-set , contains the value of nums[i]
                // Basically if set contains the number we are currently at ?
                // Then that means the duplicate exists in the array . So as per the insteuctn
                return true ;
            }
            // if the condition did not get true then that means we have not seen this one yet
            s.Add(nums[i]) ;// so we will add it in the set
        }
        return false ; // as if we did not get to return true , only then we will reach here
        // and that means the numbers are not duplicated in the array.
        // So as per the instructions returning false
    }
}
