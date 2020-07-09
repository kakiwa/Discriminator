using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector = default;
    [SerializeField] private Text text = default;
    int score = default;

    void Start()
    {
        text.text = score.ToString();
    }

    void Update()
    {

    }

    public void addScore()
    {
        score += 5;
        text.text = score.ToString();
    }

    public void setScore(int score)
    {

    }
}
