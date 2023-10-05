using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject levelSelect;
    [Space]
    [SerializeField] private TextMeshProUGUI tutorialBestTimeText;
    [Space]
    [SerializeField] private TextMeshProUGUI levelOneBestTimeText;
    [Space]
    [SerializeField] private TextMeshProUGUI levelTwoBestTimeText;


    private void Awake()
    {
        
        SetTimes();

    }

    private void SetTimes()
    {
        tutorialBestTimeText.text = string.Format("{0:00}:{1:00.00}", TimeManager.Instance.timeKeepers[0].GetBestMinutes(), TimeManager.Instance.timeKeepers[0].GetBestSeconds());

        levelOneBestTimeText.text = string.Format("{0:00}:{1:00.00}", TimeManager.Instance.timeKeepers[1].GetBestMinutes(), TimeManager.Instance.timeKeepers[1].GetBestSeconds());

        levelTwoBestTimeText.text = string.Format("{0:00}:{1:00.00}", TimeManager.Instance.timeKeepers[2].GetBestMinutes(), TimeManager.Instance.timeKeepers[2].GetBestSeconds());
    }

    private void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void LevelSelect()
    {
        startMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void TutorialLevel()
    {
        SceneManager.LoadScene("Tutorial_Level");
    }

    public void levelOne()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void Back()
    {
        startMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
