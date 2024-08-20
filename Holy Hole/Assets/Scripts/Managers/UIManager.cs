using TMPro;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;

    [Header("MENUS")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject levelSelectionMenu;

    [Tooltip("Total score shows in the end of the game")]
    [SerializeField] TextMeshProUGUI totalScoreText;

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void DisplayTimer(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetTotalScoreInMenu()
    {
        totalScoreText.text = $"Score: {ScoreManager.Instance.score}";
    }

    public void TogglePauseMenu(bool isActive)
    {
        pauseMenu.SetActive(isActive);
    }

    public void ToggleGameOverMenu(bool isActive)
    {
        gameOverMenu.SetActive(isActive);
    }

    public void ToggleLevelSelectionMenu(bool isActive)
    {
        levelSelectionMenu.SetActive(isActive);
    }
}
