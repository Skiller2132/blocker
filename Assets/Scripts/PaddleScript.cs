using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightSideEdge;
    public float leftSideEdge;
    public GameManager gm;
    public Vector2 paddleScale;
    public Transform ballPos;
    public GameObject ball;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ballPos = ball.gameObject.GetComponent<Transform> ();
        if(gm.gameOver)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < leftSideEdge) 
            {
                transform.position = new Vector2 (leftSideEdge, transform.position.y);
            }
        if (transform.position.x > rightSideEdge) 
            {
                transform.position = new Vector2 (rightSideEdge, transform.position.y);
            }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        paddleScale =ballPos.transform.position;
        
        if (other.transform.CompareTag("extralife"))
        {
            gm.UpdateLives(1);
        }
        else if (other.transform.CompareTag("expander"))
        {
            if (paddleScale.x < 1.5f)
            {
                rightSideEdge -= 0.35f;
                leftSideEdge +=0.35f;
                paddleScale.x += 0.35f; 
            }
        }
        else if (other.transform.CompareTag("shortener"))
        {
            if (paddleScale.x > 0.55f)
            {
                rightSideEdge += 0.25f;
                leftSideEdge -=0.25f;
                paddleScale.x -= 0.25f;
            }
        }
        else if (other.transform.CompareTag("multiplier"))
        {
            
        }
        transform.localScale = paddleScale;
        Destroy(other.gameObject);
    }
}
