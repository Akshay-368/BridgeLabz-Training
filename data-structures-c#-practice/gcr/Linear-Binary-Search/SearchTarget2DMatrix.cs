using System;

public class bin3 
{
    // search target in 2d sorted matrix using binary search
    // treat matrix as 1d array
    public static bool searchInMatrix(int[,] mat,int rows,int cols,int target) 
    {
        int left = 0;
        int right = rows * cols - 1;

        while(left <= right) 
        {
            int mid = left + (right - left)/2;

            // convert 1d index to 2d
            int row = mid / cols;
            int col = mid % cols;

            int current = mat[row,col];

            if(current == target) 
            {
                Console.WriteLine("found at row " + row + " col " + col);
                return true;
            }

            if(current < target) 
            {
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }

        Console.WriteLine("target not found");
        return false;
      // binary search on virtual 1d array
    }

    public static void Main(string[] args) 
    {
        /*
        Binary Search Problem 3: Search for a Target Value in a 2D Sorted Matrix
        Problem: You are given a 2D matrix where each row is sorted in ascending order. Write a program that performs Binary Search to find a target value in the matrix.
        */

        Console.WriteLine("search in 2d sorted matrix");

        Console.Write("Waiting , for user to enter rows : ");
        int r = Convert.ToInt32(Console.ReadLine());

        Console.Write("Waiting , for user to enter columns : ");
        int c = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[r,c];

        Console.WriteLine("enter matrix row by row");

        for(int i=0; i<r ; i++) 
        {
            for(int j=0; j<c ; j++) 
            {
                Console.Write("enter element [" + i + "][" + j + "] : ");
                matrix[i,j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.Write("Waiting , for user to enter target number : ");
        int targetNum = Convert.ToInt32(Console.ReadLine());

        bool found = searchInMatrix(matrix , r , c , targetNum);

        if(!found) 
        {
            Console.WriteLine("not present");
        }

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
