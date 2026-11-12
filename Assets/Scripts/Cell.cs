using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite[] _wallSprites;
    [SerializeField] private GameObject startSprite;
    [SerializeField] private GameObject endSprite;
    [SerializeField] private GameObject wallSprite;
    [SerializeField] private GameObject visitedSprite;
    [SerializeField] private GameObject pathSprite;

    private SpriteRenderer spriteRenderer;

    public int row;
    public int column;

    public bool isWall;

    [SerializeField] private bool _visited;
    public bool visited
    {
        get => _visited;
        set
        {
            if(_visited != value)
            {
                _visited = value;
                UpdateSprite();
            }
        }
    }

    public bool isStart;
    public bool isEnd;

    public int distance;


    private void Start()
    {
        if (isWall)
        {
            //Randomize Rock sprite 
            int randomRock = Random.Range(0, 2);
            wallSprite.gameObject.GetComponent<SpriteRenderer>().sprite = _wallSprites[randomRock];
            wallSprite.SetActive(true);
        }
        if (isStart)
        {
            startSprite.SetActive(true);
        }
        if (isEnd)
        {
            endSprite.SetActive(true);
        }
    }

    private void UpdateSprite()
    {
        visitedSprite.SetActive(visited);
    }
}
