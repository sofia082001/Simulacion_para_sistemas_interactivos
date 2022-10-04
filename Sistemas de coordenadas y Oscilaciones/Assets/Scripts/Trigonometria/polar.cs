using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polar : MonoBehaviour
{
    [SerializeField]
    private float angle;

    [SerializeField]
    private float radius =1f;

    [SerializeField]
    private float angluarSpeed = 5;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        PolarToCartesian(angle, radius).Draw(Color.black);
        angle = angle  + angluarSpeed * Time.deltaTime;
    }
    public myVector fromPolarToCartesiona()
    {
        myVector vector = new myVector(x * Mathf.Cos(angle), x * Mathf.Sin(angle));
        return vector;
    }
    public myVector PolarToCartesian(float angle,float rad)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);  //coseno del angulo para x
        float y = Mathf.Sin(angle * Mathf.Deg2Rad); //coseno del angulo para y       
        return new myVector(x * rad, y * rad);
    }
}
