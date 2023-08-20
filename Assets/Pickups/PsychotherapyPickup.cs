using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychotherapyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Psychotherapy();
            Destroy(gameObject);
        }
    }
}
