using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.IO;
using System.Linq;
using UnityEngine.Video;
public class LoadAllFromFolder : MonoBehaviour
{

    public RawImage[] rawImage;
    public GameObject Sphere;
    public GameObject turnoffthese;
    public string MovieDestination;
    public string Picdestination;
    VideoPlayer[] videoPlayer = null;
    public Material[] Material;
    int j;
    public void Start()
    {
        /*
         DirectoryInfo Mdir = new DirectoryInfo(@MovieDestination);
         string[] movieformats = new[] { ".mp4", ".mov",".MP4"};
         FileInfo[] Movieinfo = Mdir.GetFiles().Where(f => movieformats.Contains(f.Extension.ToLower())).ToArray();
         //Search for files
         DirectoryInfo dir = new DirectoryInfo(@""+Picdestination+"");
         string[] extensions = new[] { ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".ogg", ".OGG" };
         FileInfo[] info = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();

         //Init Array
         textures = new Texture2D[info.Length];
         videoPlayer = new VideoPlayer[Movieinfo.Length];
         for (int j = 0; j < Movieinfo.Length; j++)
         {

         }
         for (int i = 0; i < info.Length; i++)
         {
             MemoryStream dest = new MemoryStream();

             //Read from each Image File
             using (Stream source = info[i].OpenRead())
             {
                 byte[] buffer = new byte[2048];
                 int bytesRead;
                 while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                 {
                     dest.Write(buffer, 0, bytesRead);
                 }
             }

             byte[] imageBytes = dest.ToArray();

             //Create new Texture2D
             Texture2D tempTexture = new Texture2D(2, 2);

             //Load the Image Byte to Texture2D
             tempTexture.LoadImage(imageBytes);

             //Put the Texture2D to the Array
             textures[i] = tempTexture;
         }
         if (Input.GetKeyDown("down"))
         {
             Sphere.GetComponent<Renderer>().material.SetTexture("_MainTex", textures[1]);
         }
             //Load to Rawmage?
             for (int i = 0; i < info.Length; i++)
         {
             allTheImages[i] = TheParentObject.transform.GetChild(i).gameObject;
             allTheImages[i].SetActive(true);
             rawImage[i].texture = textures[i];
         }
*/
    }
    public void loadimage1(int WorldNum)
    {
        Sphere.GetComponent<Renderer>().material = Material[WorldNum];
    }
    public void loadvideo1(int MovieNum)
    {
        videoPlayer[MovieNum] = Sphere.GetComponent<VideoPlayer>();
    }
}