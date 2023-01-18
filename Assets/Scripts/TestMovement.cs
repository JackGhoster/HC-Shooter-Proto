using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _destination;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(_agent, _destination);
    }

    void Movement(NavMeshAgent agent, Transform destination)
    {
        agent.destination = destination.position;
    }
}
