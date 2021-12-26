using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;//場景轉換
using UnityEngine.UI;

public class FloorSpawner : MonoBehaviour
{
    public int SceneIndexDestination = 0;
    public static float sc;
    public static float st;

    public GameObject floor;
    public GameObject referencefloor;
    public GameObject player;
    public GameObject coin;
    public GameObject hole;
    public GameObject cross;
    public GameObject canvas;
    public GameObject canvas_cur;

    public Queue<GameObject> q = new Queue<GameObject>();//floor
    public Queue<GameObject> q1 = new Queue<GameObject>();//coin
    public Queue<GameObject> q2 = new Queue<GameObject>();//cross

    public Vector3 pre_pos;
    public Vector3 dir;

    public float dis = 8f;
    public float time_value = 1f;
    public float startTime;
    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(canvas_cur, Vector2.zero, Quaternion.identity);
        pre_pos = referencefloor.transform.position;
        startTime = Time.time;
        st = Time.time;
        sc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > time_value)
        {
            //floor
            int r = UnityEngine.Random.Range(0, 2);
            if (r == 0) dir = new Vector3(0, 0, 1);
            else if (r == 1) dir = new Vector3(1, 0, 0);
            Vector3 new_pos = pre_pos + dis * dir;
            startTime = Time.time;
            Instantiate(floor, new_pos, Quaternion.Euler(0, 0, 0));
            pre_pos = new_pos;
             q.Enqueue(floor);
            ////cross or hole
            int xy = Random.Range(0, 5);
            if (xy == 0)
            {
                if(r==1) Instantiate(cross, new Vector3(new_pos.x-4, new_pos.y+1, new_pos.z), Quaternion.Euler(0,  90 * r,0));
                else Instantiate(cross, new Vector3(new_pos.x, new_pos.y+1, new_pos.z-4), Quaternion.Euler(0, 90 * r,0));
                q2.Enqueue(cross);
            }
            else if(xy == 1)
            {
                if (r == 1) Instantiate(hole, new Vector3(new_pos.x - 4, new_pos.y-0.5f, new_pos.z), Quaternion.Euler(0,  90 * r,0));
                else Instantiate(hole, new Vector3(new_pos.x, new_pos.y-0.5f, new_pos.z - 4), Quaternion.Euler(0, 90 * r,0));
                q2.Enqueue(hole);
            }
            ////coin
            float x = Random.Range(new_pos.x - 4, new_pos.x + 4);
            float z = Random.Range(new_pos.z - 4, new_pos.z + 4);
            float y = Random.Range(0, new_pos.y + 5);
            Instantiate(coin, new Vector3(x, y, z), Quaternion.Euler(90, 0, 90*r));
            q1.Enqueue(coin);
        }
        //if(Time.time - timv > time_value * 4)
        if(q.Count != 0&& player.transform.position.x - GameObject.Find(q.Peek().name + "(Clone)").transform.position.x > 7 && player.transform.position.z - GameObject.Find(q.Peek().name + "(Clone)").transform.position.z > 7) { 
            Destroy(GameObject.Find(q.Peek().name + "(Clone)"));//直接destroy會變成直接刪除prefab，刪不到clone(也找不到
            q.Dequeue();
            //timv = Time.time;
        }

        if (q1.Count != 0 && player.transform.position.x - GameObject.Find(q1.Peek().name + "(Clone)").transform.position.x > 7 && player.transform.position.z - GameObject.Find(q1.Peek().name + "(Clone)").transform.position.z > 7)
        {
            if(q1.Peek()) Destroy(GameObject.Find(q1.Peek().name + "(Clone)"));//直接destroy會變成直接刪除prefab，刪不到clone(也找不到
            q1.Dequeue();
        }

        if (q2.Count != 0 && player.transform.position.x - GameObject.Find(q2.Peek().name + "(Clone)").transform.position.x > 7 && player.transform.position.z - GameObject.Find(q2.Peek().name + "(Clone)").transform.position.z > 7)
        {
            if (q2.Peek()) Destroy(GameObject.Find(q2.Peek().name + "(Clone)"));//直接destroy會變成直接刪除prefab，刪不到clone(也找不到
            q2.Dequeue();
        }

        if (player.transform.position.y < -20&&Time.timeScale == 1f)
        {
            sc += (Time.time - st);
            Time.timeScale = 0f;
            Destroy(GameObject.Find("Canvas(Clone)"));
            Instantiate(canvas, Vector2.zero, Quaternion.identity);
            GameObject.Find("gameover(Clone)").transform.GetChild(0).GetComponent<Text>().text += FloorSpawner.sc.ToString();
        }
    }
}
