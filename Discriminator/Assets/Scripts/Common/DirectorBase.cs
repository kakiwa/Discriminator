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
        const string SCENE_DIRECTOR_NAME = "BackGround";
        const string DIRECTOR_OBJECT_NAME = "Director";
        if (!BGDirector.isLoaded)
        {
            BGDirector.isLoaded = true;
            await SceneManager.LoadSceneAsync(SCENE_DIRECTOR_NAME, LoadSceneMode.Additive);
        }

        foreach (var gameObj in SceneManager.GetSceneByName(SCENE_DIRECTOR_NAME).GetRootGameObjects())
        {
            if (gameObj.name == DIRECTOR_OBJECT_NAME) sceneDirector = gameObj;
        }
    }

    protected void executeSceneChange(string next)
    {
        ExecuteEvents.Execute<ISceneDirector>(
            sceneDirector,
            null,
            (_, data) =>
            {
                _.SceneChange(next);
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
