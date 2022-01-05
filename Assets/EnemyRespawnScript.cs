using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���� ������ ��ũ��Ʈ
public class EnemyRespawnScript : MonoBehaviour
{
    public int stageEnemy;

    public GameObject m_enemyPrefab;
    public GameObject m_targetPrefab;
    public GameObject m_groundPrefab;
    public float m_respawnTime = 0;
    public int m_respawnEnemyNumber = 10;
    public int m_firstRespawnEnemyNumber = 10;
    public int m_stageNum = 3;

    public bool checkStageEnd = false;

    GameObject teddyObject;
    TrackingEnemyScript trackingEnemyScript;
    int saveRespawnEnemyNumber = 0;
    int saveFirstRespawnEnemyNumber = 0;

    public int totalEnemyNum = 0;

    private void RandomRespawn()
    {
        //�� ������Ʈ�� ������ z��(������) ��ġ
        Vector3 groundPosition = Camera.main.WorldToScreenPoint(m_groundPrefab.transform.position);
        float xPosition;
        float yPosition;
        string objName = m_enemyPrefab.name;
        GameObject gameObject;
        Vector3 spawnPosition;
        Vector3 targetDirection;
        Quaternion rotatedTargetDirection;

        switch (Random.RandomRange(0, 4))
        {
            //��
            case 0:
                //ī�޶�� ���� üũ
                xPosition = Random.Range(0, Screen.width);
                yPosition = Random.Range(Screen.height + 1000, Screen.height + 1200);
                //Debug.Log("�� : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //ĳ���Ϳ� ����� ���� List ������ ���� ���� �̸� ����
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
            //��
            case 1:
                //ī�޶�� ���� üũ
                xPosition = Random.Range(Screen.width + 600, Screen.width + 800);
                yPosition = Random.Range(0, Screen.height);
                //Debug.Log("�� : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //ĳ���Ϳ� ����� ���� List ������ ���� ���� �̸� ����
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
            //��
            case 2:
                //ī�޶�� ���� üũ
                xPosition = Random.Range(0, Screen.width);
                yPosition = Random.Range(-600, -400);
                //Debug.Log("�� : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //ĳ���Ϳ� ����� ���� List ������ ���� ���� �̸� ����
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
            //��
            case 3:
                //ī�޶�� ���� üũ
                xPosition = Random.Range(-600, -400);
                yPosition = Random.Range(0, Screen.height);
                //Debug.Log("�� : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //ĳ���Ϳ� ����� ���� List ������ ���� ���� �̸� ����
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        //Debug.Log("ī�޶�� �ʺ� : " + Screen.width + ", " + "ī�޶�� ���� : " + Screen.height);
        //ī�޶�� �� ������ ��ġ���� �� ������Ʈ ����
        while (m_respawnEnemyNumber != 0)
        {
            RandomRespawn();

            //������ �� ������Ʈ ���� - 1
            m_respawnEnemyNumber -= 1;
            

            yield return new WaitForSeconds(m_respawnTime);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        teddyObject = GameObject.FindWithTag("Teddy");
        trackingEnemyScript = teddyObject.GetComponent<TrackingEnemyScript>();
        
        
        stageEnemy = m_firstRespawnEnemyNumber + m_respawnEnemyNumber;
        saveFirstRespawnEnemyNumber = m_firstRespawnEnemyNumber;
        saveRespawnEnemyNumber = m_respawnEnemyNumber;

        for (int i = 0; i < m_firstRespawnEnemyNumber; i++)
        {
            RandomRespawn();
        }

        StartCoroutine(SpawnEnemy());


    }

    // Update is called once per frame
    void Update()
    {
        //Teddy�� ���������� enemy �� ��ҳ� Ȯ��, �������� ����� checkStageEnd = true
        checkStageEnd = trackingEnemyScript.stageEnd;

        //�������� �����
        if(m_respawnEnemyNumber == 0 && checkStageEnd && m_stageNum != 0)
        {
            totalEnemyNum = 0;
            Debug.Log("EnemyRespawn : �������� ���� Ȯ��");
            m_stageNum -= 1;
            
            {
                saveFirstRespawnEnemyNumber += 5;
                saveRespawnEnemyNumber += 5;
                m_respawnEnemyNumber = saveRespawnEnemyNumber;
                stageEnemy = saveRespawnEnemyNumber + saveFirstRespawnEnemyNumber;



                //�ʱ� �� ������
                for (int i = 0; i < saveFirstRespawnEnemyNumber; i++)
                {
                    Debug.Log(m_stageNum + "�������� ����");
                    RandomRespawn();
                }
                //���� �� ������
                StartCoroutine(SpawnEnemy());

                checkStageEnd = false;
            } 
        }

        
    }
}
