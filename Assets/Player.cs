using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;

    [SerializeField] TextMeshProUGUI textObject;

    [SerializeField] GameObject win, lose;

    public static Player current;

    Vector3 moveVector;
    bool isDrunk;

    private IEnumerator TypeText(string textToType)
    {
        textObject.text = "";

        foreach (char t in textToType) 
        {
            textObject.text += t;

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Win()
    {
        win.SetActive(true);
    }

    public void Lose()
    { 
        lose.SetActive(true);
    }

    public void Awake()
    {
        current = this;
    }

    public Transform ReturnPlayerTransform()
    {
        return transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        moveVector.Normalize();

        if (isDrunk)
        {
            moveVector = -moveVector;
        }

        MovePlayer(moveVector);
        SpeedControl();
        
        if(moveVector == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void MovePlayer(Vector3 directionToMove)
    {
        rb.AddForce(directionToMove * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void RemoveRandomGhost()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        enemies[Random.Range(0, enemies.Length)].Kill();

        CheckForGhost();
    }

    private void CheckForGhost()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Debug.Log(enemies.Length);
        if(enemies.Length == 1)
        {
            Win();
        }
    }

    public void Alcohol()
    {
        StopCoroutine(AlcoholCoroutine());
        StartCoroutine(AlcoholCoroutine());

        StartCoroutine(TypeText("Research suggests a causal link in that alcohol abuse leads to major depressive disorder"));
    }
    private IEnumerator AlcoholCoroutine()
    {
        isDrunk = true;
        EnemySpawner.current.SpawnEnemy();

        yield return new WaitForSeconds(30f);
        isDrunk = false;
    }

    public void Disability()
    {
        StopCoroutine(DisabilityCoroutine());
        StartCoroutine(DisabilityCoroutine());

        StartCoroutine(TypeText("Disability is a risk factor for depression"));
    }

    private IEnumerator DisabilityCoroutine()
    {
        moveSpeed = 2;
        EnemySpawner.current.SpawnEnemy();

        yield return new WaitForSeconds(30f);
        moveSpeed = 3;
    }

    public void Connection()
    {
        StartCoroutine(TypeText("Social participation and connection are known to be effective at treating depression"));
    }

    public void Exercise()
    {
        StopCoroutine(ExerciseCoroutine());
        StartCoroutine(ExerciseCoroutine());

        StartCoroutine(TypeText("Physical exercise can be an effective treatment for depression"));
    }
    private IEnumerator ExerciseCoroutine()
    {
        moveSpeed = 4;
        RemoveRandomGhost();

        yield return new WaitForSeconds(30f);
        moveSpeed = 3;
    }

    public void LGBTQIA()
    {
        EnemySpawner.current.SpawnEnemy();
        EnemySpawner.current.SpawnEnemy();

        StartCoroutine(TypeText("People from LGBTQIA+ communities are more likely to struggle with emotional and psychological wellbeing, and experience mental health issues"));
    }

    public void Psychotherapy()
    {
        StopCoroutine(PsychotherapyCoroutine());
        StartCoroutine(PsychotherapyCoroutine());

        StartCoroutine(TypeText("Pyschotherapy is a common effective treatment for depression"));
    }

    private IEnumerator PsychotherapyCoroutine()
    {
        RemoveRandomGhost();

        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.agent.speed = 0.25f;
        }

        yield return new WaitForSeconds(30f);

        enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.agent.speed = 0.5f;
        }
    }

    public void Bullying()
    {
        EnemySpawner.current.SpawnEnemyTemp();

        StartCoroutine(TypeText("Bullying has a wide range of long term negative side-effects including depression and anxiety that can last deep into adulthood"));
    }

    public void Medication()
    {
        StopCoroutine(MedicationCoroutine());
        StartCoroutine(MedicationCoroutine());

        StartCoroutine(TypeText("Medication is a common effective treatment for depression"));
    }

    private IEnumerator  MedicationCoroutine()
    {

        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.Frighten();
        }

        yield return new WaitForSeconds(30f);

        enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.UnFrighten();
        }
    }
}
