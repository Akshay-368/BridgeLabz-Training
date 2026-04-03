public class Solution {
    public int[] TwoSum(int[] nums, int target) {

        /*first let me explain my approach , 
        i am thinking of using a hashmap , for stroing every element with 
        their index whom so ever we will travsere and go through in the traversal 
        through the array and for every element i will first match it's difference 
        with the traget value with the elements present in the hashmap 
        and if it is there then cool , that's the answer we needed , 
        otherwise add the element and move forward */

        Dictionary <int , int> d = new Dictionary <int , int>();
      // we can also use var d= new Dictionary<int , it>() ; here as it means compiler will infer it for me , but it only works at method level and not for classes

        // First we created a dictionary to store every element we visited
        // This way every time we visit a new element we can just check if it completes the
        // current element to the target value

        for (int i = 0 ; i < nums.Length ; i++ ){
            int c = target - nums[i]; // complement , basically the remaining value  we need to make the current variable reach target and thus this is what we ultimately needs to find.
            if (d.ContainsKey(c)) {
                return new int[] {d[c] , i } ; // returning an array with the required pair where i in the index in nums , and d[c] will also return an index (for the other value present in nums) 
            }else {
                d [nums[i]] = i ; // Here we put nums[i] as the key in the dict with the value as it's index ( in nums ) 
            }
        }
        return Array.Empty<int>() ; // Not found as it seems the pair doesn't exists
        // here we need to do it , just to silence the compiler , because in the function above it promises the compiler that we will return an int[] and now it wants it everytime
      // and thus it's only for that purpose here 
      // as otherwise , in this problem logically it's redundant .
      // and we could have done it with new int[0]; as well , but it consumes more memory as there will be new allocation memory, even though it's empty , but still a little clunky
      // while Array.Empty<int>() means a cached shared empty array and zero new memory allocation and faster and cleaner and more intention revealing.
    }
}
