using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour {
    public GameObject movingcamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movingcamera.transform.Translate(30f*Vector3.forward * Time.deltaTime * Time.deltaTime);
            Debug.Log("moving forward");
        }
    }
}
