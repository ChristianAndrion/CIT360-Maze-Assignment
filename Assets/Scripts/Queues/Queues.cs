public class Queues
{

    public Cell[] queue;
    private int front;
    private int size;

    public Queues(int capacity)
    {
        queue = new Cell[capacity];
        front = 0;
        size = 0;
    }

    public void Enqueue(Cell obj){
        if(isFull()){
            Debug.Log("Capacity Reached");
            return;
        }

        int avail = (front + size) % queue.Length;
        queue[avail] = obj;
        size++;

    }

    public Cell Dequeue(){
        if(isEmpty()){
            Debug.Log("nothing to dequeue");
            return null;
        }

        Cell tmp = queue[front];
        front = (front + 1 ) % queue.Length;

        size--;
        return tmp;
    }

    public Cell peek()
    {
        if(isEmpty())
        {
            return null;
        }
        return queue[front];
    }

    public bool isEmpty()
    {
        return size == 0;
    }

    public bool isFull()
    {
        return size == queue.Length;
    }

}
