using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public int coinsCount;
    public Text coinText;
    public GameObject[] spawnPoints; 
    public float coinSpeed = 5f;
    private float timer;
    private Rigidbody2D coinRigidbody;
    private PlayerMovement pm;
    public float speedMultiplier;

    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Coin").GetComponent<PlayerMovement>();

        coinRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       coinText.text = ": " + coinsCount.ToString();
        speedMultiplier += Time.deltaTime * 0.1f;
        timer += Time.deltaTime;
        
        coinRigidbody.velocity = Vector2.left * coinSpeed;
    }
}