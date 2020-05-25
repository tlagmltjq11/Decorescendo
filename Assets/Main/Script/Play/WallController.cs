using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public bool m_isChosen = false;
    MeshRenderer m_meshRen;

    public void SetMaterial(Material m)
    {
        m_meshRen.material = m;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        m_meshRen = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
