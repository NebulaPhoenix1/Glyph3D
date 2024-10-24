using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
    [SerializeField]
    private string direction;

    private ObjectMove objmove_cs;

    private int health = 8;

    private scoreManager scoreManager;

    private void Awake()
    {
        if (GetComponent<ObjectMove>())
        {
            objmove_cs = GetComponent<ObjectMove>();
        }
        if(GameObject.FindObjectOfType<scoreManager>())
        {
            scoreManager = GameObject.FindObjectOfType<scoreManager>();
        }
    }

    public void Check(string dir)
    {
        if (objmove_cs.canHit == true)
        {

            if (direction == "Omni")
            {
                if (health != 0)
                {
                    scoreManager.scoreIncrease();
                    scoreManager.addCombo();
                    health--;
                }

                else
                    objmove_cs.DestroyObject(1);


            }

            if (dir == direction)
            {

                Debug.Log("Correct!");
                scoreManager.scoreIncrease();
                objmove_cs.DestroyObject(1);
                //correct
                //Chance of spawning glyph
                scoreManager.glyphRoll();
            }

            else
                objmove_cs.DestroyObject(1);


        }

    }

 
}
