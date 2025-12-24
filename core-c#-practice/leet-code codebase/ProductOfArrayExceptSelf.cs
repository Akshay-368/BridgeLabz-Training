public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

        // Leetcode - 238.
      
        var prefixarray = new int[nums.Length]; // creating a prefix array
        // This array will hold the values of the multiplication for each element for
        // whatever will be the product of them with whatever has been the product so far 
        // without involving them
        // so for example for the array = [1 ,2 ,3 ,4];
        // the prefixarray will be [1, 2, 6 , 12];
        // similarly i will create a postfix array which will b like :
        // [ 24 , 24 , 12 , 4] ; and now for final answer 
        // i can simply do let's say for ith postion
        // It will be if ( i == 0 ) ans [i] = postfixarray [i + 1] * 1;
        // and if ( i == nums.Length - 1 ) ans [i] = prefixarray[i - 1] * 1 ;
        // otherwise for any other i , ans[i] =  prefixarray[i - 1] * postfixarray[i + 1];

        // As the answer have to include every num except num itself and 
        // in those pre and post arrays at every ith position we have the result of multiplica
        // including them , so for prefix that's why we go i - 1 , as that we would not be 
        // including it and for postfix we go i + 1 , to avoid including the num itself.

        int[] postfixarray = new int[nums.Length];
        int size = nums.Length ; // puting it in a var , as we keep on needing it
        postfixarray[size- 1] = nums[size - 1]; // predefining it as that's what will be present for multiply
        // since no previous value is available since it is last and similarly
        prefixarray[0] = nums[0] ;
        int[] ans  = new int[size] ;

        for (int i = 1 ; i < size ; i++){
            prefixarray[i] = prefixarray[i - 1] * nums[i];
        }

        for (int i = size - 2 ; i >= 0 ; i--){
            postfixarray[i] = postfixarray[i + 1] * nums[i];
        }

        //now just using these two arrays
        for (int i = 0 ; i < size ; i ++){
            if (i == 0 ){
                ans [i] = postfixarray [i + 1] * 1;
            }else if ( i == nums.Length - 1 ){
                ans [i] = prefixarray[i - 1] * 1 ;
            }else{
                ans[i] =  prefixarray[i - 1] * postfixarray[i + 1];
            }

        }
        return ans ;


    }
}
