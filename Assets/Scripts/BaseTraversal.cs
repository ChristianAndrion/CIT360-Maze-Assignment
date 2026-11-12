using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BaseTraversal : MonoBehaviour
{
    public bool isRunning;
    public int distance;

    [SerializeField] protected GameObject robot;
    private RobotController rc;

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

        while(traversalStep())
        {
            
            yield return waitTime;
            
        }

        Debug.Log("Maze Traversal Finished");

    }

    public virtual void backtrack()
    {

    }

    protected virtual bool traversalResult()
    {
        return false;
    }

}
