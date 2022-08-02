using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //para que me deje serializar las variables de esta clase en otra clase
public struct myVector //no hereda de monobehavior tampoco se puede inicializar, se almacena en el stack. es un script de c-sharp
{
    public float x;
    public float y; //hay que ponerlo en public


    public myVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static implicit operator Vector3(myVector origin)
    {
        return new Vector3(origin.x, origin.y, 0);
    }

    public myVector Lerp(myVector b, float c)
    {
        return (this + (b - this) * c);
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color, 0); // en el stack solo vive el momento que se necesita
    }

    public void Draw(Color color, myVector origen)
    {
        Debug.DrawLine(new Vector3(origen.x, origen.y,0), new Vector3(x + origen.x, y+ origen.y, 0), color) ; // en el stack solo vive el momento que se necesita
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
     
    public static myVector operator * (myVector a, float b)
    {
        return a.Scale(b);
    }
    public static myVector operator *(float b, myVector a)
    {
        return a.Scale(b);
    } 

}

public struct MystructVector //en un struct no puedo heredar de otro struct
    //tampoco se pueden inicializar los campos al principio
{
    private float myX;
    private float myY;

}
