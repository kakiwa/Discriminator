using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Timer : MonoBehaviour
{
    [SerializeField] private Text text = default;

    [SerializeField] private GameObject gameDirector = default;

    [SerializeField] private float endTime = 60.0f;

    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = time.ToString("F2");

        if (time >= endTime)
        {
            TimeOver();
        }
    }

    void TimeOver()
    {
        ExecuteEvents.Execute<IGameDirector>(
            gameDirector,
            null,
            (_, data)=>
            {
                _.EndGame();
            }
        );
        this.gameObject.SetActive(false);
    }
}
