using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChangeButton : MonoBehaviour
{
    [SerializeField] private GameDirector director = default;

    public void OnExecute()
    {
        ExecuteEvents.Execute<IGameDirector>(
            director.gameObject,
            null,
            (_, data) =>_.ColorChange()
        );
    }
}
