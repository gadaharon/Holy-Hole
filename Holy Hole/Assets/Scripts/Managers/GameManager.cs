
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    GameStarted,
    Playing,
    Pause,
    GameOver
}

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public static GameState state = GameState.None;

    [Tooltip("Game time in seconds")]
    [SerializeField] float gameTimer = 180;

    float currentTimer = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (state == GameState.None)
        {
            state = GameState.GameStarted;
        }
    }


    void Update()
    {
        if (state == GameState.Playing)
        {
            HandleGameTimer();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePauseGame();
        }
    }

    public void NavigateToMainMenu()
    {
        state = GameState.GameStarted;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void HandleGameTimer()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            UIManager.Instance.DisplayTimer(currentTimer);
        }
        else
        {
            SetGameOver();
            currentTimer = 0;
        }
    }

    public void InitGamePlay()
    {
        currentTimer = gameTimer;
        state = GameState.Playing;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        UIManager.Instance.TogglePauseMenu(false);
        UIManager.Instance.ToggleGameOverMenu(false);
    }

    public void HandleResumeGame()
    {
        HandlePauseGame();
    }

    void HandlePauseGame()
    {
        if (state == GameState.Playing)
        {
            state = GameState.Pause;
            Time.timeScale = 0;
            UIManager.Instance.TogglePauseMenu(true);
        }
        else if (state == GameState.Pause)
        {
            state = GameState.Playing;
            Time.timeScale = 1;
            UIManager.Instance.TogglePauseMenu(false);
        }
    }

    void SetGameOver()
    {
        state = GameState.GameOver;
        Time.timeScale = 0;
        ScoreManager.Instance.SaveTopScore();
        UIManager.Instance.ToggleGameOverMenu(true);
        UIManager.Instance.SetTotalScoreInMenu();
    }

    public void StartSpecificLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
