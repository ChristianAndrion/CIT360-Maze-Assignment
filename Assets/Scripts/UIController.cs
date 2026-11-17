using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField widthEntry;
    [SerializeField] private TMP_InputField heightEntry;

    [SerializeField] private MazeGenerator mg;
    [SerializeField] private GameObject robot;

    [Header("Panels")]
    [SerializeField] private GameObject sideBar;
    [SerializeField] private GameObject bottomBar;
    [SerializeField] private GameObject generator;

    [Header("Traversal Toggles")]
    public Toggle stackDFSToggle;
    public Toggle queueBFSToggle;


    [Header("Buttons")]
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject completeButton;
    [SerializeField] private GameObject incrementButton;

    [Header("Traversal Objects")]
    [SerializeField] private StackDFS stackDFS;
    [SerializeField] private QueueBFS queueBFS;

    private bool stackDFSActive;
    private bool queueBFSActive;

    private void OnEnable()
    {
        BaseTraversal.OnComplete += ShowBottomBar;
    }


    private void OnDisable()
    {
        BaseTraversal.OnComplete -= ShowBottomBar;
    }


    void Awake()
    {
        //Unity subscribing 
        stackDFSToggle.onValueChanged.AddListener(OnStackDFSToggle);
        queueBFSToggle.onValueChanged.AddListener(OnQueueBFSToggle);

        completeButton.GetComponent<Button>().onClick.AddListener(OnCompleteClicked);

    }

    private void Start()
    {

        widthEntry.text = (mg.mazeWidth).ToString();
        heightEntry.text = (mg.mazeHeight).ToString();

        bottomBar.SetActive(false);
        
        stackDFSActive = true;
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

        if(queueBFSActive == true)
        {
            Debug.Log("Queue BFS traversal from UIController");
            queueBFS.startTraversal();

        }
    }

    public void Reset()
    {
        sideBar.SetActive(true);
        bottomBar.SetActive(false);
        startButton.SetActive(true);
        generator.SetActive(true);
        completeButton.SetActive(true);
        incrementButton.SetActive(true);

        mg.ResetMaze();
    }

    private void OnCompleteClicked()
    {
        bottomBar.SetActive(false);
    }

    private void ShowBottomBar()
    {
        completeButton.SetActive(false);
        incrementButton.SetActive(false);
        bottomBar.SetActive(true);
    }

    public void OnStackDFSToggle(bool active)
    {
        Debug.Log("StackDFS set to: " + active);
        stackDFSActive = active;
    }

    public void OnQueueBFSToggle(bool active)
    {
        Debug.Log("QueueBFS set to: " + active);
        queueBFSActive = active;
    }


}
