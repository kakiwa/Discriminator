using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;





/// <summary>
/// 敵追いかけるマン
/// </summary>
public class Tracker : EnemyBase
{
    private float trackTime = default;

    private Transform playerTrans = default;

    protected override void setup()
    {
        // プレイヤーのインスタンス取得
        ExecuteEvents.Execute<IGameDirector>(
            gameDirector,
            null,
            (_, data) => {
                playerTrans = _.getPlayerInstance().transform;
                Debug.Log("a");
            }
        );

        switch (enemyStatus.currentLevel) {
            case GAME_LEVEL.ONE:    enemyStatus.speed = 0.03f;  trackTime = 3.0f;   break;
            case GAME_LEVEL.TWO:    enemyStatus.speed = 0.04f;  trackTime = 4.0f;   break;
            case GAME_LEVEL.THREE:  enemyStatus.speed = 0.05f;  trackTime = 5.0f;   break;
        }
    }

    protected override void updateDosukoi()
    {
        if (trackTime > 0.0f) {
            trackPlayer();
        }
    }

    private void trackPlayer() {
        moveVec = playerTrans.position - transform.position;
        moveVec.Normalize();

        trackTime -= Time.deltaTime;
    }

}
