using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGDirector : MonoBehaviour, IBGDirector , ISceneDirector
{
    static public bool isLoaded {get;set;}

    [SerializeField]
    private GameObject backMan = default;

    public async UniTask AddScene(string name)
    {
        await SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public async UniTask RemoveScene(string name)
    {
        await SceneManager.UnloadSceneAsync(name);
    }

    public async UniTask SceneChange(string nextSceneName)
    {
        List<Scene> currentScenes = new List<Scene>();
        for (var idx = 0; idx < SceneManager.sceneCount; ++idx)
        {
            var scene = SceneManager.GetSceneAt(idx);
            if (scene.name == "BackGround") continue;
            currentScenes.Add(scene);
        }
        var nextScene = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
        nextScene.allowSceneActivation = false;

        await DOTween.Sequence()
            .Append(
                backMan.transform.DORotate(new Vector3(0,0,359), 0.5f, RotateMode.FastBeyond360)
            )
            .Append(
                backMan.transform.DORotate(new Vector3(0,0,0), 0.5f, RotateMode.FastBeyond360)
            )
            .OnComplete(
                () =>
                {
                    foreach (var scene in currentScenes)
                    {
                        SceneManager.UnloadSceneAsync(scene);
                    }
                    // シーン開始
                    nextScene.allowSceneActivation = true;
                }
            );
    }
}
