using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite _wallSprite;
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
            spriteRenderer.sprite = _wallSprite;
        }
    }
}
