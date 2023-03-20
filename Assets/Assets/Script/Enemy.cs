using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Vector3 moveOffset;
    private Vector3 startPos;
    private Vector3 targetPos;
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        // Are we at the target position?
        if (transform.position == targetPos)
        {
            // Is our target pos our start pos? If so, set it to be the other one.
            if (targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            // Otherwise, do the opposite.
            else
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Did the player hit us?
        if (collision.CompareTag("Player"))
        {
            // Trigger the game over state on the player.
            collision.GetComponent<PlayerController>().GameOver();
        }
    }
}
