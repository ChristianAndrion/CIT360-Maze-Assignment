using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite[] _wallSprites;
    private SpriteRenderer spriteRenderer;

    public int row;
    public int column;

    public bool isWall;
    public bool visited;

    int distance;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (isWall)
        {
            int randomRock = Random.Range(0, 2);
            spriteRenderer.sprite = _wallSprites[randomRock];
        }
    }
}
