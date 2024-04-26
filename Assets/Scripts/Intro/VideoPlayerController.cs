using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    // Reference to the UI button for play
    public Button playButton;

    // Reference to the UI button for pause
    public Button pauseButton;

    // Reference to the UI button for restart
    public Button restartButton;

    // Reference to the VideoPlayer component
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // Add listener to the play button
        playButton.onClick.AddListener(PlayVideo);

        // Add listener to the pause button
        pauseButton.onClick.AddListener(PauseVideo);

        // Add listener to the restart button
        restartButton.onClick.AddListener(RestartVideo);
    }

    // Function to play the video
    void PlayVideo()
    {
        // Check if the video player is not null and the video is ready
        if (videoPlayer != null && videoPlayer.isPrepared)
        {
            // Play the video
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("VideoPlayer is not set or video is not prepared.");
        }
    }

    // Function to pause the video
    void PauseVideo()
    {
        // Check if the video player is not null and is playing
        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            // Pause the video
            videoPlayer.Pause();
        }
        else
        {
            Debug.LogWarning("VideoPlayer is not set or video is not playing.");
        }
    }

    // Function to restart the video
    void RestartVideo()
    {
        // Check if the video player is not null
        if (videoPlayer != null)
        {
            // Stop the video to reset it
            videoPlayer.Stop();

            // Play the video from the beginning
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("VideoPlayer is not set.");
        }
    }
}


