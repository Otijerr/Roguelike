using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Button _menuBtn;

    [SerializeField] private GameObject _menu;

    [SerializeField] private Text _timerText;
    float timer;
    int minute = 0;

    private bool menu = false;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60)
        {
            minute++;
            timer = 0;
        }
        _timerText.text = minute.ToString() + ':' + Math.Round(timer, 0).ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu();
        }
    }
    void Start()
    {
        _menuBtn.onClick.AddListener(ShowMenu);
        _restartBtn.onClick.AddListener(RestartLevel);
        _exitBtn.onClick.AddListener(ExitGame);
    }

    void ShowMenu()
    {
        menu = !menu;
        if (menu)
        {
            _menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
