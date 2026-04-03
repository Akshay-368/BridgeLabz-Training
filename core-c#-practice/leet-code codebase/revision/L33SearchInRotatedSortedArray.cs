public class Solution {
    public int Search(int[] nums, int target) {

       // Let me use BS for the searching , with a little variation          
       int left = 0 ;       
       int right = nums.Length -1 ;
       int middle ;

       while ( left <= right ) {

               // Now I will first simply calculate the middle
               middle = left + ( ( right - left )  / 2 );
               // Happiest Case : 
               if ( nums[middle] == target ) return middle ;

               // Now  I have middle , left , right, ofcourse The TARGET
               // So first I need to check if the target is in which direction in the nums
               // SIncce the array is somewhat sorted , just got rotated. there is going to be a dip which will be acting as the differentiator anyways. So I can just simply check if the target is going to be in which half around that dip .

               if ( target < nums[left] ) {
                    // This signals that the target must be in the lower region.
                    /* Example target is :->  -
                                              -
                      L     M     T   R
                      -  -  -  -  -  -
                      -  -  -  -  -
                      -  -  -  -
                         -  -  
                            -
                     <- DIP BEGINS ->
                SO Npw as we can see if we assume that the target is to be smaller than left
    then this means it can't be in the upper region. Though whether the middle will be in upper or lower is up for figuring out , as i still can't be sure of it atleast at this stage , yet.
                    */           1                    2
                     if ( nums[middle] < target || nums[middle] >= nums[left] ){
                             // Here first Now i was checking whether my middle is smaller than the target , as that means it is in the same region as it is . since remember this is the case (1) when the target is in lower region, and here I just make sure i don't skip it . 
// Also this thing might help in navigating in the region once we get there , but before that i need to figure out if my middle is in fact inthe upper or lower and if middle is greater or equal than the left ( this is for condition 2 , middle is still in upper half ), then it is in the upper. In both cases , I can simply do this:
                             left = middle + 1 ;

                             /*
                             nums[mid] >= nums[left]   // mid in upper (wrong zone)
                             nums[mid] < target       // same zone but left of target
                             */

                             } else { right = middle - 1 ; // Easy peasy}
                    }
                  else {
                    //Now it is the case in which all the above cases failed thus we are here and also it means the target is in the upper half . As in target was greater than the left. so that means it could be somewhere in the upper half , ( though not middle , as otherwise happiest case would have been executed already ) , though still the same dilemma i have to first see if the middle is in the upper half or not or if the target is to the right of the middle within that upper half itself.
                    if ( nums [ middle ] > target || nums[middle] < nums[left] ){
                             // Here in cond-2 -> means middle must be in lower half
                             // in cond 1 -> means middle is still to the right of target while being in the same region as target, thus >
                             // in both cases :
                             right = middle - 1 ;// we don't need middle and since we need to move right and middle is in the other half which we don't need . Thus discard half the search space

                             /*
                             nums[mid] < nums[left]   // mid in lower (wrong zone)
                             nums[mid] > target      // same zone but right of target
                             */

                             } else { left = middle + 1 ; // Similar to the above }
                    }
               }
        return -1 ;
       }
}
