using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Helper : MonoBehaviour
{
    NavMeshAgent agent;

    Transform target;

    [SerializeField] GameObject sprite;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        FindNewTarget();
    }

    private void Update()
    {
        if(target!= null) { agent.destination = target.position; }

        else FindNewTarget();
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<Enemy>())
        {
            target = transform;
            col.gameObject.GetComponent<Enemy>().Kill();
            FindNewTarget();
        }
    }

    private void FindNewTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        if(enemies.Length > 0 ) { target = enemies[Random.Range(0, enemies.Length)].transform; }
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(30f);

        Destroy(sprite);
        Destroy(gameObject);
    }
}
