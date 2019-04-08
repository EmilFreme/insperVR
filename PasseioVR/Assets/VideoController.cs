using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void SkyboxUpdated() {
        if (RenderSettings.skybox.name == "Sala_RV" && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        else {
            videoPlayer.Stop();
        }
    }
}
