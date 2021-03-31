using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeed : MonoBehaviour // Изменение скорости спавна снежинок
{
    public GameObject Spawner;
    public Slider slider;
    public GameObject SettingsSaver;

    void Start()
    {
        slider.value = SettingsSaver.GetComponent<SaveSettings>().SnowAmount;
        ChangeFlakeSpeed();
    }

    public void ChangeFlakeSpeed()
    {
        Spawner.GetComponent<FlakeSpawn>().j = slider.value;
        SettingsSaver.GetComponent<SaveSettings>().SnowAmount = slider.value;
        SettingsSaver.GetComponent<SaveSettings>().SaveSet();
    }
}
