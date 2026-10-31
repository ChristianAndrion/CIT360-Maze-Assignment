using UnityEngine;

public class Stack : MonoBehaviour
{
    private Cell[] arr;
    private int top;
    private int capacity;

    public Stack(int cap)
    {
        capacity = cap;
        this.arr = new Cell[capacity];
        this.top = -1;
    }

    public void push(Cell cell)
    {
        if(isFull())
        {
            Debug.Log("Capacity exceeded");
            return;
        }
        arr[top++] = cell;
    }

    public Cell pop()
    {
        if (isEmpty())
        {
            return null;
        }
        return arr[top--];
    }

    public Cell peek()
    {
        if (isEmpty())
        {
            return null;
        }
        return arr[top];
    }

    public int getSize()
    {
        return top + 1;
    }

    public int getCapacity()
    {
        return capacity;
    }

    public bool isEmpty()
    {
        return top == -1;
    }

    public bool isFull()
    {
        return top == capacity - 1;
    }

}
