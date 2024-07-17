using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _shopBtn;
    [SerializeField] private Button _exitBtn;

    void Start()
    {
        _playBtn.onClick.AddListener(LevelSelector);
        _exitBtn.onClick.AddListener(Exit);
    }

    void LevelSelector()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Exit()
    {
        Application.Quit();
    }
}
