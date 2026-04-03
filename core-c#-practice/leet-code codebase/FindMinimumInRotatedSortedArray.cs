/*

Leetcode 153. Find Minimum in Rotated Sorted Array

Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

[4,5,6,7,0,1,2] if it was rotated 4 times.
[0,1,2,4,5,6,7] if it was rotated 7 times.
Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

Given the sorted rotated array nums of unique elements, return the minimum element of this array.

You must write an algorithm that runs in O(log n) time.

 

Example 1:

Input: nums = [3,4,5,1,2]
Output: 1
Explanation: The original array was [1,2,3,4,5] rotated 3 times.
Example 2:

Input: nums = [4,5,6,7,0,1,2]
Output: 0
Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
Example 3:

Input: nums = [11,13,15,17]
Output: 11
Explanation: The original array was [11,13,15,17] and it was rotated 4 times. 
 

Constraints:

n == nums.length
1 <= n <= 5000
-5000 <= nums[i] <= 5000
All the integers of nums are unique.
nums is sorted and rotated between 1 and n times.

*/


public class Solution {
    public int FindMin(int[] nums) {
        int left = 0 ;
        int right = nums.Length - 1 ;
        
        // Use < instead of <= so that when left == right, 
        // I've narrowed it down to the single minimum element.

        while ( left < right ){

            int middle = left + ( ( right - left ) / 2  ) ;

            // If middle is greater than the rightmost element, 
            // the dip (minimum) must be in the right half.
            if ( nums[middle] > nums[right]) {
                left = middle + 1 ;
            } // Otherwise chances are that the minimum will be in the left half ( including middle ).
            else if ( nums [middle] < nums[right]){
                right = middle ;
            }

        }

        // At the end of the loop, left == right , pointing to the minimum .
        return nums[ left ] ;
        
    }
}

/*
So here let's do a dry run of this algo, on the example [ 4,5 ,6,7,0,1,2] 
This example will show how the middle pointer interacts with that pivot point.

Step,left (idx), right (idx),  middle (idx),  nums[mid] vs nums[right],  Action
1,   0 (val: 4),  6 (val: 2),  3 (val: 7),      7>2,                     left = mid + 1 (4)
2,   4 (val: 0),  6 (val: 2),  5 (val: 1),      1<2,                     right = mid (5)
3,   4 (val: 0),  5 (val: 1),  4 (val: 0),      0<1,                     right = mid (4)
End, 4,           4,           -,           Loop stops (4 < 4 is false), Return nums[4] (0)

1. Why right = middle and not right = middle - 1?
Look at Step 3 in the table.

Our middle was index 4 (value 0).

If we had done right = middle - 1, our right would have become index 3.

We would have deleted the actual minimum (0) from our search space! By setting right = middle, we say: "The middle is smaller than the right, 
so the minimum is either this middle element or something to its left."

2. Why while (left < right) and not left <= right?
In standard Binary Search, we use <= because we are looking for a specific target value. If we find it, we return immediately. 
In this problem, we are shrinking a window until it points to one single spot.

If you used left <= right, and you reached the point where left == right, the logic would keep running forever.

middle would equal left, nums[middle] would be equal to nums[right], it would trigger the else block, and right would just stay middle over and over.

3. How do they both end up at the minimum?
Because of the "Case 1" and "Case 2" logic:

If the search space is still "rotated" (nums[mid] > nums[right]), we push left forward.

If the search space looks "sorted" (nums[mid] < nums[right]), we pull right backward. They are essentially "squeezing" the array from both sides until 
they have no choice but to meet at the lowest point.

4. The "Already Sorted" Edge Case
What if the array is [11, 13, 15, 17]?
middle is 13, right is 17.
13 < 17, so right moves to 13.
Then middle becomes 11, right is 13.
11 < 13, so right moves to 11.
left and right now both point to 11. Loop ends.

It handles the "no rotation" case perfectly without any extra if statements!

How it differs from the main binary search , just for an example the classic way of BS is:
int BinarySearch(int[] arr, int target)
{
    int low = 0;
    int high = arr.Length - 1;

    while (low <= high)
    {
        int mid = low + (high - low) / 2;  // safer than (low + high)/2

        if (arr[mid] == target)
            return mid;   // found, return index

        if (arr[mid] < target)
            low = mid + 1;   // search right half
        else
            high = mid - 1;  // search left half
    }

    return -1;  // not found
}
*/
