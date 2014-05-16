using UnityEngine;
using System.Collections;

public class EleveterOpen : MonoBehaviour {

    bool SlideFlg = false;
    GameObject DoorL, DoorR;
    float doorL_x, doorR_x;
    public float time = 0;

	// Use this for initialization
	void Start () 
    {
        DoorL = GameObject.Find("Cube_Erevator_L");
        DoorR = GameObject.Find("Cube_Erevator_R");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SlideFlg) time += Time.fixedDeltaTime;
        if(time > 0 && time < 1.0f)
        {
            DoorL.transform.position += transform.right * 0.05f;
            DoorR.transform.position -= transform.right * 0.05f;
        }
        if (time >= 2.0f && time < 3.0f)
        {
            DoorL.transform.position -= transform.right * 0.05f;
            DoorR.transform.position += transform.right * 0.05f;
        }
        Debug.Log(time);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            SlideFlg = true; 
    }

    //void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //        SlideFlg = false;
    //}
}
