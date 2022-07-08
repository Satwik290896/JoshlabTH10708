using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickStraight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool SpointerDown = false;
    public GameObject obj;
    public PlayerMotion playerMotion;

    public void OnPointerDown(PointerEventData eventData)
    {
        SpointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SpointerDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((SpointerDown) && (PlayerMotion.isColTH == false))
        {
            Vector3 offSet = new Vector3(0f, 0f, 0f);
            Vector3 eA = obj.transform.eulerAngles;
            float rad = (Mathf.PI / 180f) * (eA.y);
            offSet.x = 10 * Mathf.Sin(rad);
            offSet.z = 10 * Mathf.Cos(rad);

            obj.transform.position += offSet * Time.deltaTime;
        }
    }
}
