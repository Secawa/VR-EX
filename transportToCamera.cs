using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transportToCamera : MonoBehaviour {
    public GameObject CameraLocation;
    public float cooldown = 2f;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        this.gameObject.transform.position = CameraLocation.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            gameObject.SetActive(false);
        }
	}
}
