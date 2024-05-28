using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private int hp;
    public TMP_Text TextMesh;

    // Start is called before the first frame update
    void Start()
    {
        hp = GameController.BossHp;
        var foundObject = GameObject.FindWithTag("HpWalker");

        if (foundObject != null)
        {
            TextMesh = foundObject.GetComponent<TMP_Text>();
            TextMesh.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Boss HP: {hp}");
        if (TextMesh != null)
            TextMesh.text = $"Boss HP: {hp}";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (hp > 0)
            {
                hp -= 50;
                Destroy(collision.gameObject);
            }
            else
            {
                GameController.BossDefeated = true;
                Game2Controller.BossDefeated = true;
                Game3Controller.BossDefeated = true;

                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("End"))
        {
            GameController.GameOver = true;
            Game2Controller.GameOver = true;
            Game3Controller.GameOver = true;
            Destroy(gameObject);
        }
    }
}
