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
        GenerateMaze(mazeWidth, mazeHeight);
    }
    public void GenerateMaze(int Width, int Height)
    {
        CreateGrid(Width, Height);
    }
    
    private void CreateGrid(int Width, int Height)
    {
        mazeGrid = new GameObject[Width+1,Height+1];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector2 cellPos = new Vector2(x * cellSize, y * cellSize);

                GameObject newCell = Instantiate(Cell, cellPos, Quaternion.identity);

                newCell.transform.parent = this.transform;
                newCell.name = $"Cell_{x}_{y}";

                mazeGrid[x,y] = newCell;
            }
        }



    }

}

