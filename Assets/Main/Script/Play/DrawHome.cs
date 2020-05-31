using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
public class DrawHome : MonoBehaviour
{
    #region field
    [SerializeField]
    GameObject m_wallPrefab;

    Ray m_ray; //광선을 나타내는 변수
    RaycastHit m_rayHit; //충돌을 나타내는 변수
    Vector3 m_pos;
    
    List<Vector2> m_vectList = new List<Vector2>();

    GameObject m_wallClone;
    public int m_wallCnt = 0;
    public int m_polyCnt = 0;

    bool m_isHorizon;
    bool m_isVertical;

    [SerializeField]
    GameObject m_UIevent;

    [SerializeField]
    Text m_lengthText;

    #endregion

    #region public methods

    public void EraseWall()
    {
        string name = "Wall" + m_wallCnt.ToString();
        var obj = GameObject.Find(name);

        if (obj != null)
        {

            var wallControllers = obj.GetComponentsInChildren<WallController>();

            for (int i = 0; i < wallControllers.Length; i++)
            {
                PolyWallManager.Instance.RemoveWall(wallControllers[i]);
            }

            Destroy(obj);

            if (m_wallCnt - 1 >= 0)
            {
                m_wallCnt--;
            }

            if (m_vectList.Count > 0)
            {
                if (m_vectList.Count == 2)
                {
                    m_vectList.Clear();
                }
                else
                {
                    m_vectList.RemoveAt(m_vectList.Count - 1);
                }
            }
        }
    }

    public void EraseAll()
    {
        Transform[] childs;
        childs = GameObject.Find("Walls").GetComponentsInChildren<Transform>(true);

        if (childs.Length != 0)
        {

            foreach (var iter in childs)
            {
                if (iter != GameObject.Find("Walls").transform)
                {
                    Destroy(iter.gameObject);
                }
            }

            m_wallCnt = 0;
            m_polyCnt = 0;
            m_vectList.Clear();

            PolyWallManager.Instance.RemoveAllWall();
            PolyWallManager.Instance.RemoveAllPoly();
        }
    }

    public void EraseAllFurnitures()
    {
        var furnitures = GameObject.FindGameObjectsWithTag("furniture");

        if (furnitures.Length != 0)
        {
            foreach (var iter in furnitures)
            {
                Destroy(iter.gameObject);
            }

            FurnitureManager.Instance.RemoveAll();
        }
    }

    public void CreateFloor()
    {
        if (m_vectList.Count != 0)
        {
            GameObject poly = new GameObject("Poly" + m_polyCnt);
            poly.tag = "Floor";
            poly.layer = 9;

            poly.transform.parent = GameObject.Find("Polys").transform;

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

            mesh.SetUVs(0, vertices2D);

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // Set up game object with mesh;
            var meshRenderer = poly.AddComponent<MeshRenderer>();
            meshRenderer.material = Resources.Load("Materials/DoubleSided") as Material;

            var filter = poly.AddComponent<MeshFilter>();
            filter.mesh = mesh;

            BoxCollider bc = poly.AddComponent<BoxCollider>();
            bc.isTrigger = true;
            PolyController pc = poly.AddComponent<PolyController>();
            pc.SetVect(m_vectList);

            m_polyCnt++;
            m_vectList.Clear();

            PolyWallManager.Instance.AddPoly(pc);
        }
    }

    #endregion

    #region methods

    private Vector3 GetTouchedPos()
    {
        //Ray의 시작점을 스크린 포인트로 설정해주어야 한다.
        //마우스의 좌표를 넘겨줌으로써, 레이를 쏠 시작좌표를 정하게 된다.
        m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //레이를 쏘는 메소드 m_ray의 위치부터, 1키로 정도 광선을 쏠거고 hit된 결과는 m_rayHit에 담아서줘라 
        //RayCast는 반환값이 불린이다.
        if (Physics.Raycast(m_ray, out m_rayHit, 1000f, 1 << LayerMask.NameToLayer("Ground")))
        {
            //Debug.DrawRay(m_ray.origin, m_ray.direction * m_rayHit.distance, Color.red, 5f);
            return m_rayHit.point;
        }
        else
        {
            //Debug.DrawRay(m_ray.origin, m_ray.direction * 1000f, Color.green, 5f);
            return new Vector3(0, 0, 0);
        }
    }
    
    float CalculateAngle(Vector3 from, Vector3 to)
    {
        // 두 벡터좌표간의 각도를 구해서 반환.

        Vector3 temp = to - from;

        if(temp.x == 0f)
        {
            return 0f;
        }
        else if(temp.z == 0f)
        {
            return 9999f;
        }
        else
        {
            return Quaternion.FromToRotation(Vector3.up, temp).eulerAngles.y;
        }    
    }

    IEnumerator EndPointCorutine(GameObject wall, Vector3 prevPos)
    {
        while (true)
        {
            if (Camera.main.GetComponent<CameraController>().IsDrag() != true)
            {
                m_pos = GetTouchedPos();
                m_isHorizon = false;
                m_isVertical = false;

                if (CalculateAngle(prevPos, m_pos) == 9999f || (CalculateAngle(prevPos, m_pos) < 3.5f && CalculateAngle(prevPos, m_pos) > 0.111f) || (CalculateAngle(prevPos, m_pos) > 356.5f && CalculateAngle(prevPos, m_pos) < 359.999f))
                {
                    m_pos = new Vector3(m_pos.x, m_pos.y, prevPos.z);
                    wall.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    m_isHorizon = true;
                }
                else if (CalculateAngle(prevPos, m_pos) == 0f || (CalculateAngle(prevPos, m_pos) > 86.5f && CalculateAngle(prevPos, m_pos) < 89.999f) || (CalculateAngle(prevPos, m_pos) < 273.5f && CalculateAngle(prevPos, m_pos) > 270.111f))
                {
                    m_pos = new Vector3(prevPos.x, m_pos.y, m_pos.z);
                    wall.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    m_isVertical = true;
                }
                else
                {
                    wall.transform.rotation = Quaternion.Euler(0f, CalculateAngle(prevPos, m_pos), 0f);
                }

                wall.transform.localScale = new Vector3(Vector3.Distance(prevPos, m_pos), 3, 0.3f);
                wall.transform.position = new Vector3((prevPos.x + m_pos.x) / 2f, 1.5f, (prevPos.z + m_pos.z) / 2f);

                m_lengthText.text = (Vector3.Distance(prevPos, m_pos)).ToString("N2") + "m";
            }
            yield return null;
        }
    }

    void DrawWall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                StopAllCoroutines();

                m_pos = GetTouchedPos();

                //만약 벽의 각도가 90도 혹은 180도라면 현재 찍은 좌표를 이전에 찍은 좌표에 벽의 길이만큼을 더해준 좌표로 지정한다.
                if (m_isHorizon)
                {
                    Vector3 prevPos = GameObject.Find("Wall" + m_wallCnt).transform.position;
                    float dir = m_pos.x - prevPos.x;
                    
                    if (dir > 0)
                    {   
                        //0.05f 를 더해주는것은 그냥 좌표 보정용
                        m_pos = new Vector3(prevPos.x + dir - 0.05f, 0f, prevPos.z);
                    }
                    else
                    {
                        m_pos = new Vector3(prevPos.x + dir + 0.05f, 0f, prevPos.z);
                    }
                }
                else if(m_isVertical)
                {
                    Vector3 prevPos = GameObject.Find("Wall" + m_wallCnt).transform.position;
                    float dir = m_pos.z - prevPos.z;


                    if (dir > 0)
                    {
                        //0.05f 를 더해주는것은 그냥 좌표 보정용
                        m_pos = new Vector3(prevPos.x, 0f, prevPos.z + dir - 0.05f);
                    }
                    else
                    {
                        m_pos = new Vector3(prevPos.x, 0f, prevPos.z + dir + 0.05f);
                    }
                }
                
                m_vectList.Add(new Vector2(m_pos.x, m_pos.z));

                m_wallCnt++;

                m_wallClone = Instantiate(m_wallPrefab) as GameObject;

                var wallControllers = m_wallClone.GetComponentsInChildren<WallController>();
                for (int i = 0; i < wallControllers.Length; i++)
                {
                    PolyWallManager.Instance.AddWall(wallControllers[i]);
                }

                m_wallClone.transform.parent = GameObject.Find("Walls").transform;
                m_wallClone.name = "Wall" + m_wallCnt.ToString();
                m_wallClone.transform.position = m_pos;

                StartCoroutine(EndPointCorutine(m_wallClone, m_pos));
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if(m_wallClone != null)
            {
                StopAllCoroutines();

                var wallControllers = m_wallClone.GetComponentsInChildren<WallController>();

                for (int i = 0; i < wallControllers.Length; i++)
                {
                    PolyWallManager.Instance.RemoveWall(wallControllers[i]);
                }

                Destroy(m_wallClone);
                m_wallCnt--;

                m_isHorizon = false;
                m_isVertical = false;
                m_UIevent.GetComponent<ButtonEvent>().ButtonsEnable();
                this.enabled = false;
            }
        }
    }
    #endregion

    #region unity
    // Start is called before the first frame update
    void Start()
    {
        m_wallPrefab = Resources.Load("Wall") as GameObject;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DrawWall();
    }
    #endregion
}
