using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

    public Transform target;
    [SerializeField]
    private float moveSpeed;
    Rigidbody rb;

    private bool reachedPos = false;

    void Awake()
    {
        moveSpeed = moveSpeed / 100;
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;

    }

    void Update()
    {
        if (target != null)    // checks there is a target assigned by the object controller
        {
            if (gameObject.transform.position == target.transform.position) //checks the object has reached its target
            {
                reachedPos = true;

            }

            if (!reachedPos)
            {
                if (gameObject.transform.position != target.transform.position) //checks the gameobject hasn't reached its target
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, moveSpeed);  //moves the gameobject to its target
                }
            }

            if(reachedPos)
            {
                rb.useGravity = true;
                rb.AddTorque(transform.up * 5);
                rb.AddTorque(transform.forward * 5);

                //adds a spin and gravity to the object when it reaches its target

                if(transform.position.y <= -10.0f)
                {
                    DestroyObject();
                }
            }

        }

        else
        {
            Debug.Log("no target");
        }
    }

    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
} 
