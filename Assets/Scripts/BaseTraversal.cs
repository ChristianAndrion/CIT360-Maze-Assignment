using Unity.VisualScripting;
using UnityEngine;

public class BaseTraversal : MonoBehaviour
{
    public bool isRunning;
    public int distance;

    protected GameObject robot;

    public virtual void startTraversal()
    {
        isRunning = true;
    }

    public virtual bool traversalStep()
    {
        return false;
    }

    public virtual void incrementTraversal()
    {
        
    }

    public virtual void completeTraversal()
    {

    }

    public virtual void backtrack()
    {

    }

    protected virtual bool traversalResult()
    {
        return false;
    }

    protected void moveRobot(Vector2 newLocation)
    {
        robot.gameObject.transform.position = newLocation;
    }

}
