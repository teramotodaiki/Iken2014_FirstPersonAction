using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    NavMeshAgent nav;
    bool timeFlg = false;
    float time = 0;


	// Use this for initialization
	void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timeFlg) time += Time.fixedDeltaTime;
        if(time > 1.2f)
            nav.SetDestination(GameObject.Find("Player").transform.position);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            timeFlg = true;
    }
}
