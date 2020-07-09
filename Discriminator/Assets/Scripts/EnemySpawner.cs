using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy = default;
    [SerializeField] private Transform spawnField = default;
    [SerializeField] private GameDirector gameDirector = default;


    float t = 0;
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 2.5f)
        {
            Spawn();
            t = 0;
        }
    }

    public void Spawn()
    {
        var e = Instantiate(enemy, spawnField);
        var eS = new EnemyStatus();
        eS.colorState = COLOR_STATE.A;
        eS.speed = 0.08f;
        eS.moveVec = Vector2.up;
        e.GetComponent<Enemy>().Spawn(gameDirector, eS);
    }

}
