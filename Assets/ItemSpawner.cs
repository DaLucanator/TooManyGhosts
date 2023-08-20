using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnableItems;

    private GameObject currentItem;

    private void Start()
    {
        SpawnItem();
    }
    private void SpawnItem()
    {
        if(currentItem != null)
        {
            Destroy(currentItem);
        }
       currentItem = Instantiate(spawnableItems[Random.Range(0, spawnableItems.Length)], transform.position, Quaternion.identity);

        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);

        SpawnItem();
    }
}
