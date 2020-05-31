using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLevelCameraController : MonoBehaviour
{
    [SerializeField]
    GameObject m_EyeLevelCamera;
    [SerializeField]
    GameObject m_ExitLabel;

    [SerializeField]
    GameObject m_canvasMain;
    [SerializeField]
    GameObject m_mainCamera;
    [SerializeField]
    GameObject m_polywallManager;
    [SerializeField]
    GameObject m_drawHomeManager;
    [SerializeField]
    GameObject m_furnitureManager;

    Vector3 m_dir;

    public void EyeLevelViewOnClick()
    {
        m_canvasMain.SetActive(false);
        m_mainCamera.SetActive(false);
        m_polywallManager.SetActive(false);
        m_drawHomeManager.SetActive(false);
        m_furnitureManager.SetActive(false);

        m_EyeLevelCamera.SetActive(true);
        m_ExitLabel.SetActive(true);

        m_EyeLevelCamera.transform.rotation = Quaternion.identity;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_EyeLevelCamera.SetActive(false);
        m_ExitLabel.SetActive(false);
    }

    void KeyProcess()
    {
        m_dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            m_dir = m_EyeLevelCamera.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_EyeLevelCamera.transform.Rotate(0, -3.5f, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_dir = -m_EyeLevelCamera.transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_EyeLevelCamera.transform.Rotate(0, 3.5f, 0, Space.World);
        }
    }

    void MouseProcess()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") > 0)
            { 
                m_EyeLevelCamera.transform.Rotate(-2f, 0, 0, Space.Self);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                m_EyeLevelCamera.transform.Rotate(2f, 0, 0, Space.Self);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyProcess();
        MouseProcess();

        if (Input.GetKey(KeyCode.Escape))
        {
            m_canvasMain.SetActive(true);
            m_mainCamera.SetActive(true);
            m_polywallManager.SetActive(true);
            m_drawHomeManager.SetActive(true);
            m_furnitureManager.SetActive(true);

            m_EyeLevelCamera.SetActive(false);
            m_ExitLabel.SetActive(false);
        }

        Vector3 pos = m_EyeLevelCamera.transform.position;
        pos += m_dir * 10f * Time.deltaTime;

        m_EyeLevelCamera.transform.position = new Vector3(pos.x, 1.3f, pos.z);
    }
}
