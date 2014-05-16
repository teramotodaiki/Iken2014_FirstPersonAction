using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    RaycastHit hit;
    public GameObject Spark;
    GameObject Clone;
    float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        time++;
	    if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if(time %10 == 0)
            Clone = (GameObject)Instantiate(Spark, hit.transform.position, Quaternion.identity);
        }
        Destroy(Clone, 3);
	}
}
