using UnityEngine;

public class MazeCamera : MonoBehaviour
{
    private Camera MainCamera;

    public float padding = 2f;

    private void Awake()
    {
        MainCamera = GetComponent<Camera>();
    }

    //Readjust camera based on the corners of the generated maze
    public void ReAdjustCamera(Vector2 corner1, Vector2 corner2)
    {
        float distanceX = Mathf.Abs(corner1.x - corner2.x);
        float distanceY = Mathf.Abs (corner1.y - corner2.y);

        float camHeight = distanceY / 2f;
        float camWidth = (distanceX / MainCamera.aspect) / 2f;

        float targetSize = Mathf.Max(camHeight, camWidth) + padding;

        MainCamera.orthographicSize = targetSize;

    }
}
