using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//«ö«ö¶s¤§Ãþ

public class buttin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public int num;
    public GameObject canvasPrefab;
    public GameObject canvas2;

    public void OnPointerClick(PointerEventData e)//necessary
    {
        if (num == 0) Time.timeScale = 0f;
        else Time.timeScale = 1f;
        Instantiate(this.canvasPrefab, Vector2.zero, Quaternion.identity);
        Destroy(this.canvas2);
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
