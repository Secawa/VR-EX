using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace HoloToolkit.Unity.Examples
{
    public class Waypointers : MonoBehaviour
    {

        public GameObject Cameralocation;
        public GameObject cameraeyes;
        public GameObject[] Locations;
        public GameObject scripts;
        public GameObject[] TheWaypointers;
        public float Distancebetween;
        public float[] Measuredistance;
        public Text[] Thedistancemeasures;
        // Use this for initialization
        void Start()
        {
            Cameralocation = GameObject.Find("MixedRealityCameraParent");
            cameraeyes = GameObject.Find("Cameraeyes").transform.GetChild(0).gameObject;
            scripts = GameObject.Find("TheScripts");
            for (int i = 0; i < Locations.Length; i++)
            {
                Locations[i] = GameObject.Find("3D Buildings/" + scripts.GetComponent<FindThebuildingsagain>().namesoflocations[i] + "/Teleport");
                TheWaypointers[i] = this.gameObject.transform.GetChild(i).gameObject;
                //TheWaypointers[i].transform.position = Vector3.MoveTowards(Cameralocation.transform.position, Locations[i].transform.position, -Distancebetween);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < TheWaypointers.Length; i++)
            {
                TheWaypointers[i].transform.LookAt(cameraeyes.transform.position);
                TheWaypointers[i].transform.position = Vector3.MoveTowards(Cameralocation.transform.position, Locations[i].transform.position, -Distancebetween);
                TheWaypointers[i].transform.position = Vector3.MoveTowards(Cameralocation.transform.position, Locations[i].transform.position, Distancebetween);
                Measuredistance[i] = Vector3.Distance(TheWaypointers[i].transform.position, Locations[i].transform.position) * 3f;
                TheWaypointers[i].transform.Translate(0, 1, 0, Space.World);
                Mathf.RoundToInt(Measuredistance[i]);
                Thedistancemeasures[i].text = Measuredistance[i].ToString() + "Meters";
            }
        }
        public void OnStart()
        {
            Cameralocation = GameObject.Find("MixedRealityCameraParent");
            cameraeyes = GameObject.Find("Cameraeyes").transform.GetChild(0).gameObject;
            scripts = GameObject.Find("TheScripts");
            for (int i = 0; i < Locations.Length; i++)
            {
                Locations[i] = GameObject.Find("3D Buildings/" + scripts.GetComponent<FindThebuildingsagain>().namesoflocations[i] + "/Teleport");
                TheWaypointers[i] = this.gameObject.transform.GetChild(i).gameObject;
                TheWaypointers[i].transform.position = Vector3.MoveTowards(Cameralocation.transform.position, Locations[i].transform.position, -Distancebetween);
            }
        }
    }
}
