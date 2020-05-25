using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FurnitureMoveUIController : MonoBehaviour
{
    CameraController m_camera;
    bool m_isDrag = false;

    Ray m_ray; //광선을 나타내는 변수
    RaycastHit m_rayHit; //충돌을 나타내는 변수

    public void PD()
    {
        m_isDrag = true;
        m_camera.enabled = false;
        Debug.Log(m_isDrag);
    }

    public void PU()
    {
        m_isDrag = false;
        m_camera.enabled = true;
        Debug.Log(m_isDrag);
    }

    public void Init()
    {
        m_isDrag = false;
        m_camera.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main.GetComponent<CameraController>();
        m_isDrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDrag)
        {
            m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //레이를 쏘는 메소드 m_ray의 위치부터, 1키로 정도 광선을 쏠거고 hit된 결과는 m_rayHit에 담아서줘라 
            //RayCast는 반환값이 불린이다.
            if (Physics.Raycast(m_ray, out m_rayHit, 1000f, 1 << LayerMask.NameToLayer("Ground")))
            {
                //Debug.DrawRay(m_ray.origin, m_ray.direction * m_rayHit.distance, Color.red, 5f);
                gameObject.transform.parent.position = m_rayHit.point;
            }
        }
    }
}