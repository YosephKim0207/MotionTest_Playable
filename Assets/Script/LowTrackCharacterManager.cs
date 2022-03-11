using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LowTrackCharacterManager : MonoBehaviour
{
    NavMeshAgent navmesh;
    public GameObject m_targetObject;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        navmesh.SetDestination(m_targetObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.SetDestination(m_targetObject.transform.position);
    }
}
