using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilations : MonoBehaviour
{

    private Vector3 initialPosition;
    [SerializeField] private float period = 3;
    [SerializeField] private float alcance = 3;

    private float rhu = 1; 

    private void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        
        //rhu = Mathf.Sin(2f * Mathf.Sin (7f * Time.time) + Mathf.Sin(4f*Time.time) + Mathf.Sin(2f * Time.time) + Mathf.Sin(3f * Time.time)); 
        //transform.position = initialPosition + Vector3.right * rhu * alcance; //MOVIMIENTOS RANDOM
       
        transform.position = initialPosition + Vector3.right * Mathf.Sin(2f * Mathf.PI * (Time.time / period)) * alcance; //MOVIMIENTO HORIZONTAL CON FORMULA del periodo
        
        //transform.position = initialPosition + (Vector3.right + Vector3.up) * Mathf.Sin(Time.time * period) * alcance;    //MOVIMIENTO DIAGONAL
        

    }
}
