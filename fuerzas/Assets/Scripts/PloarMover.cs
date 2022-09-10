using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PloarMover : MonoBehaviour
{
    [Header ("Speed Controls")]
    [SerializeField]
    myVector polarCoord;
    
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;

    // Update is called once per frame
    private void Update()
    {
        polarCoord.radius += radialSpeed * Time.deltaTime;
        polarCoord.angle = angularSpeed * Time.deltaTime;
        //transform.position = polarCoord.

    }
}
