using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChangeButton : MonoBehaviour
{
    [SerializeField] private GameObject director = default;

    public void OnExecute()
    {
        ExecuteEvents.Execute<IGameDirector>(
            director,
            null,
            (_, data) =>_.ColorChange()
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnExecute();
        }
    }
}
