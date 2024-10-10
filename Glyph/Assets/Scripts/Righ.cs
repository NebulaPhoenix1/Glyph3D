using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Righ : MonoBehaviour
{
    scoreManager score;
    [SerializeField] GameObject ScoreManager;
    // Start is called before the first frame update
    private void Awake()
    {////get the score script
       // score = 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // Input.GetAxis
        if (Input.GetMouseButtonDown(0)) ///&& Right)
        {
            Debug.Log("press");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Not pressed");
        }
                /// //mouse x n  y traking
        }

    public void hit()
    {
        ///boolian on if the mouse  moved x 
        ///if true refcrence score script
        ///kill  object
    }
}
