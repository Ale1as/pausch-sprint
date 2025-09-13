using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider sensSlider;
    private float sensValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sensSlider.value = FindAnyObjectByType<FPScamera>().sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if (FindAnyObjectByType<FPScamera>().sensitivity != sensSlider.value)
        {
            FindAnyObjectByType<FPScamera>().sensitivity = sensSlider.value;
        }
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
