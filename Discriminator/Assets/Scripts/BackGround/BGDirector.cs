using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGDirector : MonoBehaviour, IBGDirector , ISceneDirector
{
    static public bool isLoaded {get;set;}

    public async UniTask AddScene(string name)
    {
        await SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public async UniTask RemoveScene(string name)
    {
        await SceneManager.UnloadSceneAsync(name);
    }

    public async UniTask SceneChange(string currentSceneName, string nextSceneName)
    {
        var currentScene = SceneManager.GetSceneByName(currentSceneName);
        var nextScene = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
        nextScene.allowSceneActivation = false;

        await DOTween.Sequence()
            .SetDelay(1.0f)
            .OnComplete(
                () =>
                {
                    SceneManager.UnloadSceneAsync(currentScene);
                    // シーン開始
                    nextScene.allowSceneActivation = true;
                }
            );
    }
}
