using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 10f; 
    public float fireRate = 1f; 

    private float nextFireTime; 

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = firePoint.right * bulletSpeed;
    }
}
