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
        //�� ������Ʈ�� ������ z��(������) ��ġ
        Vector3 groundPosition = Camera.main.WorldToScreenPoint(m_groundPrefab.transform.position);
        float xPosition; 
        float yPosition; 
        Vector3 spawnPosition;
        Vector3 targetDirection;
        Quaternion rotatdTargetDirection;

        Debug.Log("ī�޶�� �ʺ� : " + Screen.width + ", " + "ī�޶�� ���� : " + Screen.height);
        //ī�޶�� �� ������ ��ġ���� �� ������Ʈ ����
        while (enemyNumber != 0)
        {
            switch (Random.RandomRange(0, 4))
            {
                //��
                case 0:
                    //ī�޶�� ���� üũ
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height + 4000, Screen.height + 4200);
                    Debug.Log("�� : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
                //��
                case 1:
                    //ī�޶�� ���� üũ
                    xPosition = Random.Range(Screen.width + 600, Screen.width + 800);
                    yPosition = Random.Range(0, Screen.height);
                    Debug.Log("�� : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
                //��
                case 2:
                    //ī�޶�� ���� üũ
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-600, -400);
                    Debug.Log("�� : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
                //��
                case 3:
                    //ī�޶�� ���� üũ
                    xPosition = Random.Range(-600, -400);
                    yPosition = Random.Range(0, Screen.height);
                    Debug.Log("�� : " + xPosition + ", " + yPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    //Ÿ�� ������Ʈ �������� �� ������Ʈ ȸ������ �����ϱ�
                    targetDirection = m_targetPrefab.transform.position - spawnPosition;
                    rotatdTargetDirection = Quaternion.LookRotation(targetDirection);
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), rotatdTargetDirection);
                    break;
            }
            //������ �� ������Ʈ ���� - 1
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
