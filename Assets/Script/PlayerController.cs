using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement3D movement3D;
    private CharacterController charactercontroller;
    private bool isGround;



    private void Start()
    {
        movement3D = GetComponent<Movement3D>();
        charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement3D.MoveTo(new Vector3(x, 0, z));
        movement3D.PlayerRotate(x, z);

        //캐릭터 오브젝트가 공중에 뜬 경우 접지시킴
        if (!charactercontroller.isGrounded)
        {
            charactercontroller.Move(Vector3.down * Time.deltaTime);
        }
    }
}
