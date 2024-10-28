using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string videoName;
    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }
    

    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
