using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMotion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject cam;
    public GameObject block_obj;
    public GameObject realplayer;
    public GameObject Cam;
    public GameObject MazeObj;
    public GameObject MazeObj2;
    static public bool touched = false;
    static public bool ControlPause = false;
    static public bool okTouch = false;
    static public bool skipMove = false;
    //public bool ringTouch = false;
    public BoxSwapper boxswapper;
    public AnswerSelector answerSelect;

    private Touch touch;
    private float speedModifier;
    public float Force;
    static public bool isColTH;
    void Start()
    {
        speedModifier = 0.001f;
        //realplayer = GameObject.FindGameObjectWithTag("Player");
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
        Force = 10f;
        //realplayer.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, -9.81f, 0), ForceMode.Force);
        isColTH = false;
    }

    // Update is called once per frame
    void Update()
    {


            //var rayCastPoint = Camera.main.;
            if (TouchScreenInputWrapper.touches.Length > 0)
            {
                Ray rayCastPoint = Camera.main.ScreenPointToRay(TouchScreenInputWrapper.touches[0].position);
                //UnityEngine.Debug.Log("rayCastPoint origin: " + rayCastPoint.origin);
                //UnityEngine.Debug.Log("rayCastPoint direction: " + rayCastPoint.direction);
                //UnityEngine.Debug.Log("Player position: " + realplayer.transform.position);
                Debug.DrawRay(rayCastPoint.origin, rayCastPoint.direction * 10, Color.yellow);
                //Debug.DrawRay(rayCastPoint.origin, rayCastPoint.direction * 10, Color.yellow);
                RaycastHit hit;
                //obj.transform.position = rayCastPoint.origin;
                Force = 100f;
                //UnityEngine.Debug.Log("TouchPhase: " + TouchScreenInputWrapper.touches[0].phase);
            if (TouchScreenInputWrapper.touches[0].phase == TouchPhase.Began)
            {
                //UnityEngine.Debug.Log("TouchPhase: Bro. I am here 0");
                if (!ControlPause)
                {
                    touched = true;
                    if (Physics.Raycast(rayCastPoint, out hit))
                    {
                        //UnityEngine.Debug.Log("TouchPhase: Bro. I am here ");
                        if (hit.collider.tag != "cube")
                        {
                            Vector3 offSet = new Vector3(0f, 0f, 0f);
                            Vector3 eA = realplayer.transform.eulerAngles;
                            float rad = (Mathf.PI / 180f) * (eA.y);
                            offSet.x = 10*Mathf.Sin(rad);
                            offSet.z = 10*Mathf.Cos(rad);
                            //offSet.x = rayCastPoint.origin.x - realplayer.transform.position.x;
                            //offSet.z = rayCastPoint.origin.y - realplayer.transform.position.y;
                            //UnityEngine.Debug.Log("offSet: " + offSet.z);
                            //UnityEngine.Debug.Log("TouchPhase: Bro. I am here position: " + realplayer.transform.localPosition);
                            //UnityEngine.Debug.Log("TouchPhase: Bro. I am here offset: " + offSet);
                            //realplayer.transform.position += offSet*Time.deltaTime;
                            //UnityEngine.Debug.Log("TouchPhase: Bro. I am here position 2222: " + realplayer.transform.localPosition);

                            Vector3 offSet1 = new Vector3(0f, 0f, 0f);
                            Vector3 eA1 = Cam.transform.eulerAngles;
                            float rad1 = (Mathf.PI / 180f) * (eA1.y);
                            offSet1.x = Mathf.Sin(rad1);
                            offSet1.z = Mathf.Cos(rad1);
                            //Cam.transform.position += offSet1;


                        }
                        else {
                            //UnityEngine.Debug.Log("TouchPhase: Bro. I skipped it");
                        }
                    }
                }
                else
                {
                    if (Physics.Raycast(rayCastPoint, out hit))
                    {
                        //UnityEngine.Debug.Log("TouchPhasefffftyhth6h667u67c65c6y5yc54cycx5xch6ch: " + hit.collider.tag);
                        if (hit.collider.tag == "Box1")
                        {
                            boxswapper.UpdateSelectBox(0);
                        }
                        else if (hit.collider.tag == "Box2")
                        {
                            boxswapper.UpdateSelectBox(1);
                        }
                        else if (hit.collider.tag == "Box3")
                        {
                            boxswapper.UpdateSelectBox(2);
                        }
                        else if (hit.collider.tag == "YES")
                        {
                            answerSelect.UpdateSelectQues(0);
                        }
                        else if (hit.collider.tag == "MAYBE")
                        {
                            answerSelect.UpdateSelectQues(1);
                        }
                        else if (hit.collider.tag == "NO")
                        {
                            answerSelect.UpdateSelectQues(2);
                        }
                        else if (hit.collider.tag == "OK")
                        {
                            okTouch = true;
                            skipMove = true;

                        }
                    }
                }
            }
            else if (TouchScreenInputWrapper.touches[0].phase == TouchPhase.Stationary)
            {
                if (!ControlPause)
                {
                    touched = false;
                    if (Physics.Raycast(rayCastPoint, out hit))
                    {
                        if (hit.collider.tag != "cube")
                        {
                            Vector3 offSet = new Vector3(0f, 0f, 0f);
                            Vector3 eA = realplayer.transform.eulerAngles;
                            float rad = (Mathf.PI / 180f) * (eA.y);
                            offSet.x = 10*Mathf.Sin(rad);
                            offSet.z = 10*Mathf.Cos(rad);
                            //offSet.x = rayCastPoint.origin.x - realplayer.transform.position.x;
                            //offSet.z = rayCastPoint.origin.y - realplayer.transform.position.y;
                            //UnityEngine.Debug.Log("offSet: " + offSet.z);
                            //realplayer.transform.position += offSet * Time.deltaTime;

                            Vector3 offSet1 = new Vector3(0f, 0f, 0f);
                            Vector3 eA1 = Cam.transform.eulerAngles;
                            float rad1 = (Mathf.PI / 180f) * (eA1.y);
                            offSet1.x = Mathf.Sin(rad1);
                            offSet1.z = Mathf.Cos(rad1);
                            //Cam.transform.position += offSet1;
                        }

                    }
                }
                else
                {
                    if (Physics.Raycast(rayCastPoint, out hit))
                    {
                        //UnityEngine.Debug.Log("TouchPhase-Station: fffftyhth6h667u67c65c6y5yc54cycx5xch6ch: " + hit.collider.tag);
                        //UnityEngine.Debug.Log("TouchPhase-Station: hit_transform_pos: " + hit.transform.position);
                        //UnityEngine.Debug.Log("TouchPhase-Station: hit_point: " + hit.point);
                        //UnityEngine.Debug.Log("TouchPhase-Station: obj_transform_pos: " + obj.transform.position);

                        if ((hit.collider.tag == "Ring" || (OK.okenabled = true)) && (skipMove == false))
                        {
                            
                            Vector3 toMove = new Vector3(0f, 0f, 0f);
                            toMove.x = hit.point.x;
                            toMove.z = hit.point.z;
                            toMove.y = obj.transform.position.y;

                            obj.transform.position = toMove;
                            

                        }

                        
                    }


                }
            }

            }

    }

    /*public void EnableCollisionBool() {
        isColTH = true;
    }

    public void DisableCollisionBool()
    {
        isColTH = false;
    }*/

    /*public bool isColTHAPI() {
        return isColTH;
    }
    */

}