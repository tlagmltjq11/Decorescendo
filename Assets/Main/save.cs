using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class save : SingletonMonoBehaviour<save>
{
    [SerializeField]
    DrawHome dh;
    private string[] FromWebStr;
    GameObject m_moveUI;
    GameObject m_rotationUI;

    void Awake()
    {
    }
    void Start()
    {
        m_moveUI = Resources.Load("FurnitureMoveUI") as GameObject;
        Debug.Log(m_moveUI.name);
        m_rotationUI = Resources.Load("FurnitureRotationUI") as GameObject;
        Debug.Log(m_rotationUI.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save(string objname, string json)
    {
        //Application.ExternalCall("test", json);

        if (!Directory.Exists(Application.dataPath + "/Saves/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves/");
        }

        File.WriteAllText(Application.dataPath + "/Saves/" + objname + ".txt", json);
        Debug.Log("save 경로:" + Application.dataPath);

    }

    public void FromWebString(string str)
    {
        string FromWeb = str;
        FromWebStr = FromWeb.Split('!');
    }


    public string[] Load()
    {

        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Saves/");
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.txt");

        string[] arr = new string[saveFiles.Length];

        for (int i = 0; i < saveFiles.Length; i++)
        {
            arr[i] = File.ReadAllText(saveFiles[i].FullName);
            Debug.Log(arr[i]);
        }



        return arr;
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

    public void savebuttonOnclick()
    {
       
        var walls = GameObject.FindGameObjectsWithTag("Wall");
        var furnitures = GameObject.FindGameObjectsWithTag("furniture");
        var floor = GameObject.FindGameObjectsWithTag("Floor");

        wallinfo[] wallinfoarr = new wallinfo[walls.Length];
        furnitureinfo[] furnitureinfoarr = new furnitureinfo[furnitures.Length];
        floorinfo[] floorinfoarr = new floorinfo[floor.Length];

        int index = 0;
        string ToWeb = "";

        for (int i = 0; i < wallinfoarr.Length; i++)
        {
            var m_mats = walls[i].GetComponentsInChildren<MeshRenderer>();
            wallinfoarr[index] = new wallinfo(walls[i].name, walls[i].transform.position, walls[i].transform.rotation, walls[i].transform.localScale, m_mats[1].materials[0].name, m_mats[2].materials[0].name);
            string json = JsonUtility.ToJson(wallinfoarr[index]);
            //      Debug.Log("obj:" + json);
            Save(wallinfoarr[index].name, json);
            index++;
        }


        index = 0;
        for (int i = 0; i < furnitureinfoarr.Length; i++)
        {
            string furniturename = furnitures[i].name;
            if (furnitures[i].name.Substring(furnitures[i].name.Length - 7).Equals("(Clone)"))
            {
                furniturename = furnitures[i].name.Substring(0, furnitures[i].name.Length - 7);
            }

            furnitureinfoarr[index] = new furnitureinfo(furniturename, furnitures[i].transform.position, furnitures[i].transform.rotation);
            
            string json = JsonUtility.ToJson(furnitureinfoarr[index]);
            //      Debug.Log("obj:" + json);
            Save(furnitureinfoarr[index].name, json);
            index++;

        }


        index = 0;
        for (int i = 0; i < floorinfoarr.Length; i++)
        {
            var material = floor[i].GetComponent<MeshRenderer>().materials;
            floorinfoarr[index] = new floorinfo(floor[i].name, floor[i].GetComponent<PolyController>().GetVect(), material[0].name);  //좌표정보 list로 저장
                                                                                                                                      // Debug.Log("!!!!!!!!!!" + floor[i].GetComponent<PolyController>());
            string json = JsonUtility.ToJson(floorinfoarr[index]);
            //     Debug.Log("floor obj:" + json);
            Save(floor[i].name, json);
        }
        //Save(ToWeb);
    }

    public void loadbuttonOnclick()
    {
        //string[] json2 = FromWebStr;
        string[] json2 = Load();
        for (int i = 0; i < json2.Length; i++)
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

                string mateiralname_1 = obj2.material_1.Substring(0, obj2.material_1.Length - 11);
                string mateiralname_2 = obj2.material_2.Substring(0, obj2.material_2.Length - 11);

                var wallmaterial_1 = Resources.Load("Materials/" + mateiralname_1) as Material;
                var wallmaterial_2 = Resources.Load("Materials/" + mateiralname_2) as Material;

                var wallController = obj.GetComponentsInChildren<WallController>();
                PolyWallManager.Instance.AddWall(wallController[0]);
                PolyWallManager.Instance.AddWall(wallController[1]);

                wallController[0].SetMaterial(wallmaterial_1);
                wallController[1].SetMaterial(wallmaterial_2);

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

                    list.Add(new Vector2(float.Parse(xy[0]), float.Parse(xy[1])));
                }

                string materialname = obj3.material.Substring(0, obj3.material.Length - 11);
                
                var material = Resources.Load("Materials/" + materialname) as Material;
                
                script.SetVect(list);
                script.CreateFloor();


                script.SetMaterial(material);

                PolyWallManager.Instance.AddPoly(script);
            }
            else    //json 파일이 가구 정보일때
            {
                furnitureinfo obj2 = JsonUtility.FromJson<furnitureinfo>(json2[i]);

                var fur = Instantiate(Resources.Load("Furniture/" + obj2.name), obj2.position, obj2.rotation) as GameObject;


                var moveUI = Instantiate(m_moveUI);
                var rotationUI = Instantiate(m_rotationUI);
                moveUI.transform.parent = fur.transform;
                rotationUI.transform.parent = fur.transform;

                var script = fur.AddComponent<FurnitureController>();
                Debug.Log(script);
                FurnitureManager.Instance.AddFurniture(script);
            }
        }
    }
}

