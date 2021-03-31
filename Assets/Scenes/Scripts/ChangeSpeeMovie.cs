using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeeMovie : MonoBehaviour // Изменение скорости движения снежинок
{
    public GameObject Spawner;
    public int i;
    public Slider slider;
    public GameObject SettingsSaver;

    void Start()
    {
        slider.value = SettingsSaver.GetComponent<SaveSettings>().SnowSpeed;
        ChangeSpeedFlake();
    }

    public void ChangeSpeedFlake()
    {
        Spawner.GetComponent<FlakeSpawn>().Speed= slider.value;
        SettingsSaver.GetComponent<SaveSettings>().SnowSpeed = slider.value;
        Spawner.GetComponent<FlakeSpawn>().ChangeCollider();
        SettingsSaver.GetComponent<SaveSettings>().SaveSet();
    }

}
