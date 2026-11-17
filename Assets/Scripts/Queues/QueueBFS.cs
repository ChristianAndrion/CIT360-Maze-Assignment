using UnityEngine;
using UnityEngine.Rendering;

public class QueueBFS : BaseTraversal
{
    private Queues queue;

    public override void startTraversal()
    {
        Debug.Log("Starting Queue BFS traversal");
        base.startTraversal();
        robot = gameObject;

        queue = new Queues(mg.mazeWidth * mg.mazeHeight);

        Cell start = mg.getLocation((int)mg.startLocation.x,(int)mg.startLocation.y);

        start.visited = true;
        start.distance = 0;
        queue.Enqueue(start);
    }

    public override void traversalStep()
    {
        if(!queue.isEmpty())
        {
            Cell curr = queue.Dequeue();
            Debug.Log("Dequeuing: " + curr);
            rc.UpdateRobotText("Processing: " + curr.name);
            curr.processed = true;

            if(curr == mg.getLocation((int)mg.endLocation.x, (int)mg.endLocation.y))
            {
                isRunning = false;
                rc.UpdateRobotText("Exit found!");
                backtrack(curr);
                return;
            }

            

            Cell north = mg.getLocation(curr.row, curr.column + 1);
            if(!north.isWall && !north.processed)
            {
                north.visited = true;
                north.distance = curr.distance + 1;
                queue.Enqueue(north);
            }

            Cell east = mg.getLocation(curr.row + 1, curr.column);
            if(!east.isWall && !east.processed)
            {
                east.visited = true;
                east.distance = curr.distance + 1;
                queue.Enqueue(east);
            }

            Cell south = mg.getLocation(curr.row, curr.column - 1);
            if(!south.isWall && !south.processed)
            {
                south.visited = true;
                south.distance = curr.distance + 1;
                queue.Enqueue(south);
            }

            Cell west = mg.getLocation(curr.row - 1, curr.column);
            if(!west.isWall && !west.processed)
            {
                west.visited = true;
                west.distance = curr.distance + 1;
                queue.Enqueue(west);
            }

            return;
        }
        
        // unsolvable
        rc.UpdateRobotText("Cant find the exit :/ ");
        isRunning = false;
    }
}
