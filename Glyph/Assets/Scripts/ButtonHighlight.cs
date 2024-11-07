using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class ButtonHighlight : MonoBehaviour
{
    //defines both textmeshpro component so they can be used for changing image/text colour later.
    public TextMeshProUGUI textcomponent;
    float r;  // red component
    float g;  // green component
    float b;  // blue component
    public Color32 lightblue;
    private void Start()
    {
        lightblue = new Color(93, 226, 231);
    }

    //
    public void Replay()
    {
        textcomponent.color = Color.cyan;
    }
}
//#26FFFF