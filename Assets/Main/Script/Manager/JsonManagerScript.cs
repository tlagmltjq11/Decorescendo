using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEditor;

public class JsonManagerScript : SingletonMonoBehaviour<JsonManagerScript>
{
    [SerializeField]
    DrawHome dh;
    private string[] FromWebStr;
    private string FromWeb = "";
    GameObject m_moveUI;
    GameObject m_rotationUI;

    [DllImport("__Internal")]
    private static extern void saveww(string arg);

    [DllImport("__Internal")]
    private static extern void loadweb();

    void Start()
    {
        m_moveUI = Resources.Load("FurnitureMoveUI") as GameObject;
        m_rotationUI = Resources.Load("FurnitureRotationUI") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save(string json)
    {
        Console.WriteLine(json);
        saveww(json);

    }

    public void FromWebString(string str)
    {
        Console.WriteLine(FromWeb);
        Console.WriteLine(str);
        FromWeb = str;
        loadsummon();
    }



    string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }

    //객체 정보 저장할 클래스
    public class wallinfo
    {
        public string name;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public string material_1;
        public string material_2;

        public wallinfo()
        {
        }
        public wallinfo(string name, Vector3 pos, Quaternion rot, Vector3 scl, string material_1, string material_2)
        {
            this.name = name;
            this.position = pos;
            this.rotation = rot;
            this.scale = scl;
            this.material_1 = material_1;
            this.material_2 = material_2;
        }
    }
    public class furnitureinfo
    {
        public string name;
        public Vector3 position;
        public Quaternion rotation;

        public furnitureinfo()
        {
        }
        public furnitureinfo(string name, Vector3 pos, Quaternion rot)
        {
            this.name = name;
            this.position = pos;
            this.rotation = rot;
        }
    }
    public class floorinfo
    {
        public string name;
        public string position = "";
        public string material;

        public floorinfo()
        {
        }
        public floorinfo(string n, List<Vector2> pos, string material)
        {
            this.name = n;
            position = string.Join("^", pos.ToArray());
            this.material = material;
        }
    }

    public void addfurniture(string fname)
    {
        fname = "Furniture/" + fname;
        var fur = Instantiate(Resources.Load(fname)) as GameObject;

        var polys = GameObject.Find("Polys");
        if(polys.transform.childCount >= 1)
        {
            var list = polys.GetComponentsInChildren<Transform>();
            fur.transform.position = new Vector3(list[list.Length - 1].transform.position.x, 0.5f, list[list.Length - 1].transform.position.z);
        }
        else
        {
            fur.transform.position = new Vector3(0f, 0.5f, 0f);
        }

        var moveUI = Instantiate(m_moveUI) as GameObject;
        var rotationUI = Instantiate(m_rotationUI) as GameObject;
        moveUI.transform.parent = fur.transform;
        rotationUI.transform.parent = fur.transform;

        var script = fur.AddComponent<FurnitureController>();
        FurnitureManager.Instance.AddFurniture(script);
    }

    public void savebuttonOnclick()
    {

        var walls = GameObject.FindGameObjectsWithTag("Wall");
        var floor = GameObject.FindGameObjectsWithTag("Floor");
        var furnitures = GameObject.FindGameObjectsWithTag("furniture");

        wallinfo[] wallinfoarr = new wallinfo[walls.Length];
        floorinfo[] floorinfoarr = new floorinfo[floor.Length];
        furnitureinfo[] furnitureinfoarr = new furnitureinfo[furnitures.Length];

        int index = 0;
        string ToWeb = "";

        for (int i = 0; i < wallinfoarr.Length; i++)
        {
            var m_mats = walls[i].GetComponentsInChildren<MeshRenderer>();

            wallinfoarr[index] = new wallinfo(walls[i].name, walls[i].transform.position, walls[i].transform.rotation, walls[i].transform.localScale, m_mats[1].materials[0].name, m_mats[2].materials[0].name);
            string json = JsonUtility.ToJson(wallinfoarr[index]);
            Debug.Log("obj:" + json);
            //    Save(wallinfoarr[index].name, json);
            ToWeb += json + "!";
            index++;
        }


        index = 0;
        for (int i = 0; i < floorinfoarr.Length; i++)
        {
            var m_mats = floor[i].GetComponent<MeshRenderer>().materials;
            floorinfoarr[index] = new floorinfo(floor[i].name, floor[i].GetComponent<PolyController>().GetVect(), m_mats[0].name);  //좌표정보 list로 저장
                                                                                                                                    // Debug.Log("!!!!!!!!!!" + floor[i].GetComponent<PolyController>());
            string json = JsonUtility.ToJson(floorinfoarr[index]);
            Debug.Log("floor obj:" + json);
            ToWeb += json + "!";
            index++;
            //    Save(floor[i].name, json);
        }

        index = 0;
        for (int i = 0; i < furnitureinfoarr.Length; i++)
        {
            string furniturename = furnitures[i].name;
            if (furniturename.Length > 7)
            {
                if (furnitures[i].name.Substring(furnitures[i].name.Length - 7).Equals("(Clone)"))
                {
                    furniturename = furnitures[i].name.Substring(0, furnitures[i].name.Length - 7);
                }
            }
            furnitureinfoarr[index] = new furnitureinfo(furniturename, furnitures[i].transform.position, furnitures[i].transform.rotation);
            string json = JsonUtility.ToJson(furnitureinfoarr[index]);
            Debug.Log("obj:" + json);
            //    Save(furnitureinfoarr[index].name, json);
            ToWeb += json + "!";
            index++;

        }
        Save(ToWeb);
    }

    public void loadbuttonOnclick()
    {
        loadweb();
    }
    public void loadsummon()
    {

        if (FromWeb.Equals("no"))
        {

        }
        else
        {
            PolyWallManager.Instance.EraseAllPoly();
            dh.EraseAll();
            dh.EraseAllFurnitures();
            FromWebStr = FromWeb.Split('!');
            string[] json2 = FromWebStr;

            for (int i = 0; i < json2.Length - 1; i++)
            {
                Debug.Log("json print:" + json2[i].Substring(9, 4));

                if (json2[i].Substring(9, 4).Equals("Wall"))   //json 파일이 wall정보일때
                {
                    wallinfo obj2 = JsonUtility.FromJson<wallinfo>(json2[i]);
                    var obj = Instantiate(Resources.Load("Wall")) as GameObject;
                    obj.name = obj2.name;
                    obj.transform.parent = GameObject.Find("Walls").transform;

                    obj.transform.position = obj2.position;
                    obj.transform.rotation = obj2.rotation;
                    obj.transform.localScale = obj2.scale;
                    dh.m_wallCnt++;

                    string materialname1 = obj2.material_1;
                    if (materialname1.Length > 11)
                    {
                        if (materialname1.Substring(materialname1.Length - 10).Equals("(Instance)"))
                        {
                            materialname1 = materialname1.Substring(0, materialname1.Length - 11);
                        }

                    }
                    var wallmaterial1 = Resources.Load("Materials/" + materialname1) as Material;

                    string materialname2 = obj2.material_2;
                    if (materialname2.Length > 11)
                    {
                        if (materialname2.Substring(materialname2.Length - 10).Equals("(Instance)"))
                        {
                            materialname2 = materialname2.Substring(0, materialname2.Length - 11);
                        }

                    }
                    var wallmaterial2 = Resources.Load("Materials/" + materialname2) as Material;


                    var wallController = obj.GetComponentsInChildren<WallController>();
                    PolyWallManager.Instance.AddWall(wallController[0]);
                    PolyWallManager.Instance.AddWall(wallController[1]);

                    wallController[0].SetMaterial(wallmaterial1);
                    wallController[1].SetMaterial(wallmaterial2);


                }
                else if (json2[i].Substring(9, 4).Equals("Poly"))  //json 파일이 바닥정보일때
                {
                    floorinfo obj3 = JsonUtility.FromJson<floorinfo>(json2[i]);

                    string[] coordinate = obj3.position.Split('^');

                    GameObject poly = new GameObject(obj3.name);

                    PolyController script = poly.AddComponent<PolyController>();

                    List<Vector2> list = new List<Vector2>();

                    for (int k = 0; k < coordinate.Length; k++)
                    {
                        string[] xy = (coordinate[k].Substring(1, coordinate[k].Length - 2)).Split(',');
                        Debug.Log(coordinate[k].Length);
                        list.Add(new Vector2(float.Parse(xy[0]), float.Parse(xy[1])));
                    }



                    string materialname = obj3.material;
                    if (materialname.Length > 11 && materialname.Substring(materialname.Length - 10).Equals("(Instance)"))
                    {
                        materialname = materialname.Substring(0, materialname.Length - 11);
                    }
                    var material = Resources.Load("Materials/" + materialname) as Material;

                    script.SetVect(list);
                    script.CreateFloor();
                    script.SetMaterial(material);

                    dh.m_polyCnt++;

                    Debug.Log(script);

                    PolyWallManager.Instance.AddPoly(script);

                }
                else    //json 파일이 가구 정보일때
                {
                    furnitureinfo obj2 = JsonUtility.FromJson<furnitureinfo>(json2[i]);

                    var fur = Instantiate(Resources.Load("Furniture/" + obj2.name), obj2.position, obj2.rotation) as GameObject;


                    var moveUI = Instantiate(m_moveUI) as GameObject;
                    var rotationUI = Instantiate(m_rotationUI) as GameObject;
                    moveUI.transform.parent = fur.transform;
                    rotationUI.transform.parent = fur.transform;

                    var script = fur.AddComponent<FurnitureController>();
                    FurnitureManager.Instance.AddFurniture(script);
                }

            }
        }
        FromWeb = "";
    }
}