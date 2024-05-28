using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;
    private float nextFireTime = 0f;

    void Start()
    {
        Physics.IgnoreLayerCollision(7, 8);
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 0.25f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 180, 0));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
            rb.velocity = firePoint.forward * bulletSpeed;
        else
            Debug.LogError("Rigidbody não encontrado na bala. Certifique-se de que a bala tenha um Rigidbody.");

        Destroy(bullet, .5f);
    }
}
