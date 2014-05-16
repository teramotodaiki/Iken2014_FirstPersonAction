using UnityEngine;
using System.Collections;

public class SwitchBehaviour : BaseGimmicBehaviour {

    GameObject Breaker;
    public GameObject Spark;
    GameObject Clone;
    public bool timeFlg = false;
    float time = 0;
    //Renderer ren;

	// Use this for initialization
	void Start () 
    {
        Breaker = GameObject.Find("Paipu").gameObject;
        //ren = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeFlg) time += Time.fixedDeltaTime;
        if (time > 0.25f && time < 0.3f)
        {
           Clone = (GameObject)Instantiate(Spark, transform.position, Quaternion.identity);
        }
        if(time > 0.3f)
        {
            //time = 0;
            timeFlg = false;
            GameObject.Find("SlideDoor").GetComponent<SlideDoor>().enabled = true;
            //transform.rigidbody.useGravity = true;
            Destroy(Clone, 3);
        }
	}

    public override void Action()
    {
        if (Breaker.transform.parent != Player.handGameObject.transform) return;
        //ren.material.color = Color.blue;
        //transform.renderer.material.color = Color.blue;
        timeFlg = true;
        Destroy(Breaker, 0.3f);
    }
}
