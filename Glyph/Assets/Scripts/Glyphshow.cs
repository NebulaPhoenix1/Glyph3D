using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyphshow : MonoBehaviour
{
    [SerializeField] glyphManager manager;
    // Start is called before the first frame update
    public GameObject[] glyphGameObjects;
    List<int> glyphsCollected;
   

    void Start()
    {
        //Get collected glyphs
        glyphsCollected = manager.glyphsCollected();
        //Loop through all collected glyphs
        foreach(int i in glyphsCollected)
        {
            //Set collected glpyhs to be enabled
            glyphGameObjects[glyphsCollected[i]].SetActive(true);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //Instantiate()
    }
}
