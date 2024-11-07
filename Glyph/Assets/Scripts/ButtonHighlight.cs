using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class ButtonHighlight : MonoBehaviour
{
    //defines both text/image component so they can be used for changing image/text colour later.
    public TextMeshProUGUI textcomponent;
    public Image imagecomponent;

    public void Replay()
    {
        textcomponent.color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        textcomponent.color = Color.gray;
        imagecomponent.enabled = false;
    }
}
