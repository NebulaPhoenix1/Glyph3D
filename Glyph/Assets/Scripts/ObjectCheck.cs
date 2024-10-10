using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
    [SerializeField]
    private string direction;



    public void Check(string dir)
    {
        if (dir == direction)
        {
            Debug.Log("Correct!");
            Destroy(gameObject);
            //correct
        }

        else
        {
            Debug.Log("wrong");
            //wrong!

        }
    }

 
}
