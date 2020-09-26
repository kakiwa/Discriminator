using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject director = default;

    public void Invoke() {
        var button = this.GetComponent<Button>();
        button.interactable = false;
        ExecuteEvents.Execute<ITitleDirector>(
            director,
            null,
            (_, data) =>
            {
                _.ChangeSceneStart();
            }
        );
    }

}
