using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class glyphManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Ensures this game object is peristent (doesn't get destroyed on loading a new scene)
        DontDestroyOnLoad(this.gameObject);
        //Create dictionary of glyphs - int for glyph number and bool for whether we've collected it or not.
        Dictionary<int, bool> glyphList = new Dictionary<int, bool>();
        //Set up inital glyphs (22)
        for (int i = 0; i < 22; i++)
        {
            glyphList.Add(i, false);
        }

        //Print dictionary
        //Thank you reddit literal life savers
        foreach (var item in glyphList)
        {
            Debug.Log($"Key: {item.Key}, Value: {item.Value}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
