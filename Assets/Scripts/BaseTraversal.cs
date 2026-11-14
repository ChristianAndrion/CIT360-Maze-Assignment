using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BaseTraversal : MonoBehaviour
{
    public bool isRunning;
    public int distance;
    [SerializeField] protected MazeGenerator mg;
    [SerializeField] protected GameObject robot;
    protected RobotController rc;

    [SerializeField] private Button _incrementButton;
    [SerializeField] private Button _completeButton;

    private Coroutine _loopTraversalStep;
    public float loopInterval;


    private void Start()
    {
        _incrementButton.onClick.AddListener(incrementTraversal);
        _completeButton.onClick.AddListener(completeTraversal);
        rc = robot.GetComponent<RobotController>();
    }

    public virtual void startTraversal()
    {
        rc.UpdateRobotText("Starting Traversal with " + gameObject.name);
        isRunning = true;
        distance = 0;
    }

    public virtual bool traversalStep()//Override this with the algorithm
    {
        return false;
    }

    public void incrementTraversal() //Realized, can just do this instead of overriding it for every traversal
    {
        if(traversalStep())
        {
            Debug.Log("Incrementing " + gameObject.name + " Traversal");
        }   
    }

    public virtual void completeTraversal()
    {
        if(_loopTraversalStep != null)
        {
            StopCoroutine(nameof(RepeatTraversalStep));
        }

        _loopTraversalStep = StartCoroutine(RepeatTraversalStep(loopInterval));
    }

    private IEnumerator RepeatTraversalStep(float interval)
    {
        WaitForSeconds waitTime = new WaitForSeconds(interval);

        Debug.Log("Traversing Maze...");
        rc.UpdateRobotText("Processing Maze...");

        while(traversalStep())
        {
            
            yield return waitTime;
            
        }

        Debug.Log("Maze Traversal Finished");

    }

    public virtual void backtrack(Cell endLocation)
    {
        Cell curr = endLocation;

        while(curr.distance > 0)
        {

            Cell north = mg.getLocation(curr.row, curr.column + 1);
            Cell east = mg.getLocation(curr.row + 1, curr.column);
            Cell south = mg.getLocation(curr.row, curr.column - 1);
            Cell west = mg.getLocation(curr.row - 1,curr.column);

            Cell[] neighbourCells = { north, east, south, west };
            
            int num = neighbourCells.Length;

            Cell smallestDistanceCell = null;
            int testDist = int.MaxValue;
            for (int i = 0; i < num; i++)
            {
                if (neighbourCells[i].processed && neighbourCells[i].distance < testDist)
                {
                    testDist = neighbourCells[i].distance;
                    smallestDistanceCell = neighbourCells[i];
                }
            }
            curr = smallestDistanceCell;
            curr.isPath = true;
        }
    }

    protected virtual bool traversalResult()
    {
        return false;
    }

}
