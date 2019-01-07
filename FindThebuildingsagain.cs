using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace HoloToolkit.Unity.Examples
{
    public class FindThebuildingsagain : MonoBehaviour
    {
        public string[] namesoflocations;
        public bool once = true;
        public Text Locations;
        public GameObject Thecanvas;
        // Use this for initialization
        void Awake()
        {
            Thecanvas = GameObject.Find("MenuSelection");
            for (int i = 0; i < namesoflocations.Length; i++)
            {
                if (i < 10)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += i + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 11)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "Q" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 12)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "W" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 13)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "E" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 14)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "R" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 15)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "T" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 16)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "Y" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 17)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "U" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 18)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "I" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 19)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "O" + ": " + namesoflocations[i] + "\n";
                }
                else if (i == 20)
                {
                    namesoflocations[i] = GameObject.Find("3D Buildings").transform.GetChild(i).name;
                    Locations.text += "P" + ": " + namesoflocations[i] + "\n";
                }
            }
            /* if (once == true)
             {
                 Dictionary<string, int> namesoflocations = new Dictionary<string, int>();
                 namesoflocations.Add("University", 0);
                 namesoflocations.Add("Tower", 1);
                 namesoflocations.Add("BlueWaterArena", 2);
                 namesoflocations.Add("Train Station", 3);
                 namesoflocations.Add("Church", 4);
                 namesoflocations.Add("EsbjergHarbour", 5);
                 namesoflocations.Add("Hedelundvej", 6);
                 namesoflocations.Add("MusicHouse", 7);
                 namesoflocations.Add("Gaardskollegie", 8);
                 namesoflocations.Add("Kollegium", 9);
                 namesoflocations.Add("4WhiteMen", 10);
                 namesoflocations.Add("Park", 11);
                 once = false;
             }*/
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (Thecanvas.activeSelf == false)
                {
                    Thecanvas.SetActive(true);
                }
                else
                {
                    Thecanvas.SetActive(false);
                }
            }
            if ("WithLocations" == SceneManager.GetActiveScene().name)
            {
                if (once == true)
                {
                    for (int j = 0; j < namesoflocations.Length; j++)
                    {
                        namesoflocations[j] = GameObject.Find("Scripts").GetComponent<ObjectInWorld>().interactables[j].name;
                        once = false;
                    }
                }
            }
        }
    }
}
