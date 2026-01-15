public class Solution {
    public int MaxArea(int[] height) {

        // Leetcode - 11. Container With Most Water
        
        int size = height.Length; // putting it in a var, as we keep on needing it
        
        // Creating arrays to store the maximum heights encountered from each side
        // This follows my logic of prefixarray and postfixarray
        int[] leftMaxArray = new int[size]; 
        int[] rightMaxArray = new int[size];
        
        // Filling prefix array: storing the tallest bar seen so far from the left
        leftMaxArray[0] = height[0];
        for (int i = 1; i < size; i++) {
            leftMaxArray[i] = Math.Max(leftMaxArray[i - 1], height[i]);
        }

        // Filling postfix array: storing the tallest bar seen so far from the right
        rightMaxArray[size - 1] = height[size - 1];
        for (int i = size - 2; i >= 0; i--) {
            rightMaxArray[i] = Math.Max(rightMaxArray[i + 1], height[i]);
        }

        int maxWater = 0;
        int left = 0;
        int right = size - 1;

        // Now I can use these arrays to guide the decision making
        // while traversing the container options
        while (left < right) {
            // Calculate current water based on the actual lines at these positions
            int currentHeight = Math.Min(height[left], height[right]);
            int width = right - left;
            int currentArea = currentHeight * width;
            
            if (currentArea > maxWater) {
                maxWater = currentArea;
            }

            // Logic using  my  pre-calculated "directional data":
            // I move the pointer that is shorter, because that side has 
            // already hit its "max potential" for the current width.
            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }

        return maxWater;
    }
}
