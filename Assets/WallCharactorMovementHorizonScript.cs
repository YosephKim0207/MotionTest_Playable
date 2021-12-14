using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCharactorMovementHorizonScript : MonoBehaviour
{
    //���� ������01 : �ϵ��� ���� ������ ������ �ݽð�� ȸ��(�ð���� ȸ���� �� ����)
    //�ӽ��ذ�å : �� ū ��η� ȸ���ϴ� case�� �߷��� �ִܰ�η� �ܰ��� ȸ���ϵ��� ���ǹ��� ����

    //���� ������02 : ���� �������� �ӵ��� �¿� ������ �ӵ��� 1/2 ������
    //�ذ�å : ���� �Ƹ��� �ذ�?

    //[SerializeField]
    //private Transform m_target;
    [SerializeField]
    private float m_moveSpeed = 5.0f;
    private Vector3 moveDirection;

    private CharacterController characterController;

    private float rotateAngle = 90.0f;
    private float rotateHalfAngle = 45.0f;
    private float speed = 3.0f;

    //x��� = ������, x���� = ���� & z��� = ��, z���� = �Ʒ�
    IEnumerator IPlayerRotate(float directionX)
    {
        //����
        if (directionX > 0)
        {
            Vector3 to = new Vector3(0.0f, rotateAngle, 0.0f);
            this.transform.eulerAngles = Vector3.Lerp(this.transform.rotation.eulerAngles, to, Time.deltaTime * speed);
        }

        //����
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
