using TMPro;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI robotTextBox;

    public void UpdateRobotText(string newText)
    {
        robotTextBox.text = "ROBOT STATUS: " + newText;
    }

}
