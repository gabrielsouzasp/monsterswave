using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 1f;
    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCameraTransform != null)
        {
            // Calcula a posição da câmera no plano XZ
            Vector3 cameraPosition = mainCameraTransform.position;

            // Calcula a direção para a câmera apenas no eixo X
            Vector3 direction = (cameraPosition - transform.position).normalized;
            direction.z = 0;
            direction.y = 0;

            // Move o objeto na direção calculada
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
