using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _loadingScreen;
    [SerializeField] private TMP_Text _loadingText;


    private void Start()
    {
        _loadingText = GetComponentInChildren<TMP_Text>();
        _loadingScreen = GetComponent<Image>();

        StartCoroutine(LoadingScreenImage());
    }

    IEnumerator LoadingScreenImage()
    {
        yield return new WaitForSeconds(2.5f);
        yield return new WaitForEndOfFrame();

        _loadingText.enabled = false;
        _loadingScreen.enabled = false;

    }

}   
