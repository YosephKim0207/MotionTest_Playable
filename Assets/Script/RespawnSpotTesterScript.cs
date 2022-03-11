using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpotTesterScript : MonoBehaviour
{
    public GameObject m_enemyPrefab;
    public GameObject m_groundPrefab;
    public int m_enemyNum = 20;

    //termPosition�� enemy�� ���ΰ��� �ִ� �߾��� ������ �ܰ��������� respawn�ǰ� �ϱ� ���� ����ũ��
    private int m_termPosition = 400;

    //�깮â�� ����� termPosition test
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
            Debug.Log("������");
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
            //ȭ�� �ۿ��� ��ü �����ǰ� �ϱ�
            //�ػ󵵰� �޶����� ���� ��ġ���� �������ǵ��� Screen��ǥ Ȱ��(ScreenToWorldPoint)
            switch (Random.Range(0, 4))
            {
                ////��
                //case 0:
                //    xPosition = Random.Range(0, Screen.width);
                //    yPosition = Random.Range((Screen.height/2) + m_termPosition * 3, Screen.height);
                //    //ScreenToWorldPoint�� ���ϴ� ��ġ�� z��ǥ�� ���� �ʰ� Instantiate�� ������ ��ü�� �����Ǵ� ���̰�
                //    //������ �ȴ�
                //    //ScreenToWorldPoint���� WorldPoint�� �ܼ��� ����Ƽ Inspector â�� position x,y,z�� �ƴϴ�
                //    //Camera.main�̱� ������ ī�޶� �������� �����ȴ�
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                ////��
                //case 1:
                //    xPosition = Random.Range((Screen.width / 2) + m_termPosition * 3, Screen.width);
                //    yPosition = Random.Range(0, Screen.height);
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                ////��
                //case 2:
                //    xPosition = Random.Range(0, Screen.width);
                //    yPosition = Random.Range(0, (Screen.height / 2) - m_termPosition * 3);
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                ////��
                //case 3:
                //    xPosition = Random.Range(0, (Screen.width/2) * 3 - m_termPosition);
                //    yPosition = Random.Range(0, Screen.height);
                //    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                //    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                //    break;
                //��
                case 0:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height + (m_termPosition * 2), Screen.height + (m_termPosition * 3));
                    //ScreenToWorldPoint�� ���ϴ� ��ġ�� z��ǥ�� ���� �ʰ� Instantiate�� ������ ��ü�� �����Ǵ� ���̰�
                    //������ �ȴ�
                    //ScreenToWorldPoint���� WorldPoint�� �ܼ��� ����Ƽ Inspector â�� position x,y,z�� �ƴϴ�
                    //Camera.main�̱� ������ ī�޶� �������� �����ȴ�
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //��
                case 1:
                    xPosition = Random.Range(Screen.width + m_termPosition, (Screen.width + m_termPosition * 2));
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //��
                case 2:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-(m_termPosition * 2), -m_termPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //��
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
