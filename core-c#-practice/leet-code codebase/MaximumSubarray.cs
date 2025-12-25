public class Solution {
    public int MaxSubArray(int[] nums) {
      // Leetcode - 53
        int maxSubarray = nums[0];
        int currSubarray = nums[0];
        for(int i = 1;i<nums.Length;i++)
        {
            currSubarray = Math.Max(nums[i],currSubarray+nums[i]);
            maxSubarray = Math.Max(maxSubarray,currSubarray);
        }

        return maxSubarray;
    }
}
