using UnityEngine;
using UnityEngine.UI;
public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image _levelBarFilling;
    [SerializeField] private Text _levelText;
    [SerializeField] private Level _level;

    private void Awake()
    {
        _level.LevelChanged += OnLevelChanged;
        _level.ExpChanged += OnExpChanged;
    }

    private void OnExpChanged(float value)
    {
        _levelBarFilling.fillAmount = value;
    }
    private void OnLevelChanged(int value) 
    {
        _levelText.text = $"Уровень: {value}";
    }
}
