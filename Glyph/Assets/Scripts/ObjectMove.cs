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
        moveSpeed = moveSpeed / 100;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target != null)
        {
            if (gameObject.transform.position != target.transform.position)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, moveSpeed);  
            }

            if (gameObject.transform.position == target.transform.position)
            {
               rb.AddTorque(transform.forward * 2);
                rb.useGravity = true;
            }
        }

        else
        {
            Debug.Log("no target");
        }
    }
} 
