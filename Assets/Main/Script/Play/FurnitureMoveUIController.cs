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
    Ray m_ray2; //광선을 나타내는 변수
    RaycastHit m_rayHit2; //충돌을 나타내는 변수
    float m_radius;
    BoxCollider m_parentCol;
    Vector3 m_curPos;

    public void PD()
    {
        m_isDrag = true;
        m_camera.enabled = false;
    }

    public void PU()
    {
        m_isDrag = false;
        m_camera.enabled = true;
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
        m_parentCol = gameObject.transform.parent.GetComponent<BoxCollider>();
        m_radius = m_parentCol.size.x >= m_parentCol.size.z ? ((m_parentCol.size.x / 2) + 0.6f) :  ((m_parentCol.size.z / 2) + 0.6f);
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
                var collidercenterpos = gameObject.transform.parent.GetComponent<BoxCollider>().center;
                var colliderglobalpos = gameObject.transform.parent.transform.TransformPoint(collidercenterpos);
                var furpos = gameObject.transform.parent.position;
                gameObject.transform.parent.position = new UnityEngine.Vector3(m_rayHit.point.x, m_rayHit.point.y, m_rayHit.point.z) - new UnityEngine.Vector3((colliderglobalpos - furpos).x, 0, (colliderglobalpos - furpos).z);
            }

            /*
            m_ray2 = new Ray(m_curPos, transform.parent.transform.forward);
            Debug.DrawRay(m_ray2.origin, m_ray2.direction, Color.red, 1000f);
            if(Physics.Raycast(m_ray2, out m_rayHit2, m_radius, 1 << LayerMask.NameToLayer("Wall")))
            {
                //transform.parent.transform += new Vector3(m_rayHit2.point.x, transform.parent.transform.position.y, m_rayHit2.point.z - m_parentCol.size.z
                  //  );
            }

            m_ray2 = new Ray(m_curPos, -transform.parent.transform.forward);
            Debug.DrawRay(m_ray2.origin, m_ray2.direction, Color.red, 1000f);
            if (Physics.Raycast(m_ray2, out m_rayHit2, m_radius, 1 << LayerMask.NameToLayer("Wall")))
            {

            }

            m_ray2 = new Ray(m_curPos, transform.parent.transform.right);
            Debug.DrawRay(m_ray2.origin, m_ray2.direction, Color.red, 1000f);
            if (Physics.Raycast(m_ray2, out m_rayHit2, m_radius, 1 << LayerMask.NameToLayer("Wall")))
            {

            }

            m_ray2 = new Ray(m_curPos, -transform.parent.transform.right);
            Debug.DrawRay(m_ray2.origin, m_ray2.direction, Color.red, 1000f);
            if (Physics.Raycast(m_ray2, out m_rayHit2, m_radius, 1 << LayerMask.NameToLayer("Wall")))
            {

            }
            */

        }
    }
}