using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3.5f;

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 8);
    }

    void Update()
    {
        if(!GameController.GameOver || !Game2Controller.GameOver || !Game3Controller.GameOver)
        {
            float moveInput = Input.GetAxis("Horizontal");
            float moveAmount = moveInput * speed * Time.deltaTime;

            transform.Translate(Vector3.right * moveAmount);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
