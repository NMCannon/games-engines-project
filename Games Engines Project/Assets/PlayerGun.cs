using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bullet_spawn;
    public float bulletSpeed = 30f;
    public float lifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player clicks left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Instatiate bullet
        GameObject bullet = Instantiate(bulletPrefab);

        // Ignore collision with player's gun (parent)
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bullet_spawn.parent.GetComponent<Collider>());

        // Spawn bullet at bullet spawn position
        bullet.transform.position = bullet_spawn.position;

        // Convert quaternion roation to vector3
        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        // Set bullet rotation
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        // Project the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bullet_spawn.forward * bulletSpeed, ForceMode.Impulse);

        // Start Coroutine
        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    // Coroutine for destroying bullets after specified time
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

}
