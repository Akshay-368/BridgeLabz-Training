public class Solution {
    public int MaxProfit(int[] prices) {
      // Leetcode 121
        var buy = prices[0] ; // intializing the best day to buy as of now .
        int maxProfit = 0 ; // No profit is earned as of now . and thus it will be the default
        // Besides who knows if we did not find any favourable condition then this is the
        // profit we will be left with

        for (int sell = 0 ; sell < prices.Length ; sell ++){
            if (prices[sell] < buy ){
                buy = prices[sell] ; // This means we found a more cheaper position to buy
                // As for maximum profit we want to buy at the least
                // and sell at the most high price as possible
            }else {
                // Means now sell > buy
                // That measn we can calculate the profit now
                maxProfit = Math.Max(maxProfit , prices[sell] - buy);
                // Using max func , to compare curr profit with the global max profit we have
                // seen so far
            }
        }
        return maxProfit;
    }
}
