using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Vector3 offset;
    [Space]
    [SerializeField] private TextMeshProUGUI restartsText;
    [SerializeField] private int restarts;
    [Space]
    [SerializeField] private string nextScene;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
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

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public int GetRestarts() => restarts;

}
