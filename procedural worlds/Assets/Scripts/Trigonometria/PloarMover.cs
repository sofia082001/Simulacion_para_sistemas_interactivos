using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PloarMover : MonoBehaviour
{

    [SerializeField] myVector polarCoord;
    
    [Header ("Speed Controls")]
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;

    // Update is called once per frame
    private void Update()
    {
        polarCoord.radius += radialSpeed * Time.deltaTime;
        polarCoord.angle += angularSpeed * Time.deltaTime;
        transform.position = polarCoord.FromPolarToCartesian();

    }
}
