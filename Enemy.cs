using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas_cur;
    public GameObject player;

    [SerializeField] float speed = 0.14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f) return;
        transform.position += (player.transform.position - transform.position) * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "viking"&&Time.timeScale == 1f)
        {
            FloorSpawner.sc += (Time.time - FloorSpawner.st);
            Time.timeScale = 0f;
            Destroy(GameObject.Find("Canvas(Clone)"));
            Instantiate(canvas, Vector2.zero, Quaternion.identity);
            GameObject.Find("gameover(Clone)").transform.GetChild(0).GetComponent<Text>().text += FloorSpawner.sc.ToString();
        }
    }
}
