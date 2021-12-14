using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackingCharacterScript : MonoBehaviour
{
    public GameObject m_targetPrefab;
    //public Transform target;

    NavMeshAgent navmesh;

    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.SetDestination(m_targetPrefab.transform.position);
    }
}
