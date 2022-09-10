using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atraciongravitacional : MonoBehaviour
{
    [SerializeField] private myVector aceleration; // que tanto cambia la velocidad en el tiempo  
    [SerializeField] private myVector velocity;
    [SerializeField] private atraciongravitacional target;
    public myVector position;
    public float mass = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        position.x = transform.position.x;
        position.y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aceleration *= 0;
        //apply gravity
        myVector r = new myVector();
        r.x = target.transform.position.x - transform.position.x;
        r.y = target.transform.position.y - transform.position.y;

        float rMagnitud = r.magnitude;
        myVector f = r.normalized * (target.mass * mass / rMagnitud * rMagnitud);
        
        
        Applyforce(f);

        f.Draw(Color.blue, position);
        Move();
    }

    private void Update()
    {
        velocity.Draw(Color.red,position);
    }
    public void Move()
    {
        //m/s + ()m*s/s*s) = m/s +(m/s)
        velocity = velocity + aceleration * Time.fixedDeltaTime;//integral de la aceleracion

        //m + (m/s) *s = m+m
        position = position + velocity * Time.fixedDeltaTime;//integral de la velocidad

        //check bounds
        if(velocity.magnitude > 5)
        {
            velocity.Normalized();
            velocity *= 5;
        }
        //update unity object
        transform.position = position;
    }

    void Applyforce(myVector force)
    {
        aceleration += force / mass;        
    }
}
