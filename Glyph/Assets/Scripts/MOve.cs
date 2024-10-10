using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MOve : MonoBehaviour
{
    //public GameObject area;
    [SerializeField] public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
     Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit area))
        {
            ///
            /// Debug.Log("Hi");
                transform.position = area.point - Vector3.forward;
        }
    }
}
