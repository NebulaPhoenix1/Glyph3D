using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class glyphManager : MonoBehaviour
{
    //Array of bools representing whether the glyph for that index is collected
    private bool[] glyphs;
   
    private void Start()
    {
        //Initalise array to be of size 26
        glyphs = new bool[26];
        //Ensures this game object is persistent through scenes
        DontDestroyOnLoad(gameObject);
        //Initalise glyphs to false (all 26)
        for (int i = 0; i < 26; i++)
        {
            glyphs[i] = false;
            //Debug.Log(glyphs[i]);
        }
    }

    //Returns value at glyphs[key] so true if collected, false if not
    public bool glyphCollectedCheck(int key)
    {
        return glyphs[key];
    }

    //Returns a list of every glyph which is not collected
    public List<int> glyphsNotCollected()
    {
        //Create a list of ints which we can add e
        List<int> notColleted = new List<int>();
        //Iterate through array of glyphs
        for(int i = 0; i < 26; i++)
        {
            if (glyphs[i] == false)
            {
                notColleted.Add(i);
            }
        }
        return notColleted;
    }

    //Function to collect a glyph which sets glyph[key] to true
    //Or spits out a debug.log if that key is already collected
    public void collectGlyph(int key)
    {
        if (glyphs[key] == false)
        {
            glyphs[key] = true;
            Debug.Log("Collected glyph " + key );
        }
        else
        {
            Debug.Log("Already collected glyph " + key);
        }
    }
}
