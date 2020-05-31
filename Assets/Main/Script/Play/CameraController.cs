using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    Camera m_cameraComponent;
    bool m_isDrag = false;

    public bool IsDrag()
    {
        return m_isDrag;
    }

    private void CameraControl()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            transform.Translate(0, 0, -0.8f);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (transform.position.y > 1)
            {
                transform.Translate(0, 0, 0.8f);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    transform.Translate(0.7f, 0, 0);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    transform.Translate(-0.7f, 0, 0);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    transform.Translate(0, 0.7f, 0);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                if (transform.position.y > 0.8)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                        transform.Translate(0, -0.7f, 0);
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.Rotate(0, 2.5f, 0, Space.World);
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.Rotate(0, -2.5f, 0, Space.World);
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                transform.Rotate(-2.5f, 0, 0, Space.Self);
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.Rotate(2.5f, 0, 0, Space.Self);
            }
        }
    }

    private void PlaneCameraControl()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (m_cameraComponent.orthographicSize < 15f)
            {
                m_cameraComponent.orthographicSize += 2f;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (m_cameraComponent.orthographicSize > 5.71f)
            {
                m_cameraComponent.orthographicSize -= 2f;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    transform.Translate(0.7f, 0, 0);
                    m_isDrag = true;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    transform.Translate(-0.7f, 0, 0);
                    m_isDrag = true;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    transform.Translate(0, 0.7f, 0);
                    m_isDrag = true;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                if (transform.position.y > 0.8)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        transform.Translate(0, -0.7f, 0);
                        m_isDrag = true;
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            m_isDrag = false;
        }
    }


    private void Start()
    {
        m_cameraComponent = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.orthographic == true)
        {
            PlaneCameraControl();
        }
        else
        {
            CameraControl();
        }
    }
}
