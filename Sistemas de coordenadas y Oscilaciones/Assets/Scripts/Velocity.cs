using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    private myVector aceleration; // que tanto cambia la velocidad en el tiempo
    private myVector position;
    private myVector velocity;// que tanto cambia la posicion en una cantidad del tiempo
    private myVector displacement;

    private int currentAccelIndex = 0;
    private myVector[] acelerations = new myVector[4]
    {
         new myVector(0f,-9.8f),
         new myVector(9.8f,0f),
         new myVector(0f,9.8f),
         new myVector(-9.8f,0f),
    };
    
    void Start()
    {
        position = new myVector(transform.position.x, transform.position.y);
                
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.green);
        displacement.Draw(Color.clear);
        aceleration.Draw(Color.blue);
        velocity.Draw(Color.red);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            aceleration = acelerations[(currentAccelIndex++) % acelerations.Length];            
        }
        

    }

    public void Move()
    {
        velocity = velocity + aceleration * Time.fixedDeltaTime;
        //calculate displacement and new position
        displacement = velocity * Time.fixedDeltaTime;
        position += displacement;

        //check bounds
        if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x = -velocity.x;
        }

        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y = -velocity.y; // displacement es la direccion.
        }
        //update unity object
        transform.position = position;

    }
}
