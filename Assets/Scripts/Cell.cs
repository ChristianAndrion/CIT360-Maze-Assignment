using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite[] _wallSprites;
    [SerializeField] private GameObject startSprite;
    [SerializeField] private GameObject endSprite;
    [SerializeField] private GameObject wallSprite;
    [SerializeField] private GameObject visitedSprite;
    [SerializeField] private GameObject processedSprite;
    [SerializeField] private GameObject pathSprite;

    [SerializeField] private TextMeshProUGUI distanceText;
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

    [SerializeField] private bool _processed;
    public bool processed
    {
        get => _processed;
        set
        {
            if(_processed != value)
            {
                _processed = value;
                UpdateSprite();
            }
        }
    }

    [SerializeField] private bool _isPath;
    public bool isPath
    {
        get => _isPath;
        set
        {
            if(_isPath != value)
            {
                _isPath = value;
                UpdateSprite();
            }
        }
    }

    public bool isStart;
    public bool isEnd;
    private int _distance;
    public int distance
    {
        get => _distance;
        set
        {
            if(_distance != value)
            {
                _distance = value;
                UpdateDistance();
            }
        }
    }

    private void Start()
    {
        if (isWall)
        {
            //Randomize Rock sprite 
            int randomRock = Random.Range(0, 2);
            wallSprite.gameObject.GetComponent<SpriteRenderer>().sprite = _wallSprites[randomRock];
            wallSprite.SetActive(true);
            distanceText.text = "";
        }
        if (isStart)
        {
            startSprite.SetActive(true);
            distanceText.text = "";
        }
        if (isEnd)
        {
            endSprite.SetActive(true);
            distanceText.text = "";
        }
    }

    private void UpdateSprite()
    {
        visitedSprite.SetActive(visited);
        processedSprite.SetActive(processed);
        pathSprite.SetActive(isPath);
    }

    private void UpdateDistance()
    {
        distanceText.text = distance.ToString();
    }

    public void Reset()
    {
        visited = false;
        processed = false;
        isPath = false;
        distance = 0;
        
    }
}
