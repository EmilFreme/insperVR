using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void SkyboxUpdated() {
        if (RenderSettings.skybox.name == this.name && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        else {
            videoPlayer.Stop();
        }
    }
}
