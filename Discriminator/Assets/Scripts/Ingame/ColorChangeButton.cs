using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChangeButton : MonoBehaviour
{
    [SerializeField] private GameObject director = default;

    public void OnExecute()
    {
        send();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            send();
        }
    }

    private void send()
    {
        ExecuteEvents.Execute<IGameDirector>(
            director,
            null,
            (_, data) =>_.ColorChange()
        );
    }
}
