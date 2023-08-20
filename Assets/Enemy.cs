using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;

    [SerializeField] GameObject sprite;
    [SerializeField] UnityEngine.Sprite normalSprite, frightenSprite;

    SpriteRenderer rend;

    bool isFrightened;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = Player.current.transform;

        rend = sprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        agent.destination = player.position;
    }

    public void KillIn30()
    {
        StartCoroutine(KillIn30Coroutine());
    }

    IEnumerator KillIn30Coroutine()
    {
        yield return new WaitForSeconds(30f);
        Kill();
    }

    public void Frighten()
    {
        isFrightened = true;
        agent.destination = EnemySpawner.current.spawnPositions[Random.Range(0, EnemySpawner.current.spawnPositions.Length)].position;

        rend.sprite = frightenSprite;
    }

    public void UnFrighten()
    {
        rend.sprite = normalSprite;
        agent.destination = player.position;
        isFrightened = false;
    }

    public void Kill()
    {
        Destroy(sprite);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            if(isFrightened)
            {
                Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
                if (enemies.Length == 1)
                {
                    Player.current.Win();
                }
                Kill();
            }
            else
            {
                Player.current.Lose();
            }
        }
    }

}

