using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField widthEntry;
    [SerializeField] private TMP_InputField heightEntry;
    [SerializeField] private MazeGenerator mg;

    public GameObject sideBar;
    public GameObject bottomBar;
    public GameObject startButton;
    public GameObject generator;


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
    }

    public void Reset()
    {
        sideBar.SetActive(true);
        bottomBar.SetActive(false);
        startButton.SetActive(true);
        generator.SetActive(true);
    }
}
