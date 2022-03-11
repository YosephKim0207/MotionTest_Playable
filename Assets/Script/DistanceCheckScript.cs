using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheckScript : MonoBehaviour
{
    public List<GameObject> nearEnemyList = new List<GameObject>();
    public GameObject enemyObject;
    GameObject child;
    CapsuleCollider capsuleCollider;

    public float m_enemyDetectRange = 0.0f;
    private void OnTriggerEnter(Collider enemyIn)
    {
        if (enemyIn.tag == "Enemy")
        {
            nearEnemyList.Add(enemyIn.gameObject);
        }
    }
    private void OnTriggerExit(Collider enemyOut)
    {
        nearEnemyList.Remove(enemyOut.gameObject);
    }

    private void Start()
    {
        child = transform.Find("Trigger").gameObject;
        capsuleCollider = child.GetComponent<CapsuleCollider>();
        capsuleCollider.radius = m_enemyDetectRange;
    }
}
