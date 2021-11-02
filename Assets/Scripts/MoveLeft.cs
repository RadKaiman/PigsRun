using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private float leftBound = -30;
    private PlayerController playerControllerScript;

    public bool pauseMoveLeft = false;
    void Start()
    {
        playerControllerScript = GameObject.Find("pigHero").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseMoveLeft == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Acorns")))
        {
            Destroy(gameObject);
        }
    }
}
