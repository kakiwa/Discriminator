using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class EnemyBase : MonoBehaviour {
    [SerializeField] protected Sprite[] sprites = default;
    protected GameObject gameDirector = default;
    protected EnemyStatus enemyStatus = default;

    protected Vector2 moveVec = default;
    public void Spawn(GameObject gameDirector, EnemyStatus status) {
        this.gameDirector = gameDirector;
        this.enemyStatus = status;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)status.colorState];

        // 初期移動方向
        moveVec = enemyStatus.targetPos - transform.position;
        moveVec.Normalize();

        setup();
    }
    public void Update() {
        updateDosukoi();

        transform.Translate(
            new Vector2(
                moveVec.x * enemyStatus.speed,
                moveVec.y * enemyStatus.speed
            )
        );
    }
    /// <summary>
    /// 衝突ハンテー
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ExecuteEvents.Execute<IGameDirector>(
                gameDirector,
                null,
                (_, data) => _.Hit(enemyStatus.colorState)
            );
        }

        // 何かに当たったら消す
        Destroy(this.gameObject);
    }

    protected abstract void setup();
    protected abstract void updateDosukoi();

}

/// <summary>
/// ただの敵
/// </summary>
public class Enemy : EnemyBase
{
    protected override void setup() {

        switch (enemyStatus.currentLevel) {
            case GAME_LEVEL.ONE:    enemyStatus.speed = 0.08f;  break;
            case GAME_LEVEL.TWO:    enemyStatus.speed = 0.09f;  break;
            case GAME_LEVEL.THREE:  enemyStatus.speed = 0.10f;  break;
        }
    }

    protected override void updateDosukoi() {}
}
