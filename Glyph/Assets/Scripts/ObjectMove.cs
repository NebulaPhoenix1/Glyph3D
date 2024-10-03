using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

    public Transform target;
    [SerializeField]
    private float moveSpeed;
    Rigidbody rb;


    void Awake()
    {
        
    }

    void Update()
    {
        if (target != null)
        {
            if (gameObject.transform.position != target.transform.position)
            {

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, moveSpeed);
                
            }
        }

        else
        {
            Debug.Log("no target");
        }
    }
} 
