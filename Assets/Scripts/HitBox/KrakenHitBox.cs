using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KrakenHitBox : HitBox
{
    [SerializeField] private Transform _krakenTentacle;
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _durations;
    [SerializeField] private ParticleSystem _bloodParticle;
    [SerializeField] private AudioSource _krakenSound;
    [SerializeField] private AudioClip _krakenHurtClip;

    private Tween _scaleTween;
    public override void Hit(float damage)
    {
        base.Hit(damage);
        _scaleTween = _krakenTentacle.DOScale(_target, _durations);
        _krakenSound.clip = _krakenHurtClip;
        _krakenSound.Play();
        //_bloodParticle.Play();
    }
    
    private void OnDisable()
    {
        _scaleTween?.Kill();
    }
}
