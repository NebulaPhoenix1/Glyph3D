using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
    [SerializeField]
    private string direction;

    private ObjectMove objmove_cs;

    private void Awake()
    {
        if (GetComponent<ObjectMove>())
        {
            objmove_cs = GetComponent<ObjectMove>();
        }
    }

    public void Check(string dir)
    {
        if (dir == direction)
        {
            
            Debug.Log("Correct!");
            objmove_cs.DestroyObject(1); 
            //correct
        }

        else
        {
            Debug.Log("wrong");
            //wrong!

        }
    }

 
}
