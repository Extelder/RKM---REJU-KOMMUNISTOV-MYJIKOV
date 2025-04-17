using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    [SerializeField] private GameObject _rus;
    [SerializeField] private GameObject _eng;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(ChaningDisclaimersAndScene());
    }

    private IEnumerator ChaningDisclaimersAndScene()
    {
        yield return new WaitForSeconds(_delay);
        _rus.SetActive(false);
        _eng.SetActive(true);
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}