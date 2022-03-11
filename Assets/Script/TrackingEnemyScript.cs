using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class TrackingEnemyScript : MonoBehaviour
{
    //DistanceCheckScript�� List�� ����� 0��° Enemy Attack
    public GameObject m_characterPrefab;
    DistanceCheckScript distanceCheckScript;
    GameObject targetObject;
    NavMeshAgent navmesh;
    EnemyRespawnScript enemyRespawnScript;
    GameObject enemyRespawnObject;
    private float distance = 0.0f;
    public int totalEnemyNum = 0;
    public int killEnemyCount = 0;
    public bool stageEnd = false;

    int stageNum = 0;
    float sceneWaitTime = 30.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            distanceCheckScript.nearEnemyList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            killEnemyCount += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        distanceCheckScript = m_characterPrefab.GetComponent<DistanceCheckScript>();
        enemyRespawnObject = GameObject.FindWithTag("EnemySpawner");
        enemyRespawnScript = enemyRespawnObject.GetComponent<EnemyRespawnScript>();
        stageNum = enemyRespawnScript.m_stageNum;
    }

    // Update is called once per frame
    void Update()
    {
        totalEnemyNum = enemyRespawnScript.stageEnemy;
        stageEnd = enemyRespawnScript.checkStageEnd;

        //ĳ���� �ٰŸ� �� ����
        if (distanceCheckScript.nearEnemyList.Count != 0)
        {
            targetObject = distanceCheckScript.nearEnemyList[0];
            navmesh.SetDestination(targetObject.transform.position);
            distance = Vector3.Distance(this.transform.position, targetObject.transform.position);
            if (distance <= 0.7f)
            {
                this.navmesh.velocity = Vector3.zero;
                distanceCheckScript.nearEnemyList.Remove(targetObject);
                Destroy(targetObject);

                //�������� ���� ī��Ʈ
                killEnemyCount += 1;
            }
        }
        else
        {
            //Debug.Log("���� Ÿ�� ����");
            navmesh.SetDestination(m_characterPrefab.transform.position);
            distance = Vector3.Distance(this.transform.position, m_characterPrefab.transform.position);

            if (distance <= 1.5f)
            {
                this.navmesh.velocity = Vector3.zero;
            }
        }

        if (killEnemyCount == totalEnemyNum)
        {
            stageNum -= 1;

            //�� ���� ���� ����
            if (stageNum == 0)
            {
                //�� ���� �� ���� happyEnd
                while (sceneWaitTime > 0)
                {
                    sceneWaitTime -= Time.deltaTime;
                }
                SceneManager.LoadScene("Scenes/BedSceneDoll 4");
            }
            else
            {
                //EnemyRespawnScript���� ���� ���������� ��ȯ
                stageEnd = true;
                //ųī��Ʈ �ʱ�ȭ
                killEnemyCount = 0;
            }
                
        }
    }
}
