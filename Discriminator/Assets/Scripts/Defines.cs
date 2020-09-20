using UnityEngine;

/// <summary>
/// スコアの判断基準になる色情報
/// </summary>
public enum COLOR_STATE : int {
    A,
    B
}

/// <summary>
/// ゲームレベル (敵のステータスを増減させるために使用)
/// </summary>
public enum GAME_LEVEL
{
    ONE,
    TWO,
    THREE,
}

public struct EnemyStatus
{
    public COLOR_STATE colorState {get;set;}
    public float speed {get;set;}
    public Vector3 targetPos {get;set;}
    public GAME_LEVEL currentLevel {get;set;}
}
