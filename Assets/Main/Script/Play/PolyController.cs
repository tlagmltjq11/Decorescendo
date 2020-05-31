using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolyController : MonoBehaviour
{
    BoxCollider m_bc;
    bool m_wallExist = false;
    public bool m_isChosen = false;
    public List<Vector2> m_vectList;
    MeshRenderer m_meshRen;
    
    public void SetMaterial(Material m)
    {
        m_meshRen.material = m;   
    }

    public void SetVect(List<Vector2> list)
    {
        m_vectList = new List<Vector2>(list);
    }

    public List<Vector2> GetVect()
    {
        return m_vectList;
    }

    public void CreateFloor()
    {
        gameObject.transform.parent = GameObject.Find("Polys").transform;
        gameObject.layer = 9;
        gameObject.tag = "Floor";

        var vertices2D = m_vectList.ToArray<Vector2>();
        var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => new Vector3(v.x, 0.01f, v.y));
        var triangulator = new Triangulator(vertices2D);

        var indices = triangulator.Triangulate();

        // Generate a color for each vertex
        var colors = Enumerable.Range(0, vertices3D.Length)
            .Select(i => Random.ColorHSV())
            .ToArray();

        // Create the mesh
        var mesh = new Mesh
        {
            vertices = vertices3D,
            triangles = indices,
            colors = colors
        };

        mesh.SetUVs(0, vertices2D);

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Set up game object with mesh;
        m_meshRen = this.gameObject.AddComponent<MeshRenderer>();
        //m_meshRen.material = new Material(Shader.Find("DoubleSided"));

        var filter = this.gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;

        BoxCollider bc = this.gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = true;
    }

    void IsWallExist()
    {
        m_wallExist = false;

        Collider[] hitColliders = Physics.OverlapBox(
            m_bc.center,
            m_bc.size / 2);

        foreach (Collider c in hitColliders)
        {
            if (c.tag.Equals("Wall"))
            {
                m_wallExist = true;
            }
        }

        if (m_wallExist == false)
        {
            PolyWallManager.Instance.RemovePoly(this);
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        m_meshRen = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        IsWallExist();
    }
}
