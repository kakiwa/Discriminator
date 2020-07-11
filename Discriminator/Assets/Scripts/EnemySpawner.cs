using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy = default;
    [SerializeField] private Transform spawnField = default;
    [SerializeField] private GameDirector gameDirector = default;
    private List<EnemySpawnZone> enemySpawnZones = new List<EnemySpawnZone>();
    private List<SpawnWeight> spawnWeights = new List<SpawnWeight>();


    void Start()
    {
        // 敵発生ゾーンリストとスポーン重みリスト生成
        var zones = spawnField.GetComponentsInChildren<EnemySpawnZone>();
        var size = zones.Length;
        for (var i = 0; i < size; ++i) {
            var zone = zones[i];
            enemySpawnZones.Add(zone);
            spawnWeights.Add(new SpawnWeight(zone.ZoneId()));
        }

        // 一体目の出現ポイントを決めておく
        int startId = Random.Range(1, size + 1);
        SpawnWeightUpdate((uint)startId);
    }

    float t = 0;
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 1.5f)
        {
            Spawn();
            t = 0;
        }
    }

    public void Spawn()
    {
        var spawnZoneId = GetNextSpawnDecide();
        // スポーンする座標決定
        var zone = enemySpawnZones.Find(_ => _.ZoneId() == spawnZoneId);
        var e = Instantiate(enemy, zone.transform);
        var eS = new EnemyStatus();
        eS.colorState = COLOR_STATE.A;
        eS.speed = 0.08f;

        // どこへ向かうのか
        // ターゲットゾーンのID取得
        var moveV = zone.GetTargetPos() - zone.transform.position;
        moveV.Normalize();
        eS.moveVec = moveV;
        e.GetComponent<Enemy>().Spawn(gameDirector, eS);

        // 重み更新
        SpawnWeightUpdate(spawnZoneId);
    }

    // 重みを元に次の発生ゾーンを返す
    uint GetNextSpawnDecide()
    {
        // TODO:ちゃんと重みを元に返すようにする
        return (uint)(Random.Range(1, spawnWeights.Count + 1));
    }

    /// <summary>
    /// 発生ゾーンの重み更新
    /// </summary>
    void SpawnWeightUpdate(uint spawnedZoneId)
    {
        // 最後にスポーンしたゾーンの情報取得
        var enemySpawnZone = enemySpawnZones.Find(_ => _.ZoneId() == spawnedZoneId);
        var sides = enemySpawnZone.GetSideIds();
        var targets = enemySpawnZone.GetTargetIds();

        // 重み付け
        spawnWeights.ForEach(
            spawnWeight =>
            {
                // 今スポーンしたゾーンの重みを0に
                if (spawnWeight.id == spawnedZoneId)
                {
                    spawnWeight.toZero();
                    return;
                }

                // 一段上げとく
                ++spawnWeight;

                // 隣のゾーンの重みを二段下げる
                sides.ForEach(
                    sideId =>
                    {
                        if (sideId == spawnWeight.id)
                        {
                            spawnWeight += 2;
                        }
                    }
                );

                // 今スポーンしたゾーンの向き先になりうる(画面の反対側を想定)ゾーンの重みを一段あげる
                targets.ForEach(
                    targetId =>
                    {
                        if (targetId == spawnWeight.id)
                        {
                            ++spawnWeight;
                        }
                    }
                );
            }
        );
    }

}
