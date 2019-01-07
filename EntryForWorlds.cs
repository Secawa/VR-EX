using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using UnityEngine.Video;

public class EntryForWorlds : MonoBehaviour {
    public RawImage[] rawImage;
    public GameObject[] disablethese;
    public GameObject[] enablethese;
    public GameObject Sphere;
    public VideoPlayer[] videoPlayer;
    public Material[] Material;
    public bool updatetocamera;
    public GameObject thecamera;
    // Use this for initialization
    void Start () {
        thecamera = GameObject.Find("MixedRealityCameraParent");
    }
	
	// Update is called once per frame
	void Update () {
		if (updatetocamera == true)
        {
            this.gameObject.transform.position = thecamera.transform.position;
        }
	}
    public void loadimage1(int WorldNum)
    {
        for (int i = 0; i < enablethese.Length; i++) {
            enablethese[i].SetActive(true);
                }
        for (int i = 0; i < disablethese.Length; i++)
        {
            disablethese[i].SetActive(false);
        }
        Sphere.GetComponent<Renderer>().material = Material[WorldNum];
       
    }
    public void loadvideo1(int MovieNum)
    {
        videoPlayer[MovieNum] = Sphere.GetComponent<VideoPlayer>();
    }
}
