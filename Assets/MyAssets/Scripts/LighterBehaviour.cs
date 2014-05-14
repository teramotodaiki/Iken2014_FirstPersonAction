using UnityEngine;
using System.Collections;

/// <summary>
/// ライターのふるまいを定義するクラス
/// </summary>
public class LighterBehaviour : BaseGimmicBehaviour {
    public static bool Lighter { get; private set; }
    public GameObject Fire;
    public static GameObject Fire_obj { get; private set; }
    public static GameObject lighter { get; private set; }

	// Use this for initialization
	void Start () 
    {
        lighter = this.gameObject;
        Lighter = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (IsGripped)
        {
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;

            if (Input.GetButtonDown("PickUp"))
            {
                if (Lighter)
                {
                    Lighter = false;
                    Destroy(Fire_obj);
                }
                else
                {
                    Lighter = true;
                    Fire_obj = Instantiate(Fire, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                    Fire_obj.transform.parent = transform;
                }
            }
        }
	}

}
