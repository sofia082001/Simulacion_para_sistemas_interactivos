using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLinear : MonoBehaviour
{
    public enum MovementMode
    {
        Velocity = 0,
        Acceleration  
    }
    public myVector Velocity => velocity;

    [SerializeField] private MovementMode movementMode;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    
    private myVector acceleration;
    private myVector velocity;
    public myVector position;

    // Start is called before the first frame update
    void Start()
    {
        position.x = transform.position.x;
        position.y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position.Draw(Color.green);
        acceleration.Draw(Color.blue);
        velocity.Draw(Color.red);
        
        switch(movementMode)
        {
            case MovementMode.Velocity:
                velocity = target.position - transform.position;
                velocity.Normalized();
                velocity *= speed;
                break;

            case MovementMode.Acceleration:
                 acceleration = target.position - transform.position;
                break;
        }

        Move();
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
     
        position = position + velocity * Time.fixedDeltaTime;       
        //update unity object
        transform.position = position;

    }
}
