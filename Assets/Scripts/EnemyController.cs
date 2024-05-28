using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("End"))
        {
            GameController.PlayerLifeCount--;
            Game2Controller.PlayerLifeCount--;
            Game3Controller.PlayerLifeCount--;
            Destroy(gameObject);
        }
    }

}
