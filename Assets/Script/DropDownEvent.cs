using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownEvent : MonoBehaviour
{
    [SerializeField]
    GameObject m_door;

    [SerializeField]
    GameObject m_bed;

    [SerializeField]
    GameObject m_chair;

    int choice;

    public void Handler(int val)
    {
        choice = val;
    }

    public GameObject GetFurniture()
    {
        Debug.Log(choice);
        switch(choice)
        {
            case 0:
                return m_door.gameObject;
                break;

            case 1:
                return m_bed.gameObject;
                break;

            case 2:
                return m_chair.gameObject;
                break;

            default:
                return null;
                break;
        }
    }

}
