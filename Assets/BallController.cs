using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public int score = 0;
    bool isRoundClear = false;
    bool isButtonPressed = false;
    bool ballMovingToRight = true;
    [SerializeField] float ballSpeed = 0.1f;
    
   
    void Start()
    {
        ball.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        play();
    }

    void play()
    {
        var ballCurrentPosition = ball.transform.position;
        Vector3 moveRight = new Vector3(0.2f * ballSpeed, 0f, 0f);
        Vector3 moveLeft = new Vector3(-0.2f * ballSpeed, 0f, 0f);

        //Ball Moving to right
        if (ballCurrentPosition.x < 5 && (isButtonPressed == false) && ballMovingToRight)
        {
            ball.transform.position += moveRight;
        } else
        {
            ballMovingToRight = false;
        }

        //Ball Moving to left
        if (ballCurrentPosition.x > -5 && (isButtonPressed == false) && (ballMovingToRight == false))
        {
            ball.transform.position += moveLeft;
        } else
        {
            ballMovingToRight = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            isButtonPressed = true;
            ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            FindAnyObjectByType<GameManager>().pressSpace.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pin"))
        {
            ball.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        if (collision.collider.CompareTag("Bin15") && (isRoundClear == false))
        {
            score += 15;
            isRoundClear = true;
        }

        if (collision.collider.CompareTag("Bin50") && (isRoundClear == false))
        {
            score += 50;
            isRoundClear = true;
        }
    }
}
