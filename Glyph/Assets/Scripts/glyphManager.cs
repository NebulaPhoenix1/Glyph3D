using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class glyphManager : MonoBehaviour
{
    //Array of bools representing whether the glyph for that index is collected
    public bool[] glyphs;
   
    private void Start()
    {
        glyphs = new bool[26];
        //Ensures this game object is persistent through scenes
        DontDestroyOnLoad(gameObject);
        //Initalise glyphs to false (all 26)
        for (int i = 0; i < 26; i++)
        {
            glyphs[i] = false;
        }
    }

    //Returns value at glyphs[key] so true if collected, false if not
    public bool glyphCollectedCheck(int key)
    {
        return glyphs[key];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
