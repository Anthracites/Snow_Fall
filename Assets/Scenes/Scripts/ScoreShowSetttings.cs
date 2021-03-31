using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ScoreShowSetttings : MonoBehaviour // CS for show/hide settings
{
    private void Update()

{
        if (GameObject.Find("ScoreShowCheck") == true)
        {
            if (GameObject.Find("ScoreShowCheck").GetComponent<Toggle>().isOn == false)
            {
                GameObject.Find("ScoreCounter").GetComponent<Text>().enabled = false;
            }
            else
            {
                GameObject.Find("ScoreCounter").GetComponent<Text>().enabled = true;
            }
        }
    }

    private void Start()
    {
        GameObject.Find("ScoreCounter").GetComponent<Text>().enabled = false;
    }

    public void ScoreShowHideSetttings()
    {

    }
}
