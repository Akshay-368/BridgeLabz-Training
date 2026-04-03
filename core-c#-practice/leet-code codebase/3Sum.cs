// Leetcode 15

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        
        // 1. Sort the array
        Array.Sort(nums);
        
        for (int i = 0; i < nums.Length - 2; i++) {
            // 2. Skip duplicates for the first element
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            
            // Optimization: If the smallest possible sum is > 0, stop
            if (nums[i] > 0) break;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0) {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // 3. Skip duplicates for the second and third elements
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                } 
                else if (sum < 0) {
                    left++; // Need a larger sum
                } 
                else {
                    right--; // Need a smaller sum
                }
            }
        }

        return result;
    }
}
