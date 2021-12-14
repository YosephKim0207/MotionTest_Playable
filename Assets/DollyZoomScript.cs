using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아래 컴포넌트를 게임 오브젝트에 자동 추가
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
            //화살표 상/하에 따라 카메라 돌리 인/아웃
            transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * m_dollySpeed);
        }
        
        float currentDistance = Vector3.Distance(transform.position, m_target.position);
        camera.fieldOfView = ComputeFieldOfView(initialFrustumHeight, currentDistance);
    }

    private void Initialize()
    {
        camera = GetComponent<Camera>();
        //True/False 확인에 사용. camera 오브젝트를 인자로 전달할 때 False면 로그 출력
        Debug.Assert(camera != null);

        //카메라와 피사체 사이의 거리 계산
        float distanceFromTarget = Vector3.Distance(transform.position, m_target.position);
        initialFrustumHeight = ComputeFrustumHeight(distanceFromTarget);
    }

    //카메라와 피사체 사이의 거리 변화에 따라 달라지는 화면 상 피사체의 높이를 계산
    private float ComputeFrustumHeight(float distance)
    {
        return (2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    //화각(카메라로 비추는 화면) 크기 계산
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
