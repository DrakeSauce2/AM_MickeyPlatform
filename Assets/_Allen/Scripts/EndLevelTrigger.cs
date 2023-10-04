using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject resultsScreen;
    [SerializeField] private GameObject playerUI;
    [Space]
    [SerializeField] private TextMeshProUGUI endTimeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    [SerializeField] private TextMeshProUGUI restartsText;
    [Space]
    [SerializeField] private TimeKeeper timeKeeper;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    public void DisplayText()
    {
        endTimeText.text = Timer.Instance.GetTimerText();

        Timer.Instance.CompareTime(timeKeeper);

        bestTimeText.text = string.Format("Best Time: {0:00}:{1:00.00}", timeKeeper.GetBestMinutes(), timeKeeper.GetBestSeconds());

        if(timeKeeper.GetRestarts() == 0)
            timeKeeper.SetRetries(GameManager.Instance.GetRestarts());

        if (GameManager.Instance.GetRestarts() < timeKeeper.GetRestarts())
           timeKeeper.SetRetries(GameManager.Instance.GetRestarts());

        restartsText.text = $"Restarts: {GameManager.Instance.GetRestarts()}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisplayText();
            resultsScreen.SetActive(true);

            playerUI.SetActive(false);
                      
            Time.timeScale = 0.0f;
        }
    }
}
