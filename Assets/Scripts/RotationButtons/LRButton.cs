using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRButton : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj1;
    public PlayerMotion playerMotion;
    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.FindGameObjectWithTag("Player");
        obj1 = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLR(){
        if (PlayerMotion.isColTH == false)
        {
            obj.transform.Rotate(0, -20 * Time.deltaTime, 0);
            //obj1.transform.Rotate(0, -20 * Time.deltaTime, 0);
        }
    }
}
