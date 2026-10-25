using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Cell;
    public float cellSize = 1.1f;

    public int mazeWidth;
    public int mazeHeight;

    private GameObject[,] mazeGrid;

    private void Start()
    {
        //Temp to test generation
        GenerateMaze(mazeWidth, mazeHeight);
    }

    public void GenerateMaze(int Width, int Height)
    {
        CreateGrid(Width, Height);
    }
    
    private void CreateGrid(int Width, int Height)
    {
        int widthWithWall = Width + 2;
        int heightWithWall = Height + 2;

        mazeGrid = new GameObject[widthWithWall,heightWithWall];

        float xOffset = ((widthWithWall - 1) * cellSize) / 2f;
        float yOffset = ((heightWithWall - 1) * cellSize) / 2f;

        for (int x = 0; x < widthWithWall; x++)
        {
            for (int y = 0; y < heightWithWall; y++)
            {
                Vector2 cellPos = new Vector2((x * cellSize) - xOffset, (y * cellSize)- yOffset);

                GameObject newCell = Instantiate(Cell, cellPos, Quaternion.identity);

                newCell.transform.parent = this.transform;
                newCell.name = $"Cell_{x}_{y}";

                mazeGrid[x,y] = newCell;
            }
        }



    }

}

