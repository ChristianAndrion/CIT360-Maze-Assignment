using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField widthEntry;
    [SerializeField] private TMP_InputField heightEntry;

    [SerializeField] private MazeGenerator mg;
    [SerializeField] private GameObject robot;

    [SerializeField] private GameObject sideBar;

    public Toggle stackDFSToggle;
    [SerializeField] private GameObject bottomBar;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject generator;

    [SerializeField] private StackDFS stackDFS;
    private bool stackDFSActive;

    void Awake()
    {
        //Unity subscribing 
        stackDFSToggle.onValueChanged.AddListener(OnStackDFSToggle);
    }

    private void Start()
    {

        widthEntry.text = (mg.mazeWidth).ToString();
        heightEntry.text = (mg.mazeHeight).ToString();

        bottomBar.SetActive(false);
        
    }

    public void OnGenerateNewMazeClicked()
    {
        int newWidth;
        int newHeight;

        if (int.TryParse(widthEntry.text, out int result))
        {
            newWidth = result;
        }
        else { 
            newWidth = 0;
        }

        if (int.TryParse(heightEntry.text,out result))
        {
            newHeight = result;
        }
        else
        {
            newHeight = 0;
        }

        mg.GenerateMaze(newWidth, newHeight);
    }

    public void StartButton()
    {
        sideBar.SetActive(false);
        bottomBar.SetActive(true);
        startButton.SetActive(false);
        generator.SetActive(false);

        Debug.Log("Starting...");
        if(stackDFSActive == true)
        {
            Debug.Log("Stack DFS traversal from UIController");
            stackDFS.startTraversal();
        }
    }

    public void Reset()
    {
        sideBar.SetActive(true);
        bottomBar.SetActive(false);
        startButton.SetActive(true);
        generator.SetActive(true);
    }

    public void OnStackDFSToggle(bool active)
    {
        Debug.Log("StackDFS set to: " + active);
        stackDFSActive = active;
    }

}
