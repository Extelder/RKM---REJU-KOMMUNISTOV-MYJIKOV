using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Windows.WebCam;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _video;
    public void VideoPlay()
    {
        _video.Play();
    }
}
