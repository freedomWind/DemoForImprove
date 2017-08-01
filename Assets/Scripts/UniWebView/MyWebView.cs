using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//#if !UNITY_EDITOR
public class MyWebView : MonoBehaviour
{
    private UniWebView _webView;

    public System.Action BackDel;
    public string url
    {
        get
        {
         //   return "http://www.baidu.com";
#if UNITY_EDITOR
            return Application.streamingAssetsPath + "/index.html";
#elif UNITY_IOS
			return Application.streamingAssetsPath + "/index.html";
#elif UNITY_ANDROID
			return "file:///android_asset/index.html";
#endif
        }
    }
    private void Start()
    {   
        _webView = transform.AddComponentIfNoExist<UniWebView>();
        _webView.OnReceivedMessage += OnReceivedMessage;
        _webView.OnLoadComplete += OnLoadComplete;
        _webView.url = url;
        _webView.Load();
    }

    void OnReceivedMessage(UniWebView webView, UniWebViewMessage message)
    {
        if (string.Equals(message.path, "back"))
        {
            if (BackDel != null)
            {
                BackDel();
            }
        }
    }
    void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success)
        {
            webView.Show();
            Debug.Log("load complete");
        }
        else
        {
            if(BackDel != null)
                BackDel();
        }
    }
}
//#endif