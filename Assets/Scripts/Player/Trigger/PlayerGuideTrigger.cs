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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _guideTV.SetActive(true);
            StartCoroutine(StopGuide());
        }
    }

    private IEnumerator StopGuide()
    {
        yield return new WaitForSeconds(_coolDown);
        _tvAnimator.SetTrigger(_triggerName);
        Destroy(transform.gameObject);
    }
}
