using UnityEngine;
using System.Collections;

public class SlideDoor : MonoBehaviour {

    public int Slide = 0;
    GameObject door;
    float time = 0;

	// Use this for initialization
	void Start () 
    {
        door = GameObject.Find("Door");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Slide == 1 && Input.GetKeyDown(KeyCode.E))
            Slide = 2;
        if(Slide == 2)time += Time.fixedDeltaTime;
        if(time >0 && time < 1.5f)
            door.transform.position += door.transform.right * 0.05f;
        if (time >= 1.5f) Destroy(gameObject);
        Debug.Log(Slide);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            Slide = 1;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            Slide = 0;
    }
}
