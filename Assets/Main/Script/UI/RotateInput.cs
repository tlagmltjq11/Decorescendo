using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateInput : MonoBehaviour
{
    public Text m_text;
    FurnitureController m_fur;
    public InputField m_gameObject;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ValueChange()
    {
        m_fur = FurnitureManager.Instance.GetChosen();
        m_fur.RotateByInput(float.Parse(m_text.text.ToString()));

        m_gameObject.text = string.Empty;    
    }
}
