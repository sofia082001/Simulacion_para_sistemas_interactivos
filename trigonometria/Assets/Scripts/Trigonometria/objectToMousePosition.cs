using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectToMousePosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = GetWorldMousePosition();
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector4 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}
