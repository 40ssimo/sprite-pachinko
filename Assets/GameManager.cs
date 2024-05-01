using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    public TMP_Text pressSpace;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    void ShowScore()
    {
        scoreText.text = "Score : " + FindAnyObjectByType<BallController>().score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
