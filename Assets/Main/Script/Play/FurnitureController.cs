using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{

    Canvas[] m_canvas;
    public bool m_isChosen;

    GameObject removefurbutton;

    Ray m_ray; //광선을 나타내는 변수
    RaycastHit m_rayHit; //충돌을 나타내는 변수

    public void RotateByInput(float angle)
    {
        BoxCollider box = gameObject.transform.GetComponent<BoxCollider>();
        Vector3 pivot = gameObject.transform.transform.TransformPoint(box.center);

        gameObject.transform.RotateAround(pivot, Vector3.up, angle);
    }

    public void OnUI(int LR)
    {
        if (LR == 0) //좌클릭시;
        {
            for (int i = 0; i < m_canvas.Length; i++)
            {
                string name = m_canvas[i].gameObject.name;

                if (name.Length > 7)
                {
                    if (name.Substring(name.Length - 7).Equals("(Clone)"))
                    {
                        name = name.Substring(0, name.Length - 7);
                    }

                }
                
                if (name.Equals("FurnitureMoveUI"))
                {
                    m_canvas[i].gameObject.SetActive(true);
                }
            }
        }
        else if (LR == 1)    //우클릭시
        {
            for (int i = 0; i < m_canvas.Length; i++)
            {
                string name = m_canvas[i].gameObject.name;

                if (name.Length > 7)
                {
                    if (name.Substring(name.Length - 7).Equals("(Clone)"))
                    {
                        name = name.Substring(0, name.Length - 7);
                    }

                }

                if (name.Equals("FurnitureRotationUI"))
                {
                    m_canvas[i].gameObject.SetActive(true);
                }
            }
        }
    }

    public void OffUI()
    {
        m_canvas[0].GetComponentInChildren<Transform>().GetComponent<FurnitureMoveUIController>().Init();
        m_canvas[1].GetComponentInChildren<Transform>().GetComponent<FurnitureRotationUIController>().Init();

        for (int i = 0; i < m_canvas.Length; i++)
        {
            m_canvas[i].gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_isChosen = false;
        m_canvas = gameObject.GetComponentsInChildren<Canvas>();

        for (int i = 0; i < m_canvas.Length; i++)
        {
            var collider = gameObject.GetComponent<BoxCollider>();
            float posx = collider.center.x;
            float posy = collider.center.y + (collider.size.y / 2);
            float posz = collider.center.z;

            m_canvas[i].gameObject.SetActive(false);
            m_canvas[i].transform.localPosition = new Vector3(posx, posy, posz);
            m_canvas[i].transform.localRotation = gameObject.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FurnitureManager.Instance.AddFurniture(this);
        }
    }
}
