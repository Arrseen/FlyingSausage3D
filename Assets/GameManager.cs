using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    bool gameHasEnded = false;
    public float restartDelay = 2f;

    public static int level;

    public bool hitSoundPlayed = false;
    public AudioSource audioSource;
    public AudioClip[] hitClip;
    public bool deathSoundPlayed = false;

    [SerializeField] GameObject tapToPlayCanvas;

    private void Awake()
    {
        Instance = this;

        level++;

        if (level == 1)
        {
            Time.timeScale = 0;
            tapToPlayCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
    public void TapToPlay()
    {
        tapToPlayCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        level--;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("LVL" + (level + 1).ToString());
    }
}
