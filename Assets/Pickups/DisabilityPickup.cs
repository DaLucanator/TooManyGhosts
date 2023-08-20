using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabilityPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Disability();
            Destroy(gameObject);
        }
    }
}
