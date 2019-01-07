using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

namespace HoloToolkit.Unity.Examples
{
    public class LocationScout : InteractionReceiver
    {
        public GameObject TheCamera;
        public GameObject[] locations;
        public GameObject[] Teleports;
        public GameObject scripts;
        public bool teleportsuccess = false;
        public void Teleport(int number) {
            TheCamera.transform.position = locations[number].transform.position;
        }
        // Use this for initialization
        void Update()
        {
            if (teleportsuccess == true)
            {
                TheCamera.transform.Translate(0, 18, 0);
                teleportsuccess = false;
            }
        }
        void Start()
        {
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i] = GameObject.Find("3D Buildings/").transform.GetChild(i).gameObject;
                Teleports[i] = GameObject.Find(locations[i].name + "/Teleport");
            }
        }
        protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
        {
            Debug.Log(obj.name);
        }
        protected override void InputDown(GameObject obj, InputEventData eventData)
        {
            Debug.Log("being pressed");
            for (int i = 0; i < locations.Length; i++)
            {
                if (locations[i].name == obj.name)
                {
                   
                    TheCamera.transform.position = Teleports[i].transform.position;

                    teleportsuccess = true;
                }
            
            }



        }
        public void OnStart()
        {
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i] = GameObject.Find("3D Buildings/").transform.GetChild(i).gameObject;
                Teleports[i] = GameObject.Find(locations[i].name + "/Teleport");
                TheCamera.transform.position = Teleports[0].transform.position;
            }
        }
            // Update is called once per frame

        }
}