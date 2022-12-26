using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadScene("Test111"));
    }

    IEnumerator LoadScene(string strScene)
    {
        Debug.Log("LoadScene:strScene(" + strScene + ")");
        // 异步加载场景(如果场景资源没有下载，会自动下载)，
        var handle = Addressables.LoadSceneAsync(strScene);
        Debug.Log("LoadScene:" + handle.GetType());
        if (handle.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("场景加载异常: " + handle.OperationException.ToString());
            yield break;
        }
        while (!handle.IsDone)
        {
            // 进度（0~1）
            float percentage = handle.PercentComplete;
            Debug.Log("进度: " + percentage);
            yield return null;
        }

        Debug.Log("场景加载完毕");
    }

    //static async void LoadScene()
    //{
    //    var handler = await Addressables.LoadSceneAsync("Main").Task;
    //    handler.ActivateAsync();
    //    UIKit.OpenPanel<GameLobby>(UILevel.Common, null, "GameLobby", "GameLobby");
    //}
}

