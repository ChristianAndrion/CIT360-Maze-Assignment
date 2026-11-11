using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StackDFS : BaseTraversal
{
    [SerializeField] private Stack stack;

    public override void startTraversal()
    {
        base.startTraversal();
        robot = gameObject;
        //Create new stack and push starting location
        stack = new Stack(MazeGenerator.mazeWidth * MazeGenerator.mazeHeight);
        stack.push(MazeGenerator.getLocation((int)MazeGenerator.startLocation.x,(int)MazeGenerator.startLocation.y));
    }

    public override bool traversalStep()
    {

        if(!stack.isEmpty())
        {
            Cell curr = stack.pop();
            moveRobot(curr.gameObject.transform.position);
            curr.visited = true;

            if(curr == MazeGenerator.getLocation((int)MazeGenerator.endLocation.x,(int)MazeGenerator.endLocation.y))
            {
                isRunning = false;
                backtrack();
                return isRunning;
            }

            distance++;

            Cell north = MazeGenerator.getLocation(curr.row, curr.column + 1);

            if(!north.isWall && !north.visited)
            {
                stack.push(north);
                north.distance = distance;
            }

            Cell east = MazeGenerator.getLocation(curr.row + 1, curr.column);

            if(!east.isWall && !east.visited)
            {
                stack.push(east);
                east.distance = distance;
            }

            Cell south = MazeGenerator.getLocation(curr.row, curr.column - 1);

            if(!south.isWall && !south.visited)
            {
                stack.push(south);
                south.distance = distance;
            }

            Cell west = MazeGenerator.getLocation(curr.row - 1,curr.column);

            if(!west.isWall && !west.visited)
            {
                stack.push(west);
                west.distance = distance;
            }


            return isRunning;
        }
        //Unsolvable
        isRunning = false;
        return isRunning;
    }

    public override void incrementTraversal()
    {
        if(traversalStep())
        {
            Debug.Log("Incrementing Stack DFS Traversal");
        }
    }

    public override void completeTraversal()
    {
        while (traversalStep())
        {
            Debug.Log("Traversing Maze");
        }
        Debug.Log("Maze Traversal Finished");
    }

    

}
}