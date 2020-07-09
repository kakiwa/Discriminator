using UnityEngine;

/// <summary>
/// スコアの判断基準になる色情報
/// </summary>
public enum COLOR_STATE : int {
    A,
    B
}

public struct EnemyStatus
{
    public COLOR_STATE colorState {get;set;}
    public float speed {get;set;}
    public Vector2 moveVec {get;set;}
}
