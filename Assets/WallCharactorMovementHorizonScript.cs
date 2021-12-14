using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCharactorMovementHorizonScript : MonoBehaviour
{
    //현재 문제점01 : 북동쪽 방향 누르면 무조건 반시계로 회전(시계방향 회전이 더 빨라도)
    //임시해결책 : 더 큰 경로로 회전하는 case를 추려서 최단경로로 단계적 회전하도록 조건문을 삽입

    //현재 문제점02 : 상하 움직임의 속도가 좌우 움직임 속도의 1/2 수준임
    //해결책 : 현재 아마도 해결?

    //[SerializeField]
    //private Transform m_target;
    [SerializeField]
    private float m_moveSpeed = 5.0f;
    private Vector3 moveDirection;

    private CharacterController characterController;

    private float rotateAngle = 90.0f;
    private float rotateHalfAngle = 45.0f;
    private float speed = 3.0f;

    //x양수 = 오른쪽, x음수 = 왼쪽 & z양수 = 위, z음수 = 아래
    IEnumerator IPlayerRotate(float directionX)
    {
        //동쪽
        if (directionX > 0)
        {
            Vector3 to = new Vector3(0.0f, rotateAngle, 0.0f);
            this.transform.eulerAngles = Vector3.Lerp(this.transform.rotation.eulerAngles, to, Time.deltaTime * speed);
        }

        //서쪽
        else if (directionX < 0)
        {
            Vector3 to = new Vector3(0.0f, rotateAngle * 3, 0.0f);
            this.transform.eulerAngles = Vector3.Lerp(this.transform.rotation.eulerAngles, to, Time.deltaTime * speed);
        }

        yield return null;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(moveDirection * m_moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    public void PlayerRotate(float directionX, float directionZ)
    {
        StartCoroutine(IPlayerRotate(directionX));
    }
}
