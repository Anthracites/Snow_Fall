 using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;
using UnityEngine.Networking;


public class FlakeUpload : MonoBehaviour, IPointerDownHandler
{
    private Sprite mySprite;
    public GameObject SettingsSaver;
    public GameObject FlakeSpawner;
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
        Debug.Log("Flake sprite downloaded from Windows Registry");
    }

    public IEnumerator StartOutput(string url)
    {
        url = SettingsSaver.GetComponent<SaveSettings>().SnowSpriteWay;
        var loader = UnityWebRequestTexture.GetTexture(url);
        yield return loader.SendWebRequest();
        var mySprite = Sprite.Create(DownloadHandlerTexture.GetContent(loader), new Rect(0.0f, 0.0f, (DownloadHandlerTexture.GetContent(loader)).width, (DownloadHandlerTexture.GetContent(loader)).height), new Vector2(0.5f, 0.5f), 100.0f);
        FlakeSpawner.GetComponent<FlakeSpawn>().Flakes = mySprite;
        FlakeSpawner.GetComponent<FlakeSpawn>().ChangeCollider();
    }

    public void OnClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "png", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
        Debug.Log("Flake sprite changed and loaded to Windows Registry");
    }
#endif

    private IEnumerator OutputRoutine(string url)
    {
        var loader = UnityWebRequestTexture.GetTexture(url);
        yield return loader.SendWebRequest();
        var mySprite = Sprite.Create(DownloadHandlerTexture.GetContent(loader), new Rect(0.0f, 0.0f, (DownloadHandlerTexture.GetContent(loader)).width, (DownloadHandlerTexture.GetContent(loader)).height), new Vector2(0.5f, 0.5f), 100.0f);
        FlakeSpawner.GetComponent<FlakeSpawn>().Flakes = mySprite;
        SettingsSaver.GetComponent<SaveSettings>().SnowSpriteWay = url.ToString();
        SettingsSaver.GetComponent<SaveSettings>().SaveSet();
        FlakeSpawner.GetComponent<FlakeSpawn>().ChangeCollider();
    }
}
