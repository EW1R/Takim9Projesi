using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthAmount;

    public GameObject bloodPrefab;

    public bool isPlayer = false;
    private bool isDead = false;
    private float currentHealth;

    public Canvas canva;

    void Start()
    {
        currentHealth = healthAmount;
    }


    public void TakeDamage(float attackDamage)
    {
        float temp = Mathf.Max(currentHealth - attackDamage, 0);
        currentHealth = temp;

        if (currentHealth == 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            //Instantiate(bloodPrefab,transform.position+Vector3.up*5f, Quaternion.Euler(-90f, 0, 0));    

            isDead = true;
            Destroy(gameObject);
        }

        if (isPlayer)
        {

            //Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            //canva.gameObject.SetActive(true);
            isDead = true;
            GetComponent<PlayerController>().enabled = false;
            Destroy(gameObject);
        }
    }
    void SpawnParticle(GameObject particle, Transform spawnPos)
    {
        Instantiate(particle, spawnPos.position, Quaternion.identity);

    }
}
