using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoController : MonoBehaviour
{
    /// <summary>
    /// ���䂷��Video Player�̃��X�g
    /// </summary>
    [SerializeField]
    private List<VideoPlayer> playerList;
    /// <summary>
    /// �Đ�
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
    /// �ꎞ��~
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
    /// ��~
    /// </summary>
    public void Stop()
    {
        foreach (VideoPlayer player in playerList)
        {
            player.Stop();
        }
    }
}