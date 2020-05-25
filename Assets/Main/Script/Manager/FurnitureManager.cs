using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class FurnitureManager : SingletonMonoBehaviour<FurnitureManager>
{
    List<FurnitureController> m_furniutures = new List<FurnitureController>();

    [SerializeField]
    GameObject UIEvent;
    GameObject removefurbutton;
    GameObject removefur;
    Ray m_ray;
    RaycastHit m_rayHit;

    public void RemoveAll()
    {
        m_furniutures.Clear();
    }

    public void AddFurniture(FurnitureController fur)
    {
        m_furniutures.Add(fur);
    }

    public void RemoveFurniture(FurnitureController fur)
    {
        m_furniutures.Remove(fur);
        Destroy(fur.gameObject);
    }
    public void Chosen(FurnitureController fur, int LR)
    {
        for (int i = 0; i < m_furniutures.Count; i++)
        {
            if (m_furniutures[i].m_isChosen)
            {
                m_furniutures[i].m_isChosen = false;
                m_furniutures[i].OffUI();
            }
        }

        fur.m_isChosen = true;
        fur.OnUI(LR);
    }

    // Start is called before the first frame update
    void Start()
    {
        removefurbutton = UIEvent.GetComponent<ButtonEvent>().CreateRemoveFurButton(delegate { RemovefurnitureButtonClicked(removefur.GetComponent<FurnitureController>()); });
        removefurbutton.SetActive(false);
    }

    void RemovefurnitureButtonClicked(FurnitureController fur)
    {
        RemoveFurniture(fur);
        removefurbutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(m_ray, out m_rayHit, 1000f, 1 << LayerMask.NameToLayer("Furniture")))
            {
                var fur = m_rayHit.transform.gameObject.GetComponent<FurnitureController>();
                Chosen(fur, 0);


                removefur = fur.gameObject;
                removefurbutton.SetActive(true);

            }
            else
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    removefurbutton.SetActive(false);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(m_ray, out m_rayHit, 1000f, 1 << LayerMask.NameToLayer("Furniture")))
            {
                var fur = m_rayHit.transform.gameObject.GetComponent<FurnitureController>();
                Chosen(fur, 1);

                removefur = fur.gameObject;
                removefurbutton.SetActive(true);
            }
        }

    }

}

