using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpellController : MonoBehaviour
{

    public Transform handPos;
    public Ring currentRing;


    public float chaseDistance = 8f;
    public float attackRange = 5f;


    public float moveSpeed=3f;

    


    List<GameObject> projectilePool = new List<GameObject>();

    private float lastTimeSinceAttack = Mathf.Infinity;
    [SerializeField]
    private Animator anim;

    private Transform player;

    private bool isChasing=false;
    private bool isAttacking=false;
    private NavMeshAgent navMesh;





    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (currentRing == null)
        {
            return;
        }



        CheckSurroundings();

        CheckTimers();
    }
    private void CheckSurroundings()
    {
        float distanceToPlayer = DistanceToPlayer();

        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
            transform.LookAt(player);
            if (distanceToPlayer > attackRange)
            {
                ChasePlayer();
            }
            else
            {
                isAttacking = true;
                AttackPlayer();
            }
        }
        else
        {
            isChasing = false;
        }
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }

    private void ChasePlayer()
    {
        navMesh.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);
        UseSpell1();
    }


    private void CheckTimers()
    {
        lastTimeSinceAttack += Time.deltaTime;
    }

    private void UseSpell1()
    {
        if (lastTimeSinceAttack >= currentRing.leftClick.timeBetweenAttacks)
        {
            GameObject projectile = ProjectilePool(currentRing.projectileList);
            lastTimeSinceAttack = 0;

            projectile.transform.position = handPos.position;
            projectile.transform.localRotation = Quaternion.Euler(90, 0, 0);
            projectile.SetActive(true);

            projectile.GetComponent<Rigidbody>().velocity =transform.forward * currentRing.leftClick.projectileSpeed;

            //anim.SetTrigger("isAttacking");//anim

        }


    }

   
    private GameObject ProjectilePool(List<GameObject> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null && !list[i].activeSelf)
            {
                return list[i];
            }
        }

        list.Add(Instantiate(currentRing.leftClick.projectile, handPos.position, Quaternion.identity));
        list[^1].GetComponent<Projectiles>().instigator = currentRing;
        return list[^1];




    }

    private void OnDrawGizmos()
    {
        // Draw chase range sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        // Draw attack range sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
