using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EZCameraShake;

public class EnemyAi : MonoBehaviour
{
   public NavMeshAgent agent =null;

   public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private Animator animator = null;

    private ZombieStats stats = null;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet =false;
    public float walkPointRange;
    public float patrolingSpeed = 2f;
    public float chaseSpeed = 5f;

    //Attacking
    private float timeOfLastAttack = 0;
    public float timeBetweenAttacks = 1.5f;
    bool alreadyAttacked = false;
   

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //UI
    public GameObject bloodSpllater;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stats = GetComponent<ZombieStats>();
    }

    private void Update()
    {
        //Check for sight and attack range.
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
            animator.SetBool("AwareToPlayer", false);
            agent.speed = patrolingSpeed;
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            animator.SetBool("AwareToPlayer", true);
            agent.speed = chaseSpeed;

        }
        if (playerInAttackRange && playerInSightRange)
        {
            animator.SetBool("Attack", true);

            timeBetweenAttacks = Time.time;
            CharacterStats playerStats = player.GetComponent<CharacterStats>();
          //  AttackPlayer(playerStats);
            transform.LookAt(player);
            stats.DealDamage(playerStats);
            //Make sure enemy dosent move
            agent.SetDestination(player.position);
            // agent.acceleration = 1;
            

        }
       

        if (!playerInAttackRange && playerInSightRange)
        {
            ChasePlayer();
            animator.SetBool("Attack", false);
            agent.acceleration = 4;
        }

    }

    private void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;  
        
        //Walk point reached
        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,transform.position.z + randomZ);
        Debug.Log("eilon");
        StartCoroutine(CheckWalkPoint());
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        
    }
    IEnumerator CheckWalkPoint()
    {
        Vector3 walkPointCheck = walkPoint;
        yield return new WaitForSeconds(2f);
        if(walkPointCheck == walkPoint)
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            float randomZ1 = Random.Range(-walkPointRange, walkPointRange);
            float randomX1 = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX + 15f, transform.position.y, transform.position.z + randomZ + -15f);
            Debug.Log("Elhalal");
        }
        

       

    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
        
    }

    private void AttackPlayer(CharacterStats statsToDmage)
    {
        transform.LookAt(player);
        stats.DealDamage(statsToDmage);
        //Make sure enemy dosent move
        agent.SetDestination(player.position);

        

        if(!alreadyAttacked)
        {
           
           // bloodSpllater.SetActive(true);
            CameraShaker.Instance.ShakeOnce(5f,5f,0.2f,1f);
           // StartCoroutine(bloodFeedback());
            Debug.Log("attacked player");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked=false;
    }
    IEnumerator bloodFeedback()
    {

        yield return new WaitForSeconds(1.0f);
        bloodSpllater.SetActive(false);
        Debug.Log("falseBlood");
    }
}
