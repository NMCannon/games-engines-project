using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Print hit object's name
        print("hit " + other.name + "!");

        if (other.name == "fpsPlayer" || other.name == "Enemy")
        {
            var healthComponent = other.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }
        }

        // Destory the bullet
        Destroy(gameObject);
    }
}
