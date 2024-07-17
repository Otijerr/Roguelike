using System;
using UnityEngine;

public class Level : MonoBehaviour , ILevelUp
{
    private int _level;
    private int _exp;

    public event Action<int> LevelChanged;
    public event Action<float> ExpChanged;

    int toLevelUp
    {
        get { return _level * 1000; }
    }
    public void AddExp(int amount)
    {
        _exp += amount;
        CheckLevelUp();
        float _currentLevelFilled = (float)_exp / toLevelUp;
        ExpChanged?.Invoke(_currentLevelFilled);
    }
    public void CheckLevelUp()
    {
        if (_exp >= toLevelUp)
        {
            _exp -= toLevelUp;
            _level += 1;
            LevelChanged?.Invoke(_level);
            float _currentLevelFilled = (float)_exp / toLevelUp;
            ExpChanged?.Invoke(_currentLevelFilled);
        }
    }
}
