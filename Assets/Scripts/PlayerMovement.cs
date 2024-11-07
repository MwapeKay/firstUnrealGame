using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jump = 0;
    private Rigidbody2D rb;
    private bool isGrounded;

    public Animator anim;

    
    public GameObject gameOverScreen;
    public CoinScript CS;
   

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("Slide");
        }
        if (gameOverScreen.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            CS.coinsCount++;
        }

    }

    private void GameOver()
    {
        
        gameOverScreen.SetActive(true);
       
        Time.timeScale = 0f;
    }

    
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1f;
    }

    
    public void MainMenu()
    {
       
        SceneManager.LoadScene("MainMenu");
        
        Time.timeScale = 1f;
    }

    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}

