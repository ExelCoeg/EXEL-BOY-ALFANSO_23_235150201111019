
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}