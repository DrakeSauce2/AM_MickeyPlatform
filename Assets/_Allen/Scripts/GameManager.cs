using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void RespawnPlayer()
    {
        player.position = spawnPoint + offset;
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint.position;
    }

}
