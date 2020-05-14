using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolyController : MonoBehaviour
{
    BoxCollider m_bc;
    bool m_wallExist = false;
    string m_name;
    List<Vector2> m_vectList = new List<Vector2>();

    public void SetPoly(List<Vector2> list, string name)
    {
        m_vectList = list;
        m_name = name;
    }

    public List<Vector2> GetVect()
    {
        return m_vectList;
    }

    /*
    void CreateFloor()
    {
        GameObject poly = new GameObject(m_name);
        var vertices2D = m_vectList.ToArray<Vector2>();
        //var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);
        var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => new Vector3(v.x, 0.01f, v.y));
        // Use the triangulator to get indices for creating triangles
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

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Set up game object with mesh;
        var meshRenderer = poly.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("DoubleSided"));

        var filter = poly.AddComponent<MeshFilter>();
        filter.mesh = mesh;

        BoxCollider bc = poly.AddComponent<BoxCollider>();
        bc.isTrigger = true;
        PolyController pc = poly.AddComponent<PolyController>();
        pc.SetVect(m_vectList);

        m_polyCnt++;
        m_vectList.Clear();
    }
    */


    // Start is called before the first frame update
    void Start()
    {
        m_bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        m_wallExist = false;

        Collider[] hitColliders = Physics.OverlapBox(
            m_bc.center,
            m_bc.size / 2);

        foreach(Collider c in hitColliders)
        {
            if(c.tag.Equals("Wall"))
            {
                m_wallExist = true;
            }
        }

        if(m_wallExist == false)
        {
            Destroy(this.gameObject);
        }
    }
}
