using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreCounter : MonoBehaviour // CS for counting score
{
    public int Score_player = 0;
    public Text Txt_show;

    void Start()
    {


    }
    void Update()

    {

        Txt_show.text = (Score_player.ToString());

    }
}
