﻿using UnityEngine;
using UnityEngine.UI;

public class NextLevelSlider : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Text>().text=(PlayerPrefs.GetInt("Level",1)+1).ToString();
    }
}
