using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class scoreManager : MonoBehaviour
{
    [Header("UI Element References")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image survivalTime;
    [SerializeField] glyphSpawner spawner;

    [Header("Game Values")]
    [SerializeField]
    private float maxTime = 6f;
    private float timeRemaining;
    private float fillAmount;
    public float score;
    private float minGlyphChance = 0.05f;
    private float glyphChance;

    [SerializeField]
    private float scoreIncrement = 1;

    private float combo = 1;

    public UnityEvent playerDied;

    /* Note to self: we can use a dictionary with an int property to keep track of which glyph is which and a bool property to track if its got or not */

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = maxTime;
        glyphChance = minGlyphChance;
    }

    private void FixedUpdate()
    {
        //Check for player death
        if(timeRemaining <= 0)
        {
            //Debug.Log("Death");
            playerDied.Invoke();
        }

        //Update survival timer fill (has to be a float between 0 and 1)
        timeRemaining = timeRemaining - Time.deltaTime;
        fillAmount = timeRemaining/maxTime;
        survivalTime.fillAmount = fillAmount;
    }
    
    public void scoreIncrease()
    {
        //Update Score Text
        score += scoreIncrement * combo;
        scoreText.text = "Score " + score;
        //Reset survival time and bar
        timeRemaining = maxTime;
        //Fill amount goes from 0-1
        survivalTime.fillAmount = 1;
    }

    public void addCombo()
    {
        combo += 0.1f;
    }

    public void resetCombo()
    {
        combo = 1;
    }

    //Function which gets called everytime score increases
    //Has a chance of giving a glyph and the chance increases over time
    public void glyphRoll()
    {
        //Debug.Log("glyphRoll called");
        float roll = Random.Range(0f, 1f);
        //We got a glyph and reset glyph chance
        if (roll <= glyphChance)
        {
            Debug.Log("Glyph Get!");
            spawner.spawnGlyph();
            glyphChance = minGlyphChance;
            return;
        }
        //We didn't get a glyph
        else
        {
            //If glyph chance is still small and we didn't get one, increase chance
            if(glyphChance < 0.3f)
            {
                glyphChance += 0.05f;
            }
        }

    }
}
