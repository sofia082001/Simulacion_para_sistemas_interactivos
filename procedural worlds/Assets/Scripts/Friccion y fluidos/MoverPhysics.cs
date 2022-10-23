using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPhysics : MonoBehaviour
{
    [SerializeField] private float mass = 1f;
    [SerializeField] private myVector Wind;

    [Header("Other")]
    [SerializeField] private bool useFluidFriction = false;
    [SerializeField] private float gravity= -9.8f;
    [Range(0, 1)][SerializeField] private float dampingFactor = 1f;
    [SerializeField] private float fricctionCoeficiente = 0.5f;

    private myVector aceleration; // que tanto cambia la velocidad en el tiempo
    private myVector position;
    private myVector velocity;// que tanto cambia la posicion en una cantidad del tiempo
    
    void Start()
    {
        position = new myVector(transform.position.x, transform.position.y);
    }

    
    private void FixedUpdate()
    {
        //update the position
        aceleration *= 0f;
        
        //Apply gravity
        myVector weight = new myVector(0, mass*gravity);
        Applyforce(weight);
       
        //Apply friction
       if (useFluidFriction)
       {
            if(transform.position.y <= 0)
            {
                float velocityMagnitud = velocity.magnitude;
                float frontalArea = transform.localScale.x;
                myVector fluidFriction = velocity.normalized * frontalArea * velocityMagnitud * velocityMagnitud * -0.5f;
                Applyforce(fluidFriction);
            }
       }        
       else
       {
            float weightScalar = -mass * gravity;
            myVector fricction = (velocity.normalized * fricctionCoeficiente * weightScalar) * -1;
            Applyforce(fricction);
            fricction.Draw(Color.white);
       }
        
        //Apply fluid friction
        Move();

    }

    void Update()
    {
        //position.Draw(Color.green);
        //aceleration.Draw(Color.blue);
        velocity.Draw(Color.red);    
    }

    public void Move()
    {
        //m/s + ()m*s/s*s) = m/s +(m/s)
        velocity = velocity + aceleration * Time.fixedDeltaTime;//integral de la aceleracion
        
        //m + (m/s) *s = m+m
        position = position + velocity *Time.fixedDeltaTime;//integral de la velocidad
        //check bounds
        if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x = -velocity.x;
            velocity *= dampingFactor;
        }

        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y = -velocity.y; // displacement es la direccion.
            velocity *= dampingFactor; //escalar el vector de velocidad para que cada vez se mas pequeno
        }
        //update unity object
        transform.position = position;
    }

    void Applyforce (myVector force)
    {
        aceleration += force * (1f/ mass);
    }
}

