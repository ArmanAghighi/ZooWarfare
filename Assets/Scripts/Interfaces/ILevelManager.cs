using System;

public interface ILevelManager
{
    void LevelUp(int wealth);
    event Action<int> OnLevelUpRequest;
}
