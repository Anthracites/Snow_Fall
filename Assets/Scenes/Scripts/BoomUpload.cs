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

public class BoomUpload : MonoBehaviour, IPointerDownHandler // Class for select custom ExplozSprite whith windows explorer
{
    public Material BoomEff;
    private Sprite mySprite;
    public GameObject SettingsSaver;
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
        Debug.Log("Exploz sprite downloaded from Windows Registry");
    }

    public IEnumerator StartOutput(string url)
    {
        url = SettingsSaver.GetComponent<SaveSettings>().ShardSpriteWay;
        var loader = UnityWebRequestTexture.GetTexture(url);
        yield return loader.SendWebRequest();
        var mySprite = Sprite.Create(DownloadHandlerTexture.GetContent(loader), new Rect(0.0f, 0.0f, (DownloadHandlerTexture.GetContent(loader)).width, (DownloadHandlerTexture.GetContent(loader)).height), new Vector2(0.5f, 0.5f), 100.0f);
        BoomEff.SetTexture("_MainTex", DownloadHandlerTexture.GetContent(loader));
    }
    public void OnClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "png", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
        Debug.Log("Exploz sprite changed and loaded to Windows Registry");
    }
#endif

    private IEnumerator OutputRoutine(string url)
    {
        var loader = UnityWebRequestTexture.GetTexture(url);
        yield return loader.SendWebRequest();
        // var mySprite = Sprite.Create(loader.texture, new Rect(0.0f, 0.0f, (loader.texture).width, (loader.texture).height), new Vector2(0.5f, 0.5f), 100.0f);
        BoomEff.SetTexture("_MainTex", DownloadHandlerTexture.GetContent(loader));
        SettingsSaver.GetComponent<SaveSettings>().ShardSpriteWay = url.ToString();
        SettingsSaver.GetComponent<SaveSettings>().SaveSet();
    }
}
//backup
/*public void OnPointerDown(PointerEventData eventData) { }

void Start()
{
    var button = GetComponent<Button>();
    StartCoroutine(StartOutput(url));
}

public IEnumerator StartOutput(string url)
{
    url = SettingsSaver.GetComponent<SaveSettings>().ShardSpriteWay;
    var loader = new WWW(url);
    yield return loader;
    var mySprite = Sprite.Create(loader.texture, new Rect(0.0f, 0.0f, (loader.texture).width, (loader.texture).height), new Vector2(0.5f, 0.5f), 100.0f);
    BoomEff.SetTexture("_MainTex", loader.texture);
}
public void OnClick()
{
    var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "png", false);
    if (paths.Length > 0)
    {
        StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
    }
}
#endif

private IEnumerator OutputRoutine(string url)
{
    var loader = new WWW(url);
    yield return loader;
    // var mySprite = Sprite.Create(loader.texture, new Rect(0.0f, 0.0f, (loader.texture).width, (loader.texture).height), new Vector2(0.5f, 0.5f), 100.0f);
    BoomEff.SetTexture("_MainTex", loader.texture);
    SettingsSaver.GetComponent<SaveSettings>().ShardSpriteWay = url.ToString();
    SettingsSaver.GetComponent<SaveSettings>().SaveSet();
}**/
