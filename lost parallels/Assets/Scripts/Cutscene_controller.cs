using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class videocutscene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string level_name;

    private void Start()
    {
        StartVideo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnVideoFinished(videoPlayer);
        }
    }
    private void StartVideo()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoFinished;
    }
    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(level_name);
    }
}
