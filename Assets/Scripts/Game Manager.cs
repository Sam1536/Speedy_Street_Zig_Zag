using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted = false;

    public GameObject platformSpawner;

    public int score = 0;
    public int highScore = 0;

    public Text textScore;
    public Text highScoreText;

    public GameObject gamePlayUI;
    public GameObject menuUI;


    private AudioSource audioSource;
    public AudioClip[] gameMusic;
   
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "best Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }


    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);

        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);

        audioSource.clip = gameMusic[1];
        audioSource.Play();

        StartCoroutine("UpdateScore");
    }
    
    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");

        SaveHighScore();

        Invoke("ReloadLevel", 1.5f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");

    }


    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            score++;

            textScore.text = score.ToString();

           // Debug.Log(score);
            //print(score);
        }

    }

    public void incrementsScore()
    {
        score += 2;
        textScore.text = score.ToString();

        audioSource.PlayOneShot(gameMusic[2],0.2f);
    }


    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            //ja tem uma pontuação salva

            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            //jogando pela primeira vez

            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
