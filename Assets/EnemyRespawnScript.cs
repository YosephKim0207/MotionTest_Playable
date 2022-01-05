using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//몬스터 리스폰 스크립트
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
        //적 오브젝트가 생성될 z축(높낮이) 위치
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
            //북
            case 0:
                //카메라뷰 범위 체크
                xPosition = Random.Range(0, Screen.width);
                yPosition = Random.Range(Screen.height + 1000, Screen.height + 1200);
                //Debug.Log("북 : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //캐릭터와 가까운 몬스터 List 관리를 위한 몬스터 이름 생성
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
            //동
            case 1:
                //카메라뷰 범위 체크
                xPosition = Random.Range(Screen.width + 600, Screen.width + 800);
                yPosition = Random.Range(0, Screen.height);
                //Debug.Log("동 : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //캐릭터와 가까운 몬스터 List 관리를 위한 몬스터 이름 생성
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
            //남
            case 2:
                //카메라뷰 범위 체크
                xPosition = Random.Range(0, Screen.width);
                yPosition = Random.Range(-600, -400);
                //Debug.Log("남 : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //캐릭터와 가까운 몬스터 List 관리를 위한 몬스터 이름 생성
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
            //서
            case 3:
                //카메라뷰 범위 체크
                xPosition = Random.Range(-600, -400);
                yPosition = Random.Range(0, Screen.height);
                //Debug.Log("서 : " + xPosition + ", " + yPosition);
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                targetDirection = m_targetPrefab.transform.position - spawnPosition;
                rotatedTargetDirection = Quaternion.LookRotation(targetDirection);
                //캐릭터와 가까운 몬스터 List 관리를 위한 몬스터 이름 생성
                gameObject = Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatedTargetDirection);
                gameObject.name = objName + m_respawnEnemyNumber.ToString();
                totalEnemyNum += 1;
                break;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        //Debug.Log("카메라뷰 너비 : " + Screen.width + ", " + "카메라뷰 높이 : " + Screen.height);
        //카메라뷰 밖 랜덤한 위치에서 적 오브젝트 생성
        while (m_respawnEnemyNumber != 0)
        {
            RandomRespawn();

            //생성할 적 오브젝트 숫자 - 1
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
        //Teddy가 스테이지의 enemy 다 잡았나 확인, 스테이지 종료시 checkStageEnd = true
        checkStageEnd = trackingEnemyScript.stageEnd;

        //스테이지 종료시
        if(m_respawnEnemyNumber == 0 && checkStageEnd && m_stageNum != 0)
        {
            totalEnemyNum = 0;
            Debug.Log("EnemyRespawn : 스테이지 종료 확인");
            m_stageNum -= 1;
            
            {
                saveFirstRespawnEnemyNumber += 5;
                saveRespawnEnemyNumber += 5;
                m_respawnEnemyNumber = saveRespawnEnemyNumber;
                stageEnemy = saveRespawnEnemyNumber + saveFirstRespawnEnemyNumber;



                //초기 적 리스폰
                for (int i = 0; i < saveFirstRespawnEnemyNumber; i++)
                {
                    Debug.Log(m_stageNum + "스테이지 시작");
                    RandomRespawn();
                }
                //순차 적 리스폰
                StartCoroutine(SpawnEnemy());

                checkStageEnd = false;
            } 
        }

        
    }
}
