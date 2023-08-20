using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExercisePickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Exercise();
            Destroy(gameObject);
        }
    }
}
