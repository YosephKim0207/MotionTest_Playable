using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PptStartScript : MonoBehaviour
{
    public GameObject m_enemiesObj;

    private TrackingCharacterScript[] trackingCharacterScripts;

    // Update is called once per frame
    void Update()
    {
        trackingCharacterScripts = m_enemiesObj.GetComponentsInChildren<TrackingCharacterScript>();

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (TrackingCharacterScript tracking in trackingCharacterScripts)
            {
                tracking.enabled = !tracking.enabled;
            }
        }
        
    }
}
