using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDirector : DirectorBase, IGameDirector
{
    [SerializeField] private Player player = default;
    [SerializeField] private ScoreBoard scoreBoard = default;
    [SerializeField] private EnemySpawner enemySpawner = default;

    COLOR_STATE currentColor = default;

    GAME_LEVEL currentGameLevel = default;

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

    public void LevelUp()
    {
        ++currentGameLevel;
    }

    public void Hit(COLOR_STATE colorState)
    {
        if (currentColor == colorState)
        {
            scoreBoard.addScore();
        }
    }

    public Player getPlayerInstance()
    {
        return player;
    }

    public GAME_LEVEL GetGameLevel()
    {
        return currentGameLevel;
    }

    public void EndGame()
    {
        Debug.Log("end");
        enemySpawner.gameObject.SetActive(false);
        player.enabled = false;
        scoreBoard.enabled = false;
        executeSceneAdd("Result");
    }
}
