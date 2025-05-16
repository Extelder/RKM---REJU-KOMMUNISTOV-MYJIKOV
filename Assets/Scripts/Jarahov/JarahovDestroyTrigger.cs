using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JarahovDestroyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _jarahov;
    [SerializeField] private TextMeshProUGUI _jarahovPopUp;
    [SerializeField] private MegaBeatifulPopUp _megaBeatifulPopUp;
    [SerializeField] private string _jarahovPopUpText;
    [SerializeField] private float _cooldown;
    [SerializeField] private Animator _elevatorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<JarahovInteractable>(out JarahovInteractable jarahovInteractable))
        {
            _elevatorAnimator.SetBool("Open", true);
            Destroy(_jarahov);
            StartCoroutine(_megaBeatifulPopUp.EbanutiString(_jarahovPopUpText, _jarahovPopUp, _cooldown));
        }
    }
}
