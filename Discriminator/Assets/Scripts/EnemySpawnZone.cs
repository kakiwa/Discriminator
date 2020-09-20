using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    [SerializeField] private uint zoneId = default;
    [SerializeField] private List<EnemySpawnZone> sideSpownZone = default;
    [SerializeField] private List<EnemySpawnZone> targetSpownZone = default;

    BoxCollider2D bc = default;

    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    public uint ZoneId()
    {
        return zoneId;
    }

    public List<uint> GetSideIds()
    {
        var ids = new List<uint>();
        sideSpownZone.ForEach(_ => ids.Add(_.ZoneId()));
        return ids;
    }

    public List<uint> GetTargetIds()
    {
        var ids = new List<uint>();
        targetSpownZone.ForEach(_ => ids.Add(_.ZoneId()));
        return ids;
    }

    public Vector3 GetTarget()
    {
        var targetIdx = Random.Range(0, targetSpownZone.Count);
        return targetSpownZone[targetIdx].GetPos();
    }

    public Vector3 GetPos()
    {
        var b = bc.bounds;
        var x = Random.Range(b.center.x - b.extents.x, b.center.x + b.extents.x);
        var y = Random.Range(b.center.y - b.extents.y, b.center.y + b.extents.y);
        return new Vector3(x, y, 0);
    }
}
