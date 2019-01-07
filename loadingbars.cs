using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace HoloToolkit.Unity.Examples
{
    public class loadingbars : MonoBehaviour
    {
        public bool startLoadingthebars;
        public GameObject TheCamera;
        public Text thebars;
        public Renderer thespheresrenderer;
        public Color alphalevels;
        public Color betalevels;
        public Color imagealpha = new Color(1f, 1f, 1f, 1f);
        public float counterdown = 1;
        public float counterdown1 = 1;
        public float counterdown2 = 1;
        public GameObject changescenescripts;
        public string[] thebuildings;
        public Image[] LoadingCircle;
        public bool coolingdown;
        public string thename;
        public GameObject sphere;
        public GameObject eyes;
        public bool onlyonce;
        public bool onlytwice;
        public bool loadnextscene = true;
        public Vector3 zeroposition;
        Scene currentScene;
        public GameObject enabletheloadingcircle;
        // Use this for initialization
        void Start()
        {
            TheCamera = GameObject.Find("MixedRealityCameraParent");
            onlyonce = true;
            alphalevels = thespheresrenderer.material.color;
            changescenescripts = GameObject.Find("TheScripts");
            startLoadingthebars = true;
        }

        // Update is called once per frame
        void Update()
        {
            currentScene = SceneManager.GetActiveScene();
            Debug.Log(currentScene.name);
            /*
            for (int i = 0; i < thebuildings.Length; i++)
            {
                if (currentScene.name == thebuildings[i])
                {
                    thename = "";
                }
            }*/

            if (currentScene.name == "WithLocations")
            {
                thename = changescenescripts.transform.GetChild(0).gameObject.GetComponent<ObjectInWorld>().thename;
            }
            else { thename = "WithLocations"; }
            if (currentScene.name == thename)
            {
                TheCamera.transform.position = zeroposition;
                eyes.transform.GetChild(0).gameObject.SetActive(false);
                alphalevels.a += 0.2f * Time.deltaTime;
                thespheresrenderer.material.color = alphalevels;
                betalevels.a -= 0.2f * Time.deltaTime;
                enabletheloadingcircle.GetComponent<CanvasGroup>().alpha = betalevels.a;

                //enabletheloadingcircle.transform.GetChild(0).gameObject.SetActive(false);
                if (thespheresrenderer.material.color.a >= 1f)
                {
                    LoadingCircle[2].gameObject.SetActive(false);

                    sphere.SetActive(false);
                    startLoadingthebars = true;
                    onlyonce = true;
                    //  enabletheloadingcircle.SetActive(false);
                    // enabletheloadingcircle.transform.GetChild(0).gameObject.SetActive(true);
                    loadnextscene = true;
                }

            }
            if (currentScene.name != thename)
            {
                alphalevels.a -= 0.2f * Time.deltaTime;
                thespheresrenderer.material.color = alphalevels;
                betalevels.a += 0.2f * Time.deltaTime;
                enabletheloadingcircle.GetComponent<CanvasGroup>().alpha = betalevels.a ;
            }
            if (thespheresrenderer.material.color.a <= 0f)
            {
                LoadingCircle[2].gameObject.SetActive(true);
                LoadingCircle[1].fillAmount = 1f;
                //enabletheloadingcircle.SetActive(true);

                if (loadnextscene == true)
                {
                    thename = changescenescripts.transform.GetChild(0).gameObject.GetComponent<ObjectInWorld>().thename;
                    SceneManager.LoadSceneAsync(thename);
                    loadnextscene = false;

                }
                thespheresrenderer.material.color = alphalevels;
                if (onlytwice == true && onlyonce == true)
                {
                    LoadingCircle[1].fillAmount = 0f;
                    counterdown -= Time.deltaTime;
                    if (counterdown <= 0f)
                    {
                        LoadingCircle[1].fillAmount = 0.225f;
                        counterdown1 -= Time.deltaTime;
                        if (counterdown1 <= 0f)
                        {
                            LoadingCircle[1].fillAmount = 0.455f;
                            counterdown2 -= Time.deltaTime;
                            if (counterdown2 <= 0f)
                            {
                                LoadingCircle[1].fillAmount = 1f;
                                onlytwice = false;
                                onlyonce = false;
                                counterdown = 1f;
                                counterdown1 = 1f;
                                counterdown2 = 1f;
                            }
                        }
                    }

                }
                if (onlytwice == false)
                {
                    imagealpha.a -= 0.3f * Time.deltaTime;
                    LoadingCircle[0].color = imagealpha;

                }
                if (LoadingCircle[0].color.a <= 0f)
                {
                    onlytwice = true;
                }
                if (onlytwice == true)
                {
                    imagealpha.a += 0.3f * Time.deltaTime;
                    LoadingCircle[0].color = imagealpha;
                }
                if (LoadingCircle[0].color.a <= 1f)
                {
                    onlyonce = true;
                }
                /*
                                if (LoadingCircle[0].fillAmount >= 1f)
                                {
                                    onlytwice = true;
                                    Debug.Log(false);
                                    LoadingCircle[0].fillClockwise = false;

                                }//0,225 0,455 1
                                if (onlytwice == false)
                                {
                                    LoadingCircle[0].fillAmount -= 0.3f * Time.deltaTime;
                                }
                                if (onlyonce == true)
                                {
                                    LoadingCircle[0].fillAmount += 0.3f * Time.deltaTime;
                                }
                                // thebars.text = "";



                                if (LoadingCircle[0].fillAmount <= 0f)
                                {
                                    onlyonce = true;
                                    Debug.Log(false);
                                    LoadingCircle[0].fillClockwise = true;
                                }
                                */

                //   if (onlyonce == false)
                //  {
                //  LoadingCircle[1].transform.Rotate(0, 0, -30 * Time.deltaTime, Space.World);
                //   }
            }
        }

        void startloading()
        {
            startLoadingthebars = true;
        }
    }
}
