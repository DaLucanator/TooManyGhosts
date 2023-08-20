using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyingPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Bullying();
            Destroy(gameObject);
        }
    }
}
