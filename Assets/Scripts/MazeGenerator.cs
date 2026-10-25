using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Cell Cell;
    [SerializeField] private MazeCamera MainCamera;
    public float cellSize = 1.1f;

    public int mazeWidth;
    public int mazeHeight;

    private int gridWidth;
    private int gridHeight;

    private Cell[,] mazeGrid;

    private void Start()
    {
        //Temp to test generation
        GenerateMaze(mazeWidth, mazeHeight);
    }

    public void GenerateMaze(int Width, int Height)
    {
        if(mazeGrid != null)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        CreateGrid(Width, Height);
        CreateOuterWalls();
        GenerateObstacles(Width, Height);
    }
    
    private void CreateGrid(int Width, int Height)
    {
        gridWidth = Width + 2;
        gridHeight = Height + 2;

        mazeGrid = new Cell[gridWidth,gridHeight];

        float xOffset = ((gridWidth - 1) * cellSize) / 2f;
        float yOffset = ((gridHeight - 1) * cellSize) / 2f;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 cellPos = new Vector2((x * cellSize) - xOffset, (y * cellSize)- yOffset);

                Cell newCell = Instantiate(Cell, cellPos, Quaternion.identity);

                newCell.transform.parent = this.transform;
                newCell.name = $"Cell_{x}_{y}";

                mazeGrid[x,y] = newCell;
            }
        }

        MainCamera.ReAdjustCamera(mazeGrid[0, 0].transform.position, mazeGrid[gridWidth - 1, gridHeight - 1].transform.position);
    }

    private void CreateOuterWalls()
    {

        //Traverse top and bottom row:
        for(int X = 0; X < gridWidth; X++)
        {
            mazeGrid[X, gridHeight - 1].isWall = true;
            mazeGrid[X, 0].isWall = true;
        }

        //Traverse right and left column
        for(int Y = 0; Y < gridHeight; Y++)
        {
            mazeGrid[gridWidth - 1, Y].isWall = true;
            mazeGrid[0, Y].isWall = true;
        }

    }

    private void GenerateObstacles(int Width, int Height)
    {
        //Start at 1 to avoid the outer wall
        for (int x = 1; x < Width; x++)
        {
            for(int y = 1; y <  Height; y++)
            {
                float randomRock = Random.Range(0, 1.0f);
                if (randomRock > 0.5f)
                {
                    mazeGrid[x, y].isWall = true;
                }
                
            }
        }
    }
}

