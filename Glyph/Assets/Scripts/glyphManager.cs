using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Linq;

[System.Serializable]
public class saveData //Class template to save to JSON
{
    public bool[] glyphs;
}

public class glyphManager : MonoBehaviour
{
    //File path of saved glyphs
    string path = Application.dataPath + "/Glyphs.json";
    private glyphSpawner spawner;
    [SerializeField] bool resetOnStart;

    //Array of bools representing whether the glyph for that index is collected
    private bool[] glyphs;

    private void Start()
    {
        spawner = GetComponent<glyphSpawner>();
        //Initalise array to be of size 26
        glyphs = new bool[26];
        //Ensures this game object is persistent through scenes
        DontDestroyOnLoad(gameObject);
        //Read save data
        readJSON();
        //Reset JSON if resetOnStart is true
        if (resetOnStart) { resetJSON(); }
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
        List<int> notCollected = new List<int>();
        //Iterate through array of glyphs
        for (int i = 0; i < 26; i++)
        {
            if (glyphs[i] == false)
            {
                notCollected.Add(i);
            }
        }
        //Debug.Log(notColleted.Count); //Prints to console how many glyphs are left to collect
        return notCollected;
    }

    //Returns a list of every glyph which is collected
    public List<int> glyphsCollected()
    {
        //Create a list of ints which we can add e
        List<int> Collected = new List<int>();
        //Iterate through array of glyphs
        for (int i = 0; i < 26; i++)
        {
            if (glyphs[i] == true)
            {
                Collected.Add(i);
            }
        }
        //Debug.Log(notColleted.Count); //Prints to console how many glyphs are left to collect
        return Collected;
    }

    //Function to collect a glyph which sets glyph[key] to true
    //Or spits out a debug.log if that key is already collected
    public void collectGlyph(int key)
    {
        if (glyphs[key] == false)
        {
            glyphs[key] = true;
            Debug.Log("Collected glyph " + key);
        }
        else
        {
            Debug.Log("Already collected glyph " + key);
        }

        saveJSON();
    }
#region Save To Json
    //Saves glyphs array to JSON
    private void saveJSON()
    {
        saveData data = new saveData();
        data.glyphs = glyphs;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    //Reads Glyphs.json and parses it to glyphs array
    private void readJSON()
    {
        string path = Application.dataPath + "/Glyphs.json";

        // Check if the file exists
        if (File.Exists(path))
        {
            // Read the file
            string json = File.ReadAllText(path);
            //Debug.Log("JSON Data: " + json);
            saveData data = JsonUtility.FromJson<saveData>(json);

            // Check if the data was successfully loaded
            if (data != null && data.glyphs != null && data.glyphs.Length == 26)
            {
                glyphs = data.glyphs;
                Debug.Log("Glyphs loaded successfully.");
            }
            else
            {
                Debug.LogError("Loaded glyphs data is invalid.");
                // Initialize to default if invalid
                glyphs = new bool[26]; // All glyphs default to false
            }
        }
        else
        {
            Debug.LogWarning("Glyphs.json not found. Using default values.");
            // If the file does not exist, initialize glyphs to false
            glyphs = new bool[26]; // All glyphs default to false
        }
    }

    //Reset JSON of glyphs to be all false
    private void resetJSON()
    {
        saveData data = new saveData();
        glyphs = new bool[26];
        for(int i = 0; i < glyphs.Length; i++)
        {
            glyphs[i] = false;
        }
        data.glyphs = glyphs;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
}
#endregion