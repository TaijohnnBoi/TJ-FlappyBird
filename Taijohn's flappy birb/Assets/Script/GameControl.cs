using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{ 

    public static GameControl instance;
    public GameObject GameOverText;
    public TextMeshProUGUI scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;

    AudioSource audioSource;
    public AudioClip scoreSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake ()
    {
        if (instance == null) 
        { 
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0)) 
           
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        GameOverText.SetActive (true);
        gameOver = true;
    }
}