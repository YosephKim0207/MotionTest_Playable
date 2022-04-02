using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//몬스터의 캐릭터 추적 및 공격
public class TrackingCharacterScript : MonoBehaviour
{
    //public GameObject m_targetPrefab;
    public float m_attackRange = 0.0f;
    private float distance = 0.0f;

    NavMeshAgent navmesh;
    Animator animator;
    GameObject targetObject;


    private const string isAttacking = "isAttacking";
    private const string isRunning = "isRunning";

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        targetObject = GameObject.FindWithTag("Player");
        Debug.Log(targetObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.SetDestination(targetObject.transform.position);

        //캐릭터 오브젝트와의 거리 측정 및 근접시 공격
        distance = Vector3.Distance(this.transform.position, targetObject.transform.position);
        //Debug.Log(gameObject.name + "거리 : " + distance);
        if (distance <= m_attackRange)
        {
            Debug.Log("Attack!");
            //Debug.Log("거리 : " + distance);
            this.animator.SetBool(isRunning, false);
            this.navmesh.velocity = Vector3.zero;
            this.animator.SetBool(isAttacking, true);
        }
        else
        {
            this.animator.SetBool(isAttacking, false);
            this.animator.SetBool(isRunning, true);
        }
    }
}