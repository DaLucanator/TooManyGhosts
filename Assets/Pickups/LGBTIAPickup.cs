using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGBTIAPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            other.GetComponent<Player>().LGBTQIA();
            Destroy(gameObject);
        }
    }
}
