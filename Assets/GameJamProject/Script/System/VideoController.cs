using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoController : MonoBehaviour
{
    /// <summary>
    /// §Œä‚·‚éVideo Player‚ÌƒŠƒXƒg
    /// </summary>
    [SerializeField]
    private List<VideoPlayer> playerList;
    /// <summary>
    /// Ä¶
    /// </summary>
    public void Play()
    {
        foreach (VideoPlayer player in playerList)
        {
            if (!player.isPlaying)
            {
                player.Play();
            }
        }
    }
    /// <summary>
    /// ˆê’â~
    /// </summary>
    public void Pause()
    {
        foreach (VideoPlayer player in playerList)
        {
            if (player.isPlaying)
            {
                player.Pause();
            }
        }
    }
    /// <summary>
    /// ’â~
    /// </summary>
    public void Stop()
    {
        foreach (VideoPlayer player in playerList)
        {
            player.Stop();
        }
    }
}