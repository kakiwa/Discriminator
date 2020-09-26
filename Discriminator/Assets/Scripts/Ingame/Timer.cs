using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] private Text text = default;

    [SerializeField] private GameDirector gameDirector = default;

    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = time.ToString("F2");

        if (time == 30f) {
            // gameDirector.LevelUp();
        }
    }
}
