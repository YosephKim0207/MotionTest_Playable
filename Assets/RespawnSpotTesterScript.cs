using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpotTesterScript : MonoBehaviour
{
    public GameObject m_enemyPrefab;
    public GameObject m_groundPrefab;
    public int m_enemyNum = 20;

    //termPosition은 enemy가 주인공이 있는 중앙을 제외한 외곽에서부터 respawn되게 하기 위한 공간크기
    private int m_termPosition = 400;

    //산문창작 연출용 termPosition test
    //public int m_termPosition = 50;


    // Start is called before the first frame update
    void Start()
    {
        
              
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Respawn());
            Debug.Log("리스폰");
        }
    }

    public IEnumerator Respawn()
    {
        Vector3 groundPosition = Camera.main.WorldToScreenPoint(m_groundPrefab.transform.position);
        float xPosition;
        float yPosition;
        
        Vector3 spawnPosition;

        for (int i = 0; i < m_enemyNum; i++)
        {
            //화면 밖에서 객체 생성되게 하기
            //해상도가 달라져도 같은 위치에서 리스폰되도록 Screen좌표 활용(ScreenToWorldPoint)
            switch (Random.Range(0, 4))
            {
                ////북
                //case 0:
                //    xPosition = Random.Range(0, Screen.width);
                //    yPosition = Random.Range((Screen.height/2) + m_termPosition * 3, Screen.height);
                //    //ScreenToWorldPoint에 원하는 위치의 z좌표를 넣지 않고 Instantiate때 넣으면 객체가 생성되는 높이가
                //    //엉망이 된다
                //    //ScreenToWorldPoint에서 WorldPoint는 단순한 유니티 Inspector 창의 position x,y,z가 아니다
                //    //Camera.main이기 때문에 카메라 기준으로 생성된다
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                ////동
                //case 1:
                //    xPosition = Random.Range((Screen.width / 2) + m_termPosition * 3, Screen.width);
                //    yPosition = Random.Range(0, Screen.height);
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                ////남
                //case 2:
                //    xPosition = Random.Range(0, Screen.width);
                //    yPosition = Random.Range(0, (Screen.height / 2) - m_termPosition * 3);
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                ////서
                //case 3:
                //    xPosition = Random.Range(0, (Screen.width/2) * 3 - m_termPosition);
                //    yPosition = Random.Range(0, Screen.height);
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                //북
                case 0:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height + (m_termPosition * 2), Screen.height + (m_termPosition * 3));
                    //ScreenToWorldPoint에 원하는 위치의 z좌표를 넣지 않고 Instantiate때 넣으면 객체가 생성되는 높이가
                    //엉망이 된다
                    //ScreenToWorldPoint에서 WorldPoint는 단순한 유니티 Inspector 창의 position x,y,z가 아니다
                    //Camera.main이기 때문에 카메라 기준으로 생성된다
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //동
                case 1:
                    xPosition = Random.Range(Screen.width + m_termPosition, (Screen.width + m_termPosition * 2));
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //남
                case 2:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-(m_termPosition * 2), -m_termPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //서
                case 3:
                    xPosition = Random.Range(-(m_termPosition * 2), -m_termPosition);
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
            }
        }

        yield return new WaitForSeconds(2.0f);
    }
}
