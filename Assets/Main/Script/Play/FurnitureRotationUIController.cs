using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FurnitureRotationUIController : MonoBehaviour
{
    [SerializeField]
    GameObject m_rotate;

    CameraController m_camera;
    bool m_isDrag = false;

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

    private void Awake()
    {
        m_camera = Camera.main.GetComponent<CameraController>();
        var obj = GameObject.Find("Canvas");
        var childObjects = obj.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < childObjects.Length; i++)
        {
            if (childObjects[i].name.Equals("InputField_Rotate"))
            {
                m_rotate = childObjects[i].gameObject;
                break;
            }
        }


    }

    private void OnEnable()
    {
        m_rotate.SetActive(true);
    }

    private void OnDisable()
    {
        if(m_rotate != null)
        {
            m_rotate.SetActive(false);
        }
    }

    void Start()
    {
        m_isDrag = false;
    }

    public void Init()
    {
        m_isDrag = false;
        m_camera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDrag)
        {
            BoxCollider box = gameObject.transform.parent.GetComponent<BoxCollider>();
            Vector3 pivot = gameObject.transform.parent.transform.TransformPoint(box.center);

            if (Input.GetAxis("Mouse X") > 0)
            {
                gameObject.transform.parent.RotateAround(pivot, Vector3.up, 2);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                gameObject.transform.parent.RotateAround(pivot, Vector3.up, -2);
            }
        }

    }

}