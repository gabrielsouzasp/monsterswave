using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player1;
    public TMP_Text boardText;
    private float offsetZ = 0.3f;
    public static int playerCount = 1;
    private bool hasCollided = false;
    private int maxPlayerCount = 24;
    
    void Start()
    {
        boardText.text = $"+ 1";
        player1 = GameObject.Find("Player1");

        if(player1 == null)
        {
            player1 = GameObject.Find("Player");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("End"))
            Destroy(gameObject);

        if (!hasCollided && collision.gameObject.CompareTag("Player"))
        {
            hasCollided = true; 

            if (playerCount <= maxPlayerCount)
            {
                if (playerCount < 6)
                {
                    if (player1 == null)
                        player1 = GameObject.Find("Player");

                    var pos1 = player1.transform.position;
                    var newPos = new Vector3(pos1.x, pos1.y, pos1.z + (offsetZ * playerCount));
                    Instantiate(playerPrefab, newPos, Quaternion.Euler(0, -90, 0));
                }

                if (playerCount >= 6 && playerCount < 12)
                {
                    if (player1 == null)
                        player1 = GameObject.Find("Player");

                    var pos1 = player1.transform.position;
                    var newPos = new Vector3(pos1.x - 0.4f, pos1.y, pos1.z + (offsetZ * (playerCount - 6)));
                    Instantiate(playerPrefab, newPos, Quaternion.Euler(0, -90, 0));
                }

                if (playerCount >= 12 && playerCount < 18)
                {
                    if (player1 == null)
                        player1 = GameObject.Find("Player");
                    
                    var pos1 = player1.transform.position;
                    var newPos = new Vector3(pos1.x - 0.8f, pos1.y, pos1.z + (offsetZ * (playerCount - 12)));
                    Instantiate(playerPrefab, newPos, Quaternion.Euler(0, -90, 0));
                }

                if (playerCount >= 18 && playerCount < 24)
                {
                    if (player1 == null)
                        player1 = GameObject.Find("Player");

                    var pos1 = player1.transform.position;
                    var newPos = new Vector3(pos1.x - 1.2f, pos1.y, pos1.z + (offsetZ * (playerCount - 18)));
                    Instantiate(playerPrefab, newPos, Quaternion.Euler(0, -90, 0));
                }

                playerCount++;
            }

            Destroy(gameObject);
            Debug.Log($"Player count: {playerCount}");
        }
    }

}
