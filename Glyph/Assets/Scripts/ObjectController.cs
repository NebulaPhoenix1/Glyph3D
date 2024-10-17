using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] objectsToSpawn;

    [SerializeField]
    private Transform startPoint, endPoint;

    [SerializeField]
    private float timeBetweenSpawns = 0.75f;

    [SerializeField]
    private float startMoveSpeed = 1, maxMoveSpeed = 5;

    public float curMoveSpeed;

    private bool objectEnabled;

    private bool shouldSpawn = true;

    void Start()
    {
        curMoveSpeed = startMoveSpeed;
        SpawnObject();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SpawnObject();
        }


    }

    public void SpawnNext(float timeMod)
    {
        StartCoroutine(Delay(timeBetweenSpawns * timeMod));
        if (curMoveSpeed < maxMoveSpeed)
        {
            curMoveSpeed += 0.05f;
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

            if (currentObj.GetComponent<ObjectMove>() != null)
            {
                currentObj.GetComponent<ObjectMove>().target = endPoint;
            }

            //spawns an object in and assigns its target
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);

        SpawnObject();


    }


}
