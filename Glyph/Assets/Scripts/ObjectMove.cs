using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        rb.angularVelocity = Vector3.zero;
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
               rb.AddTorque(transform.up * 5);
                rb.AddTorque(transform.forward * 5);

                rb.useGravity = true;
            }
        }

        else
        {
            Debug.Log("no target");
        }
    }
} 
