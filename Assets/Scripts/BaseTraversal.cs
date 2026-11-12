using UnityEngine;

public class BaseTraversal : MonoBehaviour
{
    public bool isRunning;
    public int distance;

    [SerializeField] protected GameObject robot;

    public virtual void startTraversal()
    {
        isRunning = true;
    }

    public virtual bool traversalStep()//Override this with the algorithm
    {
        return false;
    }

    public virtual void incrementTraversal() //This is called by the increment button which effectively just calls traversal step once
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

}
