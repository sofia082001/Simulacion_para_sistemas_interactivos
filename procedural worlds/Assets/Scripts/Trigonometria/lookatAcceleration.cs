using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatAcceleration : MonoBehaviour
{
    [SerializeField] private MoverLinear mover;
    private Vector3 direction; 
 
    void Update()
    {
        direction = mover.Velocity; 
        float radians = Mathf.Atan2(direction.y, direction.x);
        RotateZ(radians);
    }
    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }


}
