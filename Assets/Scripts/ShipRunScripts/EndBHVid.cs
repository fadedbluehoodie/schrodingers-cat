using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndBHVideo : MonoBehaviour
{
    public double time;
    public double currentTime;
    // Use this for initialization
    void Start () {
 
    time = GetComponent<VideoPlayer>().clip.length - 0.2f;
    }
 
   
    // Update is called once per frame
    void Update () {
        currentTime = GetComponent<VideoPlayer>().time;
        if (currentTime >= time) {
            PageController.currentIndex = 20;
            SceneManager.LoadScene("Paiges");
        }
    }
}
