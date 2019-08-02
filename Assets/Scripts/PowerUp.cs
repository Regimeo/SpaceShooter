using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.fireRate = controller.fireRate - 0.03f;
        Destroy(gameObject);
    }
}
