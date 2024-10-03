using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToSpawn;

    [SerializeField]
    private Transform startPoint, endPoint;


    private bool objectEnabled;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SpawnObject();
        }



    }

    void SpawnObject()
    {
        if (!objectEnabled)
        {
            GameObject currentObj = Instantiate(objectToSpawn, startPoint.position, Quaternion.identity);
           
            if(currentObj.GetComponent<ObjectMove>() != null)
            {
                currentObj.GetComponent<ObjectMove>().target = endPoint;
            }
        }
    }

           
}