using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Cell Cell;
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
        CreateGrid(Width, Height);
        CreateOuterWalls();
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

}

