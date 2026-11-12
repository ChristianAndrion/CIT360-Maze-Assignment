using UnityEngine;
using UnityEngine.Rendering;

public class StackDFS : BaseTraversal
{
    private Stack stack;
    [SerializeField] private MazeGenerator mg;

    public override void startTraversal()
    {
        Debug.Log("Starting Stack DFS traversal");
        base.startTraversal();
        robot = gameObject;
        //Create new stack and push starting location
        stack = new Stack(mg.mazeWidth * mg.mazeHeight);
        stack.push(mg.getLocation((int)mg.startLocation.x,(int)mg.startLocation.y));
    }

    public override bool traversalStep()
    {

        if(!stack.isEmpty())
        {
            
            Cell curr = stack.pop();
            Debug.Log("Popping stack: " + curr);
            curr.visited = true;

            if(curr == mg.getLocation((int)mg.endLocation.x,(int)mg.endLocation.y))
            {
                isRunning = false;
                backtrack();
                Debug.Log("Exit found!");
                return isRunning;
            }

            distance++;

            Cell north = mg.getLocation(curr.row, curr.column + 1);

            if(!north.isWall && !north.visited)
            {
                stack.push(north);
                north.distance = distance;
            }

            Cell east = mg.getLocation(curr.row + 1, curr.column);

            if(!east.isWall && !east.visited)
            {
                stack.push(east);
                east.distance = distance;
            }

            Cell south = mg.getLocation(curr.row, curr.column - 1);

            if(!south.isWall && !south.visited)
            {
                stack.push(south);
                south.distance = distance;
            }

            Cell west = mg.getLocation(curr.row - 1,curr.column);

            if(!west.isWall && !west.visited)
            {
                stack.push(west);
                west.distance = distance;
            }


            return isRunning;
        }
        //Unsolvable
        Debug.Log("Unable to find exit :(");
        isRunning = false;
        return isRunning;
    }

    // public override void completeTraversal()
    // {
    //     while (traversalStep())
    //     {
    //         Debug.Log("Traversing Maze");
    //     }
    //     Debug.Log("Maze Traversal Finished");
    // }

    

}