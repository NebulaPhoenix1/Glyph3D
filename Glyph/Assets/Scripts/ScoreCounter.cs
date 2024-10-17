using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Counter : MonoBehaviour
{using UnityEngine;
using System.Collections;
using namespace;

int score = 0;

public void AddToCounter()
{
    ++Counter;

    guiText.text = "Count " + score.ToString();
}
}
