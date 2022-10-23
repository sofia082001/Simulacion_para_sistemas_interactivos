using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmyvector : MonoBehaviour
{
    [SerializeField] //para ponerlo en unity, tambien poner sytem.serializefield en la clase 
    private myVector myFirstVector;

    [SerializeField]
    private myVector mySecondVector;  //tiene que ser struct por que va a ser caotico para el heap

    [SerializeField,Range(0,1)]
    private float factor = 0;
    
    void Start()
    {
        //myVector sumResult = myFirstVector + mySecondVector;
        //myVector sumResult = myFirstVector - mySecondVector;

        //Debug.Log(sumResult.x);
        //Debug.Log(sumResult.y);


        //Vector2 myVariable = new Vector2();// este codigo de unity es con struct

        //Vector3.Lerp(myFirstVector, mySecondVector, 0); // Linear interpolation 
    }
    void Update()
    {
       myFirstVector.Draw(Color.blue);
        mySecondVector.Draw(Color.green);      
        myVector lerp = myFirstVector.Lerp(mySecondVector, factor);
        lerp.Draw(Color.red);

        myVector diff = myFirstVector - lerp;
        diff.Draw(Color.yellow, lerp);
    }
}
