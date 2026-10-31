using UnityEngine;
using UnityEngine.Rendering;

public class StackDFS : BaseTraversal
{
    Stack stack;
    protected override void startTraversal()
    {
        base.startTraversal();
        //Create new stack and push starting location
        stack = new Stack(mg.mazeWidth * mg.mazeHeight);
        stack.push(mg.getLocation(mg.startLocation));
    }

    public override bool incrementTraversal()
    {

        if(!stack.isEmpty())
        {
            Cell curr = stack.pop();
            curr.visited = true;

            if(curr == mg.getLocation(mg.endLocation))
            {
                isRunning = false;
                backtrack();
                return isRunning;
            }

            distance++;

            Cell north = mg.getLocation(new Vector2(curr.row, curr.column + 1));

            if(!north.isWall && !north.visited)
            {
                stack.push(north);
                north.distance = distance;
            }

            Cell east = mg.getLocation(new Vector2(curr.row + 1, curr.column));

            if(!east.isWall && !east.visited)
            {
                stack.push(east);
                east.distance = distance;
            }

            Cell south = mg.getLocation(new Vector2(curr.row, curr.column - 1));

            if(!south.isWall && !south.visited)
            {
                stack.push(south);
                south.distance = distance;
            }

            Cell west = mg.getLocation(new Vector2(curr.row - 1,curr.column));

            if(!west.isWall && !west.visited)
            {
                stack.push(west);
                west.distance = distance;
            }

            return isRunning;
        }
        isRunning = false;
        return isRunning;
    }

    public override void completeTraversal()
    {
        while (incrementTraversal())
        {
            Debug.Log("Traversing Maze");
        }
        Debug.Log("Maze Traversal Finished");
    }
}
