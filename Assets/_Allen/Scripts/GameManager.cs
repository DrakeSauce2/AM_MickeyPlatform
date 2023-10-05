using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level;

    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Vector3 offset;
    [Space]
    [SerializeField] private TextMeshProUGUI restartsText;
    [SerializeField] private int restarts;
    [Space]
    [SerializeField] private string nextScene;
    [Space]
    [SerializeField] private GameObject pauseMenu;
    [Space]

    bool isPaused = false;

    public bool gameEnd = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        Time.timeScale = 1f;
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape) && !gameEnd)
        {
            Pause();
        }
    }

    public void GameEnd()
    {
        pauseMenu.SetActive(false);
    }

    private void Pause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void RespawnPlayer()
    {
        player.position = spawnPoint + offset;
        restarts++;
        restartsText.text = $"Restarts: {restarts}";
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint.position;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Resume()
    {
        isPaused = false;

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetRestarts() => restarts;

}
