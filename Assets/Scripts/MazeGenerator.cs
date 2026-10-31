using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Cell Cell;
    [SerializeField] private MazeCamera MainCamera;
    [SerializeField] private GameObject robot;
    public float cellSize = 1.1f;

    public int mazeWidth;
    public int mazeHeight;

    public Vector2 startLocation;
    public Vector2 endLocation;

    private int gridWidth;
    private int gridHeight;

    private Cell[,] mazeGrid;

    private void Start()
    {
        //Generate initial maze based of mazeWidth and mazeHeight set in editor
        GenerateMaze(mazeWidth, mazeHeight);
    }

    public void GenerateMaze(int Width, int Height)
    {
        //Checks if there is a maze then deletes it
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
        ChooseRandomStartAndFinish(Width, Height);
    }
    
    private void CreateGrid(int Width, int Height)
    {
        //+2 to account for the outer wall
        gridWidth = Width + 2;
        gridHeight = Height + 2;

        mazeGrid = new Cell[gridWidth,gridHeight];

        //Offset maze so its center is the game object the script is on
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

                newCell.row = x;
                newCell.column = y;

                mazeGrid[x,y] = newCell;
            }
        }
        
        //Dynamically adjust the camera after a maze is generated
        //Refer to MazeCamera.cs
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
                //50% chance to generate a rock obstacle 
                float randomRock = Random.Range(0, 1.0f);
                if (randomRock > 0.5f)
                {
                    mazeGrid[x, y].isWall = true;
                }
                
            }
        }
    }

    private void ChooseRandomStartAndFinish(int Width, int Height)
    {
        bool validStart = false;

        while (!validStart)
        {
            int randStartX = Random.Range(1, Width);
            int randStartY = Random.Range(1, Height);

            if (mazeGrid[randStartX, randStartY].isWall)
            {
                validStart = false;
            }
            else
            { 
                mazeGrid[randStartX,randStartY].isStart = true;
                startLocation = new Vector2(randStartX, randStartY);
                robot.gameObject.transform.position = mazeGrid[randStartX, randStartY].transform.position;
                validStart = true;
            }
        }

        bool validEnd = false;
        while (!validEnd)
        {
            int randEndX = Random.Range(1, Width);
            int randEndY = Random.Range(1, Height);

            if (mazeGrid[randEndX, randEndY].isWall || mazeGrid[randEndX,randEndY].isStart)
            {
                validEnd = false;
            }
            else
            {
                mazeGrid[randEndX,randEndY].isEnd = true;
                endLocation = new Vector2(randEndX, randEndY);
                validEnd = true;
            }
        }
    }

    public Cell getLocation(Vector2 locationVector)
    {
        return mazeGrid[(int)locationVector.x,(int)locationVector.y];
    }
}

