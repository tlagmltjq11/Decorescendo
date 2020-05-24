using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : SingletonMonoBehaviour<ButtonEvent>
{
    [SerializeField]
    GameObject m_drawHome;

    [SerializeField]
    GameObject m_cameraController;

    [SerializeField]
    GameObject m_canvas;

    [SerializeField]
    GameObject m_plane;

    DrawHome m_drawHomeScript;

    private void Start()
    {
        m_drawHomeScript = m_drawHome.GetComponent<DrawHome>();
    }

    public void ThreeDButtonClick()
    {
        m_drawHomeScript.CreateFloor();

        Camera.main.orthographic = false;
        m_drawHomeScript.enabled = false;
        m_plane.GetComponent<Renderer>().material.SetFloat("_LineSize", 0.1f);


        //3D버튼을 누를 시 벽의 두께를 0.1f로 설정해주는 코드
        Transform[] childs;
        childs = GameObject.Find("Walls").GetComponentsInChildren<Transform>(true);

        foreach (var iter in childs)
        {
            if (iter != GameObject.Find("Walls").transform)
            {
                iter.localScale = new Vector3(iter.localScale.x, iter.localScale.y, 0.1f);
            }
        }

    }

    public void CreateRoomClick()
    {
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        Camera.main.orthographic = true;
        m_drawHomeScript.enabled = true;
        ButtonsDisable();
    }

    public void ButtonsDisable()
    {
        Button[] buttons;
        buttons = m_canvas.GetComponentsInChildren<Button>(true);

        foreach(Button obj in buttons)
        {
            if(obj.gameObject.name != "RawImage")
            {
                obj.interactable = false;
            }
        }
    }

    public void ButtonsEnable()
    {
        Button[] buttons;
        buttons = m_canvas.GetComponentsInChildren<Button>(true);
        foreach (Button obj in buttons)
        {
            obj.interactable = true;
        }
    }
}
