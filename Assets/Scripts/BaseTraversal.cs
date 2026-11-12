using UnityEngine;
using UnityEngine.UI;

public class BaseTraversal : MonoBehaviour
{
    public bool isRunning;
    public int distance;

    [SerializeField] protected GameObject robot;

    [SerializeField] private Button _incrementButton;

    private void Start()
    {
        _incrementButton.onClick.AddListener(incrementTraversal);
    }

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
