using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicationPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Medication();
            Destroy(gameObject);
        }
    }
}
