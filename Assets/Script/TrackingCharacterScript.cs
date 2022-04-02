using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//������ ĳ���� ���� �� ����
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

        //ĳ���� ������Ʈ���� �Ÿ� ���� �� ������ ����
        distance = Vector3.Distance(this.transform.position, targetObject.transform.position);
        //Debug.Log(gameObject.name + "�Ÿ� : " + distance);
        if (distance <= m_attackRange)
        {
            Debug.Log("Attack!");
            //Debug.Log("�Ÿ� : " + distance);
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