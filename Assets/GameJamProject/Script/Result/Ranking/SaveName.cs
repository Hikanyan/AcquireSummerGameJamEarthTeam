using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField = default;

    private void Start()
    {
        _inputField.onEndEdit.AddListener(SavePlayerName);
    }
    
    private void SavePlayerName(string text)
    {
        SaveManager.Instance.GetPlayerName(text);
    }
}
