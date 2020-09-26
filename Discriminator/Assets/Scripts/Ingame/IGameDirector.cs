using UnityEngine.EventSystems;

public interface IGameDirector : IEventSystemHandler
{

    void ColorChange();

    void Hit(COLOR_STATE c);

    void LevelUp();

    Player getPlayerInstance();
}
