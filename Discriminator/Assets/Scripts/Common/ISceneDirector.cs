using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;

public interface ISceneDirector : IEventSystemHandler
{
    UniTask SceneChange(string nextSceneName);

    UniTask AddScene(string name);

    UniTask RemoveScene(string name);
}
