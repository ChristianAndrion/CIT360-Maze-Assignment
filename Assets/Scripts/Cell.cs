using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite[] _wallSprites;
    [SerializeField] private GameObject startSprite;
    [SerializeField] private GameObject endSprite;
    [SerializeField] private GameObject wallSprite;

    private SpriteRenderer spriteRenderer;

    public int row;
    public int column;

    public bool isWall;
    public bool visited;

    public bool isStart;
    public bool isEnd;

    int distance;


    private void Start()
    {
        if (isWall)
        {
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
}
