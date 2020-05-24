using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : SingletonMonoBehaviour<FurnitureManager>
{

    List<FurnituerController> m_furniutures = new List<FurnituerController>();

    public void RemoveAll()
    {
        m_furniutures.Clear();
    }

    public void AddFurniture(FurnituerController fur)
    {
        m_furniutures.Add(fur);
    }

    public void RemoveFurniture(FurnituerController fur)
    {
        m_furniutures.Remove(fur);
    }

    /*
    public void Chosen(FurnituerController fur)
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
        fur.OnUI();
    }
    */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
}
