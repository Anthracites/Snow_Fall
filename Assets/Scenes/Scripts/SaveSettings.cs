using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettings : MonoBehaviour // Сохранение настроек
{
    public string BackGroundWay;
    public string SnowSpriteWay;
    public string ShardSpriteWay;

    public float SnowSize;
    public float SnowSpeed;
    public float SnowAmount;


     void Awake()
    {
        #region PlayerPrefs.Get***
        BackGroundWay = PlayerPrefs.GetString("BackGroundWay");
        SnowSpriteWay = PlayerPrefs.GetString("SnowSpriteWay");
        ShardSpriteWay = PlayerPrefs.GetString("ShardSpriteWay");

        SnowSize = PlayerPrefs.GetFloat("SnowSize");
        SnowSpeed = PlayerPrefs.GetFloat("SnowSpeed");
        SnowAmount = PlayerPrefs.GetFloat("SnowAmount");
        #endregion
        Debug.Log("Settings downloaded from Windows Registry");
    }
    public void SaveSet()
    {
        #region PlayerPrefs.Set***
        PlayerPrefs.SetString("BackGroundWay", BackGroundWay);
        PlayerPrefs.SetString("SnowSpriteWay", SnowSpriteWay);
        PlayerPrefs.SetString("ShardSpriteWay", ShardSpriteWay);

        PlayerPrefs.SetFloat("SnowSize", SnowSize);
        PlayerPrefs.SetFloat("SnowSpeed", SnowSpeed);
        PlayerPrefs.SetFloat("SnowAmount", SnowAmount);
        #endregion
        Debug.Log("Settings uploaded to Windows Registry");
    }
}
