using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BaseCharacterController))]
public class RandomPointGenerator : MonoBehaviour
{
    [SerializeField]
    private NavMeshData navMesh;

    private BaseCharacterController characterController;
    private NavMeshAgent agent;
    private Bounds levelBounds;
    private Vector3 targetPoint;
    private bool flag = false;

    private void Start()
    {
        characterController = GetComponent<BaseCharacterController>();
        agent = GetComponent<NavMeshAgent>();
        levelBounds = navMesh.sourceBounds;
    }

    private void Update()
    {
        if (characterController.isActive)
        {
            if (!agent.hasPath && !flag)
            {
                flag = true;
                SetRandomDestination();
            }
        }
    }

    internal void SetRandomDestination()
    {
        float posX = Random.Range(levelBounds.min.x, levelBounds.max.x);
        float posZ = Random.Range(levelBounds.min.z, levelBounds.max.z);
        targetPoint = new Vector3(posX, transform.position.y, posZ);
        agent.SetDestination(targetPoint);
        Invoke(nameof(CheckPointOnPath), 0.2f);
        flag = false;
    }

    private void CheckPointOnPath()
    {
        if (agent.pathEndPosition != targetPoint)
        {
            SetRandomDestination();
        }
    }
}
