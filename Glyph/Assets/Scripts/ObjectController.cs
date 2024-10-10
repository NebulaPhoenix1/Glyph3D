using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] objectsToSpawn;

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


    int ChooseObject()
    {
       return Random.Range(0, objectsToSpawn.Length);
    }

    void SpawnObject()
    {
        if (!objectEnabled)
        {
            GameObject currentObj = Instantiate(objectsToSpawn[ChooseObject()], startPoint.position, Quaternion.identity);
           
            if(currentObj.GetComponent<ObjectMove>() != null)
            {
                currentObj.GetComponent<ObjectMove>().target = endPoint;
            }

            //spawns an object in and assigns its target
        }
    }

           
}
