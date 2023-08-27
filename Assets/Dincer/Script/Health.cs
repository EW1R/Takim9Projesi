using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
//    [SerializeField] private Image totalHealthBar;
    //[SerializeField] private Image currentHealthBar;
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
    void Update()
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
       // currentHealthBar.fillAmount = currentHealth / healthAmount;
=======
<<<<<<< HEAD
        //totalHealthBar.fillAmount = currentHealth / healthAmount;
        
=======
        currentHealthBar.fillAmount = currentHealth / healthAmount;
>>>>>>> cecb71c95419aa12026e32f8d8d10a87923bccae
>>>>>>> ce1bbf65c3f4f6f04881e16baebed13e30565ddb
>>>>>>> 1456b850e0dcfade142f1fa8ff1c54cf47ad903a
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
