using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //private Transform cameraTransform;
    private Movement3D movement3D;

    private void Awake()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        movement3D = GetComponent<Movement3D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //movement3D.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        //movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));
        movement3D.MoveTo(new Vector3(x, 0, z));
        movement3D.PlayerRotate(x, z);

    }
}
