using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private ObjectController objcontroller_cs;

    public Transform target;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float reachedDelay = 1f;

    

    Rigidbody rb;



    [SerializeField]
    private float xRotation;

    private bool reachedPos = false;

    void Awake()
    {
        gameObject.transform.eulerAngles = new Vector3(xRotation, 90f, 0f);

        if (GameObject.FindAnyObjectByType<ObjectController>() != null)
        {
            objcontroller_cs = GameObject.FindObjectOfType<ObjectController>();
        }
        else
        {
            Debug.Log("Couldn't find object controller");
        }


        moveSpeed = objcontroller_cs.curMoveSpeed / 100;
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
                StartCoroutine(ReachedPos());
            }

        }

        else
        {
            Debug.Log("no target");
        }
    }

    public void DestroyObject(float timeMod)
    {
        objcontroller_cs.SpawnNext(timeMod);
        
        gameObject.SetActive(false);
    }

    IEnumerator ReachedPos()
    {
        yield return new WaitForSeconds(reachedDelay);
        
        rb.useGravity = true;
        rb.AddTorque(transform.up * 5);
        rb.AddTorque(transform.forward * 5);

        //adds a spin and gravity to the object when it reaches its target

        if (transform.position.y <= -10.0f)
        {

            DestroyObject(0.25f);
        }

    }


} 
