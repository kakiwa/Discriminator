using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DirectorBase : MonoBehaviour
{
    protected GameObject sceneDirector = default;

    async UniTask Awake() {
        if (!BGDirector.isLoaded)
        {
            BGDirector.isLoaded = true;
            await SceneManager.LoadSceneAsync("BackGround", LoadSceneMode.Additive);
        }

        foreach (var gameObj in SceneManager.GetSceneByName("BackGround").GetRootGameObjects())
        {
            if (gameObj.name == "Director") sceneDirector = gameObj;
        }
    }

    protected void executeSceneChange(string current, string next)
    {
        ExecuteEvents.Execute<ISceneDirector>(
            sceneDirector,
            null,
            (_, data) =>
            {
                _.SceneChange(current, next);
            }
        );
    }

    protected void executeSceneAdd(string name)
    {
        ExecuteEvents.Execute<ISceneDirector>(
            sceneDirector,
            null,
            (_, data) =>
            {
                _.AddScene(name);
            }
        );
    }

    protected void executeSceneRemove(string name)
    {
        ExecuteEvents.Execute<ISceneDirector>(
            sceneDirector,
            null,
            (_, data) =>
            {
                _.RemoveScene(name);
            }
        );
    }
}
