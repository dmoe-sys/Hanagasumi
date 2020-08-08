using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    public NavMeshAgent enemy;
    public GameObject target;

    void Start()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            enemy.destination = target.transform.position;
        }
    }
}
