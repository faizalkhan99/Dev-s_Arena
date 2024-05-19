using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null) Debug.Log("UIManager:NULL");
            return instance;
        }
    }

    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private GameObject _pauseButttonPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progressBar;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        //TurnEverythingOFF();
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        TurnEverythingOFF();
        if (_loadingScreen) _loadingScreen.SetActive(true);
        StartCoroutine(LoadingAsync(sceneName));
    }
    IEnumerator LoadingAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            _progressBar.value = operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
    public void TurnEverythingOFF()
    {
        if (_creditsPanel) _creditsPanel.SetActive(false);
        if (_mainMenu) _mainMenu.SetActive(false);
        if (_restartPanel) _restartPanel.SetActive(false);
        if (_pauseMenuPanel) _pauseMenuPanel.SetActive(false);
        if (_loadingScreen) _loadingScreen.SetActive(false);
        if (_pauseButttonPanel) _pauseButttonPanel.SetActive(false);
    }
    public void GamePauseUnpause(bool condition)
    {
        if (condition)
        {
            Time.timeScale = 0f;
            //AudioManager.Instance.PauseBGM();
            if (_pauseMenuPanel) _pauseMenuPanel.SetActive(condition); //true
            if (_pauseButttonPanel) _pauseButttonPanel.SetActive(!condition);  //!true
        }
        else
        {
            Time.timeScale = 1f;
            //AudioManager.Instance.UnpauseBGM();
            if (_pauseMenuPanel) _pauseMenuPanel.SetActive(condition); //false
            if (_pauseButttonPanel) _pauseButttonPanel.SetActive(!condition);  //!false
        }
    }


    public void CreditsScreen()
    {
        TurnEverythingOFF();
        if (_creditsPanel) _creditsPanel.SetActive(true);
    }
    public void BackToHome()
    {
        TurnEverythingOFF();
        if (_mainMenu) _mainMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
