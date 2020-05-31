using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    private GameObject removefurbutton;

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
            if (obj.gameObject.name != "Remove_ Furniture")
            {
                obj.interactable = true;
            }
        }
    }

    public GameObject CreateRemoveFurButton(UnityAction eventlistener)
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            var es = new GameObject("EventSystem", typeof(EventSystem));
            es.AddComponent<StandaloneInputModule>();
        }

        removefurbutton = new GameObject("RemoveFurButton");

        var canvasObject = new GameObject("RemoveFurButtonCanvas");
        var canvas = canvasObject.AddComponent<Canvas>();
        canvasObject.AddComponent<GraphicRaycaster>();
        canvasObject.layer = 5;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        var image = removefurbutton.AddComponent<Image>();
        image.transform.SetParent(canvas.transform);
        image.rectTransform.sizeDelta = new Vector2(180, 50);
        image.rectTransform.anchoredPosition = new Vector3(205, 200, 0);
        image.color = new Color(1f, .3f, .3f, .5f);


        var button = removefurbutton.AddComponent<Button>();
        button.targetGraphic = image;
        button.onClick.AddListener(eventlistener);

        var textObject = new GameObject("Text");
        textObject.transform.parent = removefurbutton.transform;
        var text = textObject.AddComponent<Text>();
        text.rectTransform.sizeDelta = Vector2.zero;
        text.rectTransform.anchorMin = Vector2.zero;
        text.rectTransform.anchorMax = Vector2.one;
        text.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
        text.text = "Remove Furniture!";
        text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
        text.fontSize = 20;
        text.color = Color.white;
        text.alignment = TextAnchor.MiddleCenter;

        removefurbutton.layer = 5;

        return removefurbutton;

    }
}
