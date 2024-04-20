using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddleSpawnPosition;
    public Transform multiplierPowerUp;
    public Transform expanderPowerUp;
    public Transform extraLifePowerUp;
    public Transform shortenerPowerUp;
    public float speed;
    public GameManager gm;
    public int numberOfBalls;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        inPlay = false;
        // rb.AddForce(Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay && numberOfBalls <= 1)
        {
            transform.position = paddleSpawnPosition.position;
        }
        if (gm.gameOver)
        {
            return;
        }
        if (Input.GetButtonDown ("Fire1") && !inPlay)
        {
            inPlay = true;
            this.rb.AddForce(Vector2.up * speed);
        }
        numberOfBalls = GameObject.FindGameObjectsWithTag("ball").Length;
    } 

    void FixedUpdate()
{
    if (gm.gameOver)
    {
        rb.velocity = rb.velocity.normalized * 0f;
        inPlay = false;
    }
    else if (inPlay)
    {
        rb.velocity =rb.velocity.normalized * speed;

    }
}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("bottom"))
        {
           rb.velocity = Vector2.zero;
           if(gameObject.CompareTag("ball"))
           {
                
                if(numberOfBalls <= 1)
           {
                gm.UpdateLives (-1);
                gm.UpdateScore (-1);
            }
            
            
           }
           
           inPlay = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 collisionVelocity = this.rb.velocity;

        if (other.transform.CompareTag("brick"))
        {
            BrickScript brickScript = other.gameObject.GetComponent<BrickScript> ();
            if (brickScript.hitPoints > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
            int randChance = Random.Range(1,101);
            if (randChance <= 20)
            {
                
                int randomChance = Random.Range(1,101);
                if (randomChance <= 15)
                {
                    Instantiate (extraLifePowerUp, other.transform.position, other.transform.rotation);
                }
                if (randomChance > 15 && randomChance <= 30)
                {
                    Instantiate (expanderPowerUp, other.transform.position, other.transform.rotation);
                }
                if (randomChance > 30 && randomChance <= 50)
                {
                    Instantiate (shortenerPowerUp, other.transform.position, other.transform .rotation);
                }
                if (randomChance > 50 && randomChance <= 100)
                {
                    Instantiate (multiplierPowerUp, other.transform.position, other.transform .rotation);
                }
            }
            
            gm.UpdateScore(1);
            gm.UpdateNumberOfBricks();
            Destroy(other.gameObject);
            }
            

        }
        
    
    }
    
}
