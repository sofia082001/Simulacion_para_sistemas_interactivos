using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //para que me deje serializar las variables de esta clase en otra clase
public struct myVector //no hereda de monobehavior tampoco se puede inicializar, se almacena en el stack. es un script de c-sharp
{
    public float x;
    public float y; //hay que ponerlo en public

    public float radius { get => x; set => x = value; }
    public float angle { get => y; set => y = value; }

    public myVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public float magnitude => Mathf.Sqrt(x * x + y * y);
    public myVector normalized
    {
        get
        {
            float distance = magnitude;

            if (distance < 0.0001)
            {
                return new myVector(0, 0);
            }
            return new myVector(x / magnitude, y / magnitude);

        }
    }

    public static implicit operator myVector(Vector3 origin)
    {
        return new myVector(origin.x, origin.y);
    }
    public static implicit operator Vector3(myVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public void Normalized()
    {
        float magnitudCahce = magnitude;
        if (magnitudCahce < 0.0001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x /= magnitudCahce;
            y /= magnitudCahce;
        }

    }

    public myVector Lerp(myVector b, float c)
    {
        return (this + (b - this) * c);
    }

    public void Draw(Color color, myVector origen)
    {
        Debug.DrawLine(new Vector3(origen.x, origen.y, 0), new Vector3(x + origen.x, y + origen.y, 0), color); // en el stack solo vive el momento que se necesita
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color, 0);
    }

    public myVector Suma(myVector other)
    {
        return new myVector(x + other.x, y + other.y);
    }

    public myVector Sub(myVector other)
    {
        return new myVector(x - other.x, y - other.y);
    }
    public myVector Scale(float other)
    {
        return new myVector(x * other, y * other);
    }

    public static myVector operator +(myVector a, myVector b)
    {
        return a.Suma(b);
    }

    public static myVector operator -(myVector a, myVector b)
    {
        return a.Sub(b);
    }

    public static myVector operator *(myVector a, float b)
    {
        return a.Scale(b);
    }
    public static myVector operator *(float b, myVector a)
    {
        return a.Scale(b);
    }
    static public myVector operator /(myVector a, float b)
    {
        return new myVector(a.x / b, a.y / b);
    }
    static public myVector operator /(float b, myVector a)
    {
        return new myVector(a.x / b, a.y / b);

    }

    public struct MystructVector //en un struct no puedo heredar de otro struct
                                 //tampoco se pueden inicializar los campos al principio
    {
        private float myX;
        private float myY;

    }

    public myVector FromPolarToCartesian()
    {
        return new myVector(radius *Mathf.Cos(angle), radius * Mathf.Sin(angle));
    }
}
