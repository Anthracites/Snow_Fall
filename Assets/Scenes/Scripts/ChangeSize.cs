using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSize : MonoBehaviour // Ghange size of flakes
{
    public GameObject Spawner;
    public GameObject FlakeSizePref;
    public Slider slider; 
    public GameObject SettingsSaver;

    void Start()
    {
        slider.value = SettingsSaver.GetComponent<SaveSettings>().SnowSize;
        ChangeSizeFlakes();
        Debug.Log("Size downloaded from Windows Registry");
    }

   public void ChangeSizeFlakes()
    {
        Spawner.GetComponent<FlakeSpawn>().Size = slider.value;
        SettingsSaver.GetComponent<SaveSettings>().SnowSize = slider.value;
        Spawner.GetComponent<FlakeSpawn>().ChangeCollider();
        SettingsSaver.GetComponent<SaveSettings>().SaveSet();
        Debug.Log("Size changed and loaded to Windows Registry");
    }
}
