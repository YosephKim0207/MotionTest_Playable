using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnScript : MonoBehaviour
{
    public GameObject m_enemyPrefab;
    public GameObject m_targetPrefab;
    public GameObject m_groundPrefab;
    public float m_respawnTime = 0;
    public int enemyNumber = 10;

    private List<objectPoolItem> objectPoolList;

    private class objectPoolItem
    {
        public bool isActive = true;
        public GameObject gameObject;
    }
    private void ObjectPool(GameObject m_enemyPrefab)
    {
        m_enemyPrefab.SetActive(false);
    }

    private IEnumerator SpawnEnemy()
    {
        //적 오브젝트가 생성될 z축(높낮이) 위치
        Vector3 groundPosition = Camera.main.WorldToScreenPoint(m_groundPrefab.transform.position);
        float xPosition; 
        float yPosition; 
        Vector3 spawnPosition;
        Vector3 targetDirection;
        Quaternion rotatdTargetDirection;

        Debug.Log("카메라뷰 너비 : " + Screen.width + ", " + "카메라뷰 높이 : " + Screen.height);
        //카메라뷰 밖 랜덤한 위치에서 적 오브젝트 생성
        while (enemyNumber != 0)
        {
            switch (Random.RandomRange(0, 4))
            {
                //북
                case 0:
                    //카메라뷰 범위 체크
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height + 4000, Screen.height + 4200);
                    Debug.Log("북 : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
                //동
                case 1:
                    //카메라뷰 범위 체크
                    xPosition = Random.Range(Screen.width + 600, Screen.width + 800);
                    yPosition = Random.Range(0, Screen.height);
                    Debug.Log("동 : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
                //남
                case 2:
                    //카메라뷰 범위 체크
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-600, -400);
                    Debug.Log("남 : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
                //서
                case 3:
                    //카메라뷰 범위 체크
                    xPosition = Random.Range(-600, -400);
                    yPosition = Random.Range(0, Screen.height);
                    Debug.Log("서 : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //타겟 오브젝트 방향으로 적 오브젝트 회전시켜 생성하기
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
            }
            //생성할 적 오브젝트 숫자 - 1
            enemyNumber -= 1;

            yield return new WaitForSeconds(m_respawnTime);
        }  
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        //if(enemyNumber == 0)
        //{
        //    StopCoroutine(SpawnEnemy());
        //}
    }
}
