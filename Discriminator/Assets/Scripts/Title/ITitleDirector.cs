using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;

public interface ITitleDirector : IEventSystemHandler
{
    void ChangeSceneStart();
}
