using UnityEngine;
using System.Collections;

/// <summary>
/// これが噂のキューブパイプさ！
/// </summary>
public class PaipuBehaviour : BaseGimmicBehaviour {

    SwitchBehaviour SB;

	// Use this for initialization
	void Start () 
    {
        SB = GetComponent<SwitchBehaviour>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(IsGripped)
        {
            transform.localPosition = Vector3.zero;
            if(!GameObject.Find("Switch").GetComponent<SwitchBehaviour>().timeFlg)
            transform.localEulerAngles = new Vector3(-90,0,45);
            else
                transform.Rotate(30, 0, 0);
            transform.rigidbody.useGravity = true;
        }
	}
}
