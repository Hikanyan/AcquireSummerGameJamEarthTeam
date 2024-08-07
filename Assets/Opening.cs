using System;
using System.Collections;
using System.Collections.Generic;
using GameJamProject.Audio;
using UnityEngine;

public class Opening : MonoBehaviour
{
    [SerializeField] private string _bgmName = default;

    private void Start()
    {
        AudioManager.Instance.PlayBGM(_bgmName);
    }
}