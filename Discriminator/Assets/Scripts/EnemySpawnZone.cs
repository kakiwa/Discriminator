using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    [SerializeField] private uint zoneId = default;
    [SerializeField] private List<EnemySpawnZone> sideSpownZone = default;
    [SerializeField] private List<EnemySpawnZone> targetSpownZone = default;


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

    public Vector3 GetTargetPos()
    {
        var targetIdx = Random.Range(0, targetSpownZone.Count);
        return targetSpownZone[targetIdx].transform.position;
    }
}
