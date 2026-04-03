// Leetcode - 33

public class Solution {
    public int Search(int[] nums, int target) {
        int left  = 0 ;
        int right = nums.Length - 1 ;
        int middle ;

        while (left <= right) {
    middle = left + ((right - left) / 2);
    if (nums[middle] == target) return middle;

    // Your original logic: target < nums[left]
    if (target < nums[left]) {
        // We know target is in the "rotated/lower" half.
        // BUT, we can only move left = middle + 1 IF middle is 
        // also in the "upper" half or if middle is still to the left of target.
        if (nums[middle] >= nums[left] || nums[middle] < target) {
            left = middle + 1;
        } else {
            right = middle - 1;
        }
    } 
    else {
        // Target is in the "upper" half (>= nums[left]).
        // We can only move right = middle - 1 IF middle is 
        // in the "lower" half or if middle is still to the right of target.
        if (nums[middle] < nums[left] || nums[middle] > target) {
            right = middle - 1;
        } else {
            left = middle + 1;
        }
    }
}

        return - 1 ;
    }
}

/*
My version is a bit different though both are doing the same thing to answer "Can I prove the target is NOT in this half?"
The Standard version proves it by saying: "I know this side is perfectly sorted, and the target isn't within its min/max, so it must be on the other side."

My version proves it by saying: "I know the target is on the 'low' side of the rotation, so unless the middle is also on the 'low' side and still 
smaller than the target, I should move right."

Feature,               My Code,                                                                    Standard Code
Primary Question,   """Where is the target relative to the start?""",                         """Which half of the array is sorted?"""
Logic Flow,          Target-centric (checks values first).,                                    Structure-centric (checks indices/segments first).
Complexity,           Both are O(logn).,                                                       Both are O(logn).
Readability,     "High for those thinking about ""rotation"" as a property of the target.",   "High for those thinking about ""sub-arrays"" as chunks of space."



 The difference is actually philosophical: the **Standard Approach** is "Geography-First," while **My Approach** is "Target-First."

To see the difference, imagine the rotated array as two separate "hills" (slopes).

---

### 1. The Standard Approach: "Where am I standing?"

The textbook logic starts by looking at the **array structure** around the `middle` pointer.

* **The Question:** "Is the piece of land I'm standing on (from `left` to `middle`) a smooth, unbroken uphill slope?"
* **The Logic:**
1. Check if `nums[left] <= nums[middle]`. If yes, the left side is a "Safe Zone" (perfectly sorted).
2. Only *then* check the target: "Is the target physically inside the boundaries of this Safe Zone?"
3. If yes, go left. If no, it **must** be on the other side (the "Messy Zone").



**Example: `[4, 5, 6, 7, 0, 1, 2]`, Target = 1**

* `mid` is 7.
* Standard says: "Indices 0 to 3 (`4` to `7`) are sorted. Is `1` between `4` and `7`? No. Okay, I'm going right."

---

### 2. My Approach: "Where is my target hiding?"

My logic starts by looking at the **target's relationship** to the "Big Jump" (the rotation).

* **The Question:** "Based on the first number in the array, is my target on the 'High Hill' or the 'Low Hill'?"
* **The Logic:**
1. If `target < nums[left]`, the target is a "Low Hill" resident.
2. Then look at `middle`: "Is `middle` on the same hill as my target, or is it still up on the 'High Hill'?"
3. I use the position of the target as my primary compass.



**Example: `[4, 5, 6, 7, 0, 1, 2]`, Target = 1**

* `target (1) < nums[left] (4)` is **True**. (Target is on the "Low Hill").
* `mid` is 7. `mid` is on the "High Hill."
* My logic says: "My target is low, but my middle is high. I need to jump down to the right to find the Low Hill."

---

### Why the "Edge Cases" hit them differently

Let's look at the case : **`nums = [5, 1, 2, 3, 4]`, Target = 1**

| Feature | Standard Book Approach | My "Target-First" Approach |
| --- | --- | --- |
| **Middle Point** | `mid` is index 2 (value `2`) | `mid` is index 2 (value `2`) |
| **Step 1** | Is left sorted? `nums[0](5) <= nums[2](2)`? **No.** | Is `target(1) < nums[0](5)`? **Yes.** |
| **Step 2** | Since left is messy, the right `[2, 3, 4]` **must** be sorted. | Is `mid(2)` on the "High Hill" or "Low Hill"? |
| **Step 3** | Is `target(1)` between `nums[2](2)` and `nums[4](4)`? **No.** | `nums[mid](2)` is also < `nums[left](5)`. They are on the same "Low Hill." |
| **Decision** | Go Left. | Is `mid(2) > target(1)`? **Yes.** Go Left. |

---

### Summary of the Difference

* **The Standard Approach** is more **defensive**. It finds a "Safe Zone" and checks if the target is in it.
If not, it runs to the other side. It doesn't actually care *why* the other side is messy.
* **My Approach** is more **navigational**. It maps out the two "Hills" and checks which hill the target lives on,
then adjusts the `middle` pointer based on whether the `middle` has reached that hill yet.

My way is actually how a human usually scans a list! We think, "I'm looking for a small number, and this part of the list is all huge numbers, 
let me skip ahead." The standard way is more "robotic"—it checks for order first, then for the value.




*/
