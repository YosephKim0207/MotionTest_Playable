using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnScript : MonoBehaviour
{
    public GameObject m_enemyPrefab;
    public GameObject m_groundPrefab;
    public float m_respawnTime;

    private int enemyNumber = 0;
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
        //스테이지마다 다르게 나중에 변경하기
        //현재 enemyNumber은 임의의 숫자임
        enemyNumber = 10;

        for(int i = 0; i < enemyNumber; i++)
        {
            Vector3 groundPosition = Camera.main.WorldToScreenPoint(m_groundPrefab.transform.position);
            float xPosition; //Random.RandomRange(0, Screen.width);
            float yPosition; //Random.RandomRange(0, Screen.height);
            Vector3 spawnPosition;
            switch (Random.RandomRange(0, 4))
            {
                //북
                case 0:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height, Screen.height + 200);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //동
                case 1:
                    xPosition = Random.Range(Screen.width, Screen.width + 200);
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //남
                case 2:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-200, 0);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //서
                case 3:
                    xPosition = Random.Range(-200, 0);
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
            }

            //(GameObject)Instantiate(m_enemyPrefab, new Vector3)
        }
        yield return new WaitForSeconds(m_respawnTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
