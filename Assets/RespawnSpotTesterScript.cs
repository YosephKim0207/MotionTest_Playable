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
            //ȭ�� �ۿ��� ��ü �����ǰ� �ϱ�
            //�ػ󵵰� �޶����� ���� ��ġ���� �������ǵ��� Screen��ǥ Ȱ��(ScreenToWorldPoint)
            switch (Random.Range(0, 4))
            {
                //��
                case 0:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(Screen.height + (termPosition * 2), Screen.height + (termPosition * 3));
                    //ScreenToWorldPoint�� ���ϴ� ��ġ�� z��ǥ�� ���� �ʰ� Instantiate�� ������ ��ü�� �����Ǵ� ���̰�
                    //������ �ȴ�
                    //ScreenToWorldPoint���� WorldPoint�� �ܼ��� ����Ƽ Inspector â�� position x,y,z�� �ƴϴ�
                    //Camera.main�̱� ������ ī�޶� �������� �����ȴ�
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //��
                case 1:
                    xPosition = Random.Range(Screen.width + termPosition, (Screen.width + termPosition * 2));
                    yPosition = Random.Range(0, Screen.height);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //��
                case 2:
                    xPosition = Random.Range(0, Screen.width);
                    yPosition = Random.Range(-(termPosition * 2), -termPosition);
                    spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, groundPosition.z));
                    Instantiate(m_enemyPrefab, new Vector3(spawnPosition.x, 0.0f, spawnPosition.z), Quaternion.identity);
                    break;
                //��
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
