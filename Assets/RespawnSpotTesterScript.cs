using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpotTesterScript : MonoBehaviour
{
    public GameObject m_enemyPrefab;
    public GameObject m_groundPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Respawn());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Respawn()
    {
        Vector3 groundPosition = Camera.main.WorldToScreenPoint(m_groundPrefab.transform.position);
        float xPosition;
        float yPosition;
        int termPosition = 400;
        Vector3 spawnPosition;

        for (int i = 0; i < 10; i++)
        {
            //화면 밖에서 객체 생성되게 하기
            //해상도가 달라져도 같은 위치에서 리스폰되도록 Screen좌표 활용(ScreenToWorldPoint)
            switch (Random.Range(0, 4))
            {
                //북
                case 0:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height + (termPosition * 2), Screen.height + (termPosition * 3));
                    //ScreenToWorldPoint에 원하는 위치의 z좌표를 넣지 않고 Instantiate때 넣으면 객체가 생성되는 높이가
                    //엉망이 된다
                    //ScreenToWorldPoint에서 WorldPoint는 단순한 유니티 Inspector 창의 position x,y,z가 아니다
                    //Camera.main이기 때문에 카메라 기준으로 생성된다
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //동
                case 1:
                    xPosition = Random.Range(Screen.width + termPosition, (Screen.width + termPosition * 2));
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //남
                case 2:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-(termPosition * 2), -termPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //서
                case 3:
                    xPosition = Random.Range(-(termPosition * 2), -termPosition);
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
            }
        }

        yield return new WaitForSeconds(2.0f);
    }
}
