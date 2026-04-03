public class Solution {
    public int MaxProduct(int[] nums) {
      // Leetcode - 152
        int minProduct = nums[0], maxProduct = nums[0], res = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            int num = nums[i];
            int tempMax = Math.Max(num, Math.Max(num * maxProduct, num * minProduct));
            minProduct = Math.Min(num, Math.Min(num * maxProduct, num * minProduct));
            maxProduct = tempMax;
            res = Math.Max(res, maxProduct);
        }

        return res;
    }
}
