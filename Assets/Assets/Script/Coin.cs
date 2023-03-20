using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToGive;
    private float startYPos;
    public float pobHeight;
    public float pobSpeed;
    void Start()
    {
        startYPos = transform.position.y;
    }
    void Update()
    {
        float newY = startYPos + (Mathf.Sin(Time.time* pobSpeed)*pobHeight);
        transform.position = new Vector3(transform.position.x, newY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Did the player hit us?
        if (collision.CompareTag("Player"))
        {
            // Increase their score, then destroy our GameObject.
            collision.GetComponent<PlayerController>().AddScore(scoreToGive);
            Destroy(gameObject);
        }
    }
}
