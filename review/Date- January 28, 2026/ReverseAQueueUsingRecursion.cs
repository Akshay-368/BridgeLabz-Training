using System;
namespace ReviewQuestions ;

public class SimpleQueue
{
    private int[] arr;        // array to store elements
    private int front;        // index of front element
    private int rear;         // index where next element will be added
    private int capacity;     // max size
    private int currentSize;  // how many elements currently

    public SimpleQueue(int size)
    {
        // Defining and initializing the queue with the user defined size
        // Now this is a constructor to help us do so because these are some private fields and thus using a constructor
        capacity = size;
        arr = new int [capacity];
        front = 0; // index of the front
        rear = -1; // since it is the last element ,so basically index from the end
        currentSize = 0 ; // size of the queue which is just empty currently
    }

    // add element to rear as this is a queue we will add elements to the very end following first in first out.
    public void Enqueue(int value)
    {
        if (currentSize == capacity)
        {
            Console.WriteLine (" The queue is full ");
            return;
        }

        // For example :-> ( -1 + 1 ) % 10 = ( 0 % 10 ) = 0 ;
        rear = (rear + 1) % capacity ; // just to make sure that the indexing stays in circular and we don't end up going 
        arr [rear] = value ;// as value always gets added to the end of the queue but since i already updated rear so the very first value will be
        //ultimately getting stored in the 0th index and then second value will be at the 1th index automatically
        // so essentially making sure no new addition to the queue end up in making me to do the entire update again and again.
        currentSize ++ ;
        Console.WriteLine  (  " Enqueued : " + value );
    }

    // remove element from front
    public int Dequeue()
    {
        if ( IsEmpty())
        {
            Console.WriteLine ( " The queue is empty ");
            return -1 ;
        }
        
        int value = arr[front] ; // storing the value at the required index for displaying what is deleted.
        front = (front + 1 ) % capacity ; // using and updating front because only from front we delete the data
        currentSize -- ;
        return value ;
    }

    // check if queue is empty
    public bool IsEmpty()
    {
        return currentSize == 0;
    }

    // print current queue (for demo)
    public void Print()
    {
        if ( IsEmpty())
        {
            Console.WriteLine ( " The queue is empty ");
            return ;
        }

        Console.Write("Queue : ");
        int f = front; // because we don't want to make the changes in the private field of front, so creating a local copy to work on it
        for (int count = 0 ; count < currentSize; count++)
        {
            Console.Write(arr [f] + " ");
            f = ( f + 1) % capacity;
        }
        Console.WriteLine();
    }


    public void Reverse()
    {
        // base case - if queue is empty, nothing to do
        if ( IsEmpty() )
        {
            return ;
        }

        // so for example we will get to the end of the queue in this manner until we will get to actually enqueue.

        // remove front element
        int frontValue = Dequeue();

        //  recursively reverse the remaining queue
        Reverse();

        // add the removed element back to the rear
        Enqueue(frontValue);
    }


}
