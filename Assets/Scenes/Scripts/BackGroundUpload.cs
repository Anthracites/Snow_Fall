using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;
using UnityEngine.Networking;

[RequireComponent(typeof(Button))]

public class BackGroundUpload : MonoBehaviour, IPointerDownHandler
{
    public GameObject BackGround;
    public GameObject SettingsSaver;
    private Sprite mySprite;
    public string url;


#if UNITY_WEBGL && !UNITY_EDITOR
    //
    // WebGL
    //
    [DllImport("__Internal")]
    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

    public void OnPointerDown(PointerEventData eventData) {
        UploadFile(gameObject.name, "OnFileUpload", ".png, .jpg", false);
    }

    // Called from browser
    public void OnFileUpload(string url) {
        StartCoroutine(OutputRoutine(url));
    }
#else
    //
    // Standalone platforms & editor
    //
    public void OnPointerDown(PointerEventData eventData) { }

    void Start()
    {
        var button = GetComponent<Button>();
        StartCoroutine(StartOutput(url));
    }

    public IEnumerator StartOutput(string url)
    {
        url = SettingsSaver.GetComponent<SaveSettings>().BackGroundWay;
        var loader = UnityWebRequestTexture.GetTexture(url);
        yield return loader.SendWebRequest();
        var mySprite = Sprite.Create(DownloadHandlerTexture.GetContent(loader), new Rect(0.0f, 0.0f, (DownloadHandlerTexture.GetContent(loader)).width, (DownloadHandlerTexture.GetContent(loader)).height), new Vector2(0.5f, 0.5f), 100.0f);
        BackGround.GetComponent<SpriteRenderer>().sprite = mySprite;
    }

    public void OnClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "jpg", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }
#endif

    public IEnumerator OutputRoutine(string url)
    {
        var loader = UnityWebRequestTexture.GetTexture(url);
        yield return loader.SendWebRequest();
        var mySprite = Sprite.Create(DownloadHandlerTexture.GetContent(loader), new Rect(0.0f, 0.0f, (DownloadHandlerTexture.GetContent(loader)).width, (DownloadHandlerTexture.GetContent(loader)).height), new Vector2(0.5f, 0.5f), 100.0f);
        BackGround.GetComponent<SpriteRenderer>().sprite = mySprite;
        SettingsSaver.GetComponent<SaveSettings>().BackGroundWay = url.ToString();
        SettingsSaver.GetComponent<SaveSettings>().SaveSet();
    }

 
}
