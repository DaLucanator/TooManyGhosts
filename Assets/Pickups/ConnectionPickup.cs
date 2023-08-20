using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPickup : MonoBehaviour
{
   [SerializeField] GameObject helper;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Instantiate(helper);
            other.GetComponent<Player>().Connection();
            Destroy(gameObject);
        }
    }
}
