using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private myVector acceleration;
    [SerializeField] private myVector velocity;
    private myVector position;
    private myVector displacement;

    private int currentAccelIndex = 0;
    private myVector[] acelerations = new myVector[4]
    {
         new myVector(0f,-9.8f),
         new myVector(9.8f,0f),
         new myVector(0f,9.8f),
         new myVector(-9.8f,0f),
    };
    // Start is called before the first frame update
    void Start()
    {
        position.x = transform.position.x;
        position.y = transform.position.y;
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
        acceleration.Draw(Color.blue);
        velocity.Draw(Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            acceleration = acelerations[(currentAccelIndex++) % acelerations.Length];
        }
        acceleration.x = target.position.x - transform.position.x;
        acceleration.y = target.position.y - transform.position.y;
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
     
        position = position + velocity * Time.fixedDeltaTime;

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
