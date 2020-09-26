using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// なみなみ
/// </summary>
public class Waver : EnemyBase
{
    Vector3 rightVec = default;

    float time = default;

    protected override void setup()
    {
        // 生まれた場所を覚えておく
        var defaultMoveVec = enemyStatus.targetPos - transform.position;
        rightVec = Quaternion.Euler(0,0,90) * defaultMoveVec;
        rightVec.Normalize();

        switch (enemyStatus.currentLevel) {
            case GAME_LEVEL.ONE:    enemyStatus.speed = 0.04f;  break;
            case GAME_LEVEL.TWO:    enemyStatus.speed = 0.05f;  break;
            case GAME_LEVEL.THREE:  enemyStatus.speed = 0.06f;  break;
        }
    }

    protected override void updateDosukoi()
    {
        // 進行方向と垂直方向にブレる
        time += Time.deltaTime;
        var cos = Mathf.Cos
            (
                Mathf.PI * time * 2f
            );
        transform.position += rightVec * cos * 0.1f;
    }
}
