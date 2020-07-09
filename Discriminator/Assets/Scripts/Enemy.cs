using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = default;

    private GameDirector gameDirector = default;
    private EnemyStatus enemyStatus = default;

    /// <summary>
    /// スポーン
    /// </summary>
    /// <param name="gameDirector"></param>
    /// <param name="status"></param>
    public void Spawn(GameDirector gameDirector, EnemyStatus status)
    {
        this.gameDirector = gameDirector;
        this.enemyStatus = status;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)status.colorState];
    }

    /// <summary>
    /// 移動するだけ
    /// </summary>
    public void Update()
    {
        transform.Translate(
            new Vector3(
                enemyStatus.moveVec.x * enemyStatus.speed,
                enemyStatus.moveVec.y * enemyStatus.speed,
                0
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
                gameDirector.gameObject,
                null,
                (_, data) => _.Hit(enemyStatus.colorState)
            );
        }

        // 何かに当たったら消す
        Destroy(this.gameObject);
    }

}
