using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ʒ� ������Ʈ�� ���� ������Ʈ�� �ڵ� �߰�
[RequireComponent(typeof(Camera))]

//https://docs.unity3d.com/kr/530/Manual/DollyZoom.html
//https://www.youtube.com/watch?v=epvviNA2cFA
public class DollyZoomScript : MonoBehaviour
{
    public Transform m_target;
    public float m_dollySpeed = 3.0f;
    private Camera camera;
    private float initialFrustumHeight;
    private bool dollyZoomEnabled = true;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        StopDollyZoom();
        Debug.Log(dollyZoomEnabled);
        if (dollyZoomEnabled)
        {
            //ȭ��ǥ ��/�Ͽ� ���� ī�޶� ���� ��/�ƿ�
            transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * m_dollySpeed);
        }
        
        float currentDistance = Vector3.Distance(transform.position, m_target.position);
        camera.fieldOfView = ComputeFieldOfView(initialFrustumHeight, currentDistance);
    }

    private void Initialize()
    {
        camera = GetComponent<Camera>();
        //True/False Ȯ�ο� ���. camera ������Ʈ�� ���ڷ� ������ �� False�� �α� ���
        Debug.Assert(camera != null);

        //ī�޶�� �ǻ�ü ������ �Ÿ� ���
        float distanceFromTarget = Vector3.Distance(transform.position, m_target.position);
        initialFrustumHeight = ComputeFrustumHeight(distanceFromTarget);
    }

    //ī�޶�� �ǻ�ü ������ �Ÿ� ��ȭ�� ���� �޶����� ȭ�� �� �ǻ�ü�� ���̸� ���
    private float ComputeFrustumHeight(float distance)
    {
        return (2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    //ȭ��(ī�޶�� ���ߴ� ȭ��) ũ�� ���
    private float ComputeFieldOfView(float height, float distance)
    {
        return (2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg);
    }

    private void StartDollyZoom()
    {
        dollyZoomEnabled = true;
    }

    private void StopDollyZoom()
    {
        if(Vector3.Distance(transform.position, m_target.position) <= 1.1f)
        {
            dollyZoomEnabled = false;
        }
    }
}
