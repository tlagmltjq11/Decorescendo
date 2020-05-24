using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
public class JsonManagerScript : SingletonMonoBehaviour<JsonManagerScript>
{
    [SerializeField]
    DrawHome dh;
    private string[] FromWebStr;
    private string FromWeb = "";

    [DllImport("__Internal")]
    private static extern void saveww(string arg);

    [DllImport("__Internal")]
    private static extern void loadweb();

    void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save(string json)
    {
        Console.WriteLine(json);
        saveww(json);
        /*
        if (!Directory.Exists(Application.dataPath + "/Saves/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves/");
        }

        File.WriteAllText(Application.dataPath + "/Saves/" + objname + ".txt", json);
        Debug.Log("save 경로:" + Application.dataPath);
        */
    }

    public void FromWebString(string str)
    {
        Console.WriteLine(FromWeb);
        Console.WriteLine(str);
        FromWeb = str;
        loadsummon();
    }

    /*
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
    */

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

        public wallinfo()
        {
        }
        public wallinfo(string name, Vector3 pos, Quaternion rot, Vector3 scl)
        {
            this.name = name;
            this.position = pos;
            this.rotation = rot;
            this.scale = scl;
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

        public floorinfo()
        {
        }
        public floorinfo(string n, List<Vector2> pos)
        {
            this.name = n;
            position = string.Join("^", pos.ToArray());
        }
    }

    public void addfurniture(string fname)
    {
        fname = "Furniture/" + fname;
        var fur = Instantiate(Resources.Load(fname), new Vector3(0, 1, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        //var script = fur.AddComponent<FurnituerController>();
        //FurnitureManager.Instance.AddFurniture(script);
    }

    public void savebuttonOnclick()
    {
        /*
        var walls = GameObject.Find("Walls").GetComponentsInChildren<Transform>();
        var floor = GameObject.Find("Floor").GetComponentsInChildren<Transform>();
        var furnitures = GameObject.Find("Furnitures").GetComponentsInChildren<Transform>();
        */
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
            wallinfoarr[index] = new wallinfo(walls[i].name, walls[i].transform.position, walls[i].transform.rotation, walls[i].transform.localScale);
            string json = JsonUtility.ToJson(wallinfoarr[index]);
            Debug.Log("obj:" + json);
            //    Save(wallinfoarr[index].name, json);
            ToWeb += json + "!";
            index++;
        }


        index = 0;
        for (int i = 0; i < furnitureinfoarr.Length; i++)
        {

            furnitureinfoarr[index] = new furnitureinfo(furnitures[i].name, furnitures[i].transform.position, furnitures[i].transform.rotation);
            string json = JsonUtility.ToJson(furnitureinfoarr[index]);
            Debug.Log("obj:" + json);
            //    Save(furnitureinfoarr[index].name, json);
            ToWeb += json + "!";
            index++;

        }


        index = 0;
        for (int i = 0; i < floorinfoarr.Length; i++)
        {
            floorinfoarr[index] = new floorinfo(floor[i].name, floor[i].GetComponent<PolyController>().GetVect());  //좌표정보 list로 저장
                                                                                                                    // Debug.Log("!!!!!!!!!!" + floor[i].GetComponent<PolyController>());
            string json = JsonUtility.ToJson(floorinfoarr[index]);
            Debug.Log("floor obj:" + json);
            ToWeb += json + "!";
            //    Save(floor[i].name, json);
        }
        Save(ToWeb);
    }

    public void loadbuttonOnclick()
    {
        SceneManager.LoadScene("Main");
        loadweb();
    }
    public void loadsummon()
    {

        if (FromWeb.Equals("no"))
        {

        }
        else
        {
            FromWebStr = FromWeb.Split('!');
            string[] json2 = FromWebStr;

            for (int i = 0; i < json2.Length; i++)
            {
                Debug.Log("json print:" + json2[i].Substring(9, 4));

                if (json2[i].Substring(9, 4).Equals("Wall"))   //json 파일이 wall정보일때
                {
                    wallinfo obj2 = JsonUtility.FromJson<wallinfo>(json2[i]);
                    var obj = Instantiate(Resources.Load("Wall")) as GameObject;
                    obj.name = obj2.name;
                    obj.transform.position = obj2.position;
                    obj.transform.rotation = obj2.rotation;
                    obj.transform.localScale = obj2.scale;
                    dh.m_wallCnt++;
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

                    script.SetVect(list);
                    script.CreateFloor();
                    dh.m_polyCnt++;

                    PolyWallManager.Instance.AddPoly(script);
                }
                else    //json 파일이 가구 정보일때
                {
                    furnitureinfo obj2 = JsonUtility.FromJson<furnitureinfo>(json2[i]);

                    string n = "Furniture/" + obj2.name.Substring(0, obj2.name.Length - 7);
                    var fur = Instantiate(Resources.Load(n), obj2.position, obj2.rotation) as GameObject;
                    //var script = fur.AddComponent<FurnituerController>();
                    //FurnitureManager.Instance.AddFurniture(script);
                }

            }
        }
        FromWeb = "";
    }
}