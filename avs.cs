using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//�����s����
using UnityEngine.SceneManagement;//�����ഫ

public class avs : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 0;
    public GameObject canvas;
    public void OnPointerClick(PointerEventData e)//necessary
    {
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("current s is" + scene.name + "index " + scene.buildIndex);
        Destroy(GameObject.Find("gameover(Clone)"));
        SceneManager.LoadScene(SceneIndexDestination);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
