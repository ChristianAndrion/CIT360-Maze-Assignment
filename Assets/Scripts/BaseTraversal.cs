using UnityEngine;

public class BaseTraversal : MonoBehaviour
{
    public bool isRunning;
    public int distance;
    [SerializeField] protected MazeGenerator mg;

    protected virtual void startTraversal()
    {
        isRunning = true;
    }

    public virtual bool incrementTraversal()
    {
        return false;
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
