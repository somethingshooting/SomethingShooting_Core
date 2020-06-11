using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : ManagerBase<SceneManager>
{
    public IReadOnlyList<string> SceneNameList => _SceneNameList;
    [SerializeField] private List<string> _SceneNameList = new List<string>();

    private void Start()
    { 
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
        {
            _SceneNameList.Add(GetSceneNameFromScenePath(SceneUtility.GetScenePathByBuildIndex(i)));
        }
    }

    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
    }

    private string GetSceneNameFromScenePath(string path)
    {
        var sceneNameStart = path.LastIndexOf("/", StringComparison.Ordinal) + 1;
        var sceneNameEnd = path.LastIndexOf(".", StringComparison.Ordinal);
        var sceneNameLength = sceneNameEnd - sceneNameStart;
        return path.Substring(sceneNameStart, sceneNameLength);
    }
}
