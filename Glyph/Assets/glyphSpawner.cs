using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glyphSpawner : MonoBehaviour
{
    [SerializeField] glyphManager manager;
    [SerializeField] GameObject[] glyphs;
    [SerializeField] Vector3 spawnPos;
    List<int> remainingGlyphs;
    float spawnChance = 0.005f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawnGlyph();
    }

    public void spawnGlyph()
    {
        //Get remaining glyphs
        getRemainingGlyphs();
        //If there are remaining glyphs
        //Debug.Log(remainingGlyphs.Count);
        if(remainingGlyphs.Count > 0)
        {
            //Choose random remaining glyph and spawn it
            int choice = Random.Range(0, remainingGlyphs.Count);
            Instantiate(glyphs[choice], spawnPos, Quaternion.identity);
            manager.collectGlyph(remainingGlyphs[choice]);
            //Update remaining glyphs list
            getRemainingGlyphs();
        }
        //No remaining glyphs, send a warning
        else
        {
            Debug.LogWarning("No Glyphs Remaining");
        }
        
    }

    private void getRemainingGlyphs()
    {
        remainingGlyphs = manager.glyphsNotCollected();
    }
}
