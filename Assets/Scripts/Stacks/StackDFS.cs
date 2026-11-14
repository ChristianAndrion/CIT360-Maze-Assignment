using UnityEngine;
using UnityEngine.Rendering;

public class StackDFS : BaseTraversal
{
    private Stack stack;

    public override void startTraversal()
    {
        Debug.Log("Starting Stack DFS traversal");
        base.startTraversal();
        robot = gameObject;
        //Create new stack and push starting location
        stack = new Stack(mg.mazeWidth * mg.mazeHeight);
        stack.push(mg.getLocation((int)mg.startLocation.x,(int)mg.startLocation.y));
    }

    public override void traversalStep()
    {

        if(!stack.isEmpty())
        {
            
            Cell curr = stack.pop();
            Debug.Log("Popping stack: " + curr);
            rc.UpdateRobotText("Processing: " + curr.name);
            curr.processed = true;
            curr.distance = distance;

            if(curr == mg.getLocation((int)mg.endLocation.x,(int)mg.endLocation.y))
            {
                isRunning = false;
                rc.UpdateRobotText("Exit found!");
                backtrack(curr);
            }

            distance++;

            Cell north = mg.getLocation(curr.row, curr.column + 1);

            if(!north.isWall && !north.processed)
            {
                north.visited = true;
                north.distance = distance;
                stack.push(north);
            }

            Cell east = mg.getLocation(curr.row + 1, curr.column);

            if(!east.isWall && !east.processed)
            {
                east.visited = true;
                east.distance = distance;
                stack.push(east);
            }

            Cell south = mg.getLocation(curr.row, curr.column - 1);

            if(!south.isWall && !south.processed)
            {
                south.visited = true;
                south.distance = distance;
                stack.push(south);
            }

            Cell west = mg.getLocation(curr.row - 1,curr.column);

            if(!west.isWall && !west.processed)
            {
                west.visited = true;
                west.distance = distance;
                stack.push(west);
            }
            return;
        }
        //Unsolvable
        rc.UpdateRobotText("Unable to find exit :(");
        isRunning = false;

    }

}