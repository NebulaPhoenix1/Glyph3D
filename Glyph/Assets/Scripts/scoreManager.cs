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
    [SerializeField] Scrollbar survivalTime;

    private float maxTime = 3f;
    private float timeRemaining;
    public float score;
    private float glyphChance = 0.05f;

    public UnityEvent playerDied;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = maxTime;
    }

    private void FixedUpdate()
    {
        //Check for player death
        if(timeRemaining <= 0)
        {
            playerDied.Invoke();
        }
    }
    
    public void scoreIncrease()
    {
        //Update Score Text
        score++;
        scoreText.text = "Score " + score;
        //Reset survival time and bar
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
