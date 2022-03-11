using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchToWolfLow : MonoBehaviour
{
    public float m_switchTime = 0.0f;
    float timeCheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCheck += Time.deltaTime;
        Debug.Log(timeCheck);

        if (m_switchTime < timeCheck)
        {
            SceneManager.LoadScene("Scenes/WolfAttack_LowAngle");
        }
    }
}
