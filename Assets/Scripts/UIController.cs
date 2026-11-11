using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField widthEntry;
    [SerializeField] private TMP_InputField heightEntry;
    [SerializeField] private MazeGenerator mg;

    private void Start()
    {
        widthEntry.text = (MazeGenerator.mazeWidth).ToString();
        heightEntry.text = (MazeGenerator.mazeHeight).ToString();  
        
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

    
}
