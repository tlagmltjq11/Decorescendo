using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PolyWallManager : SingletonMonoBehaviour<PolyWallManager>
{
    Ray m_ray;
    RaycastHit m_rayHit;
    public bool m_select = false;

    [SerializeField]
    List<PolyController> m_polyList = new List<PolyController>();
    [SerializeField]
    List<WallController> m_wallList = new List<WallController>();

    [SerializeField]
    GameObject m_FloorMat;
    [SerializeField]
    GameObject m_WallMat;

    public void EraseAllPoly()
    {
        RemoveAllPoly();

        Transform[] childs;
        childs = GameObject.Find("Polys").GetComponentsInChildren<Transform>(true);

        if (childs.Length != 0)
        {

            foreach (var iter in childs)
            {
                if (iter != GameObject.Find("Polys").transform)
                {
                    Destroy(iter.gameObject);
                }
            }
        }
    }

    public void SelectFloorMat()
    {
        var texture = EventSystem.current.currentSelectedGameObject.GetComponent<RawImage>().texture;
        var material = Resources.Load("Materials/" + texture.name) as Material;

        var poly = GetChosenPoly();
        poly.SetMaterial(material);
        poly.m_isChosen = false;
        m_select = true;
    }

    public void SelectWallMat()
    {
        var texture = EventSystem.current.currentSelectedGameObject.GetComponent<RawImage>().texture;
        var material = Resources.Load("Materials/" + texture.name) as Material;
        var wall = GetChosenWall();
        wall.SetMaterial(material);
        wall.m_isChosen = false;
        m_select = true;
    }

    public PolyController GetChosenPoly()
    {
        for(int i=0; i< m_polyList.Count; i++)
        {
            if(m_polyList[i].m_isChosen)
            {
                return m_polyList[i];
            }
        }

        return null;
    }

    public WallController GetChosenWall()
    {
        for (int i = 0; i < m_wallList.Count; i++)
        {
            if (m_wallList[i].m_isChosen)
            {
                return m_wallList[i];
            }
        }

        return null;
    }

    public void AddPoly(PolyController poly)
    {
        m_polyList.Add(poly);
    }

    public void RemovePoly(PolyController poly)
    {
        if(m_polyList.Remove(poly))
        {
            m_polyList.Remove(poly);
        }
    }

    public void RemoveAllPoly()
    {
        m_polyList.Clear();
    }


    public void AddWall(WallController wall)
    {
        m_wallList.Add(wall);
    }

    public void RemoveWall(WallController wall)
    {
        m_wallList.Remove(wall);
    }

    public void RemoveAllWall()
    {
        m_wallList.Clear();
    }

    IEnumerator Choice()
    {
        while (true)
        {
            if (m_select == false)
            {
                yield return null;
            }
            else
            {
                m_select = false;
                m_FloorMat.SetActive(false);
                m_WallMat.SetActive(false);
                ButtonEvent.Instance.ButtonsEnable();
                Camera.main.GetComponent<CameraController>().enabled = true;
                yield break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_FloorMat.SetActive(false);
        m_WallMat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetKey(KeyCode.T) && Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(m_ray, out m_rayHit, 1000f, 1 << LayerMask.NameToLayer("Floor") | 1 << LayerMask.NameToLayer("Wall")))
            {
                if(LayerMask.LayerToName(m_rayHit.collider.gameObject.layer).Equals("Floor"))
                {
                    var obj = m_rayHit.collider.gameObject.GetComponent<PolyController>();

                    for (int i = 0; i < m_polyList.Count; i++)
                    {
                        if (m_polyList[i].m_isChosen)
                        {
                            m_polyList[i].m_isChosen = false;
                        }
                    }

                    obj.m_isChosen = true;
                    m_FloorMat.SetActive(true);
                    Camera.main.GetComponent<CameraController>().enabled = false;
                    ButtonEvent.Instance.ButtonsDisable();
                    StartCoroutine("Choice");
                }
                else if(LayerMask.LayerToName(m_rayHit.collider.gameObject.layer).Equals("Wall"))
                {
                    var obj = m_rayHit.collider.gameObject.GetComponent<WallController>();

                    for (int i = 0; i < m_wallList.Count; i++)
                    {
                        if (m_wallList[i].m_isChosen)
                        {
                            m_wallList[i].m_isChosen = false;
                        }
                    }

                    obj.m_isChosen = true;
                    m_WallMat.SetActive(true);
                    Camera.main.GetComponent<CameraController>().enabled = false;
                    ButtonEvent.Instance.ButtonsDisable();
                    StartCoroutine("Choice");
                }
            }
        }
    }
}
