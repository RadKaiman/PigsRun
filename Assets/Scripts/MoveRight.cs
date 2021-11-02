using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 20;
    private float leftBound = -30;
    private PlayerController playerControllerScript;

    public bool pauseMoveRight = false;
    void Start()
    {
        playerControllerScript = GameObject.Find("pigHero").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseMoveRight == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Acorns")))
        {
            Destroy(gameObject);
        }
    }
}
