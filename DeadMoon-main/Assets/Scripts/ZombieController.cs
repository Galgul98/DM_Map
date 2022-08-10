using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent = null;
   [SerializeField] private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    private void RotateToTarget()
    {
       // transform.LookAt(target);

        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackTarget()
    {

    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }

}
