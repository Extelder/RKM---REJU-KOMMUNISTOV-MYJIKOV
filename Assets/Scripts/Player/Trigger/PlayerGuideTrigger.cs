using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class PlayerGuideTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _guideTV;
    [SerializeField] private Animator _tvAnimator;
    [SerializeField] private string _triggerName;
    [SerializeField] private float _coolDown;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("KppGuideCompleated", 0) == 1)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("KppGuideCompleated", 0) == 1)
        {
            Destroy(this);
        }

        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            if (PlayerPrefs.GetInt("KppGuideCompleated", 0) == 1)
            {
                return;
            }

            _guideTV.SetActive(true);
            StartCoroutine(StopGuide());
        }
    }

    private IEnumerator StopGuide()
    {
        yield return new WaitForSeconds(_coolDown);
        PlayerPrefs.SetInt("KppGuideCompleated", 1);
        _tvAnimator.SetTrigger(_triggerName);
        Destroy(transform.gameObject);
    }
}