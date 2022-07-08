using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown = false;
    public GameObject obj;
    public GameObject obj1;
    public PlayerMotion playerMotion;

    public void OnPointerDown(PointerEventData eventData){
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        pointerDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.FindGameObjectWithTag("Player");
        obj1 = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerDown && (PlayerMotion.isColTH == false))
        {
            obj.transform.Rotate(0, -20*Time.deltaTime, 0);
            //obj1.transform.Rotate(0, -20 * Time.deltaTime, 0);
        }
    }
}
