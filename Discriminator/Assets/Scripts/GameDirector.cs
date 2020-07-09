using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour, IGameDirector
{
    [SerializeField] private Player player = default;
    [SerializeField] private Timer timer = default;
    [SerializeField] private ScoreBoard scoreBoard = default;
    [SerializeField] private EnemySpawner enemySpawner = default;

    COLOR_STATE currentColor = default;

    public void ColorChange()
    {
        if (currentColor == COLOR_STATE.A) {
            currentColor = COLOR_STATE.B;
        }
        else
        {
            currentColor = COLOR_STATE.A;
        }
        player.setColorState(currentColor);
    }

    public void Hit(COLOR_STATE colorState)
    {
        if (currentColor == colorState)
        {
            scoreBoard.addScore();
        }
    }
}
