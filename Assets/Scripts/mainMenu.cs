using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject mainBackground;
    public GameObject settingsBackground;
    public GameObject loadingBackground;
    public Image loadingBar;
    public void PlayGame(int sceneIndex)
    {
        StartCoroutine(loadingsceneAsync(sceneIndex));
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit!"); // Shows in editor
        Application.Quit();
    }

    public void SettingsMenu()
    {
        mainBackground.SetActive(false);
        settingsBackground.SetActive(true);
    }

    public void closesettingsMenu()
    {
        mainBackground.SetActive(true);
        settingsBackground.SetActive(false);
    }

    IEnumerator loadingsceneAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingBackground.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progress;
            yield return null;
        }
    }
}
