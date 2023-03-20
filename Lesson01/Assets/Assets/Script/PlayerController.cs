using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumforce;
    private bool isGrounded;
    public SpriteRenderer Sr;
    public int score;
    public TextMeshProUGUI socreText;


    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
       /// Debug.Log("this is move input: "+moveInput);
        rig.velocity = new Vector2(moveInput * moveSpeed, rig.velocity.y);
       // Debug.Log("This is move speed: " + moveSpeed);

        if (rig.velocity.x > 0)
        {
            Sr.flipX = true;
        }
        else if (rig.velocity.x < 0)
        {
            Sr.flipX = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded==true){
            isGrounded=false;
            rig.AddForce(Vector2.up * jumforce,ForceMode2D.Impulse);
        }

        if (transform.position.y < -4)
        {
            GameOver();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    

    }
    public void AddScore(int amout)
    {
        score += amout;
        socreText.text ="Score: " + score;
    }
}
