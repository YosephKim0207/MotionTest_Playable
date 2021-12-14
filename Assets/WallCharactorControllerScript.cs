using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCharactorControllerScript : MonoBehaviour
{
    private WallCharactorMovementHorizonScript WallCharactorMovementHorizonScript;

    private void Awake()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        WallCharactorMovementHorizonScript = GetComponent<WallCharactorMovementHorizonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");


        WallCharactorMovementHorizonScript.MoveTo(new Vector3(x, 0, 0));
        WallCharactorMovementHorizonScript.PlayerRotate(x, 0);

    }
}
