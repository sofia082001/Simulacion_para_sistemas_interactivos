using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = GetWorldMousePosition();
        lookAt(mouseWorldPosition);

    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector4 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

   private void lookAt(Vector3 targetPosition)
    {
        Vector3 thisposition = new Vector3(transform.position.x, transform.position.y);
        Vector3 foward = targetPosition - thisposition;
        float radians = Mathf.Atan2(foward.y, foward.x);
        RotateZ(radians);
   }
}
