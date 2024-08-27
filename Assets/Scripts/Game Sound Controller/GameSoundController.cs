using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundController : MonoBehaviour
{
    public static GameSoundController instance;

    private AudioSource audioSouce;
    [Header("Sound Car Draving")]
    [SerializeField] private AudioClip carDravingSound;
    [SerializeField][Range(0f, 1f)] private float carDravingVolume;

    [Header("Sound Buttons")]
    [SerializeField] private AudioClip buttonSound;
    [SerializeField][Range(0f, 1f)] private float buttonVolume;

    [Header("Sound Spawner Box")]
    [SerializeField] private AudioClip spawnerSound;
    [SerializeField][Range(0f, 1f)] private float spawnerVolume;

    [Header("Sound PickUp Box")]
    [SerializeField] private AudioClip pickUpBoxSound;
    [SerializeField][Range(0f, 1f)] private float pickUpBoxVolume;

    [Header("Sound Delivery Box")]
    [SerializeField] private AudioClip deliveryBoxSound;
    [SerializeField][Range(0f, 1f)] private float deliveryBoxVolume;

    [Header("Sound Not Delivery Box")]
    [SerializeField] private AudioClip notDeliveryBoxSound;
    [SerializeField][Range(0f, 1f)] private float notDeliveryBoxVolume;

    [Header("Sound Positive Score")]
    [SerializeField] private AudioClip positiveScore;
    [SerializeField][Range(0f, 1f)] private float positiveScoreVolume;

    [Header("Sound Negative Score")]
    [SerializeField] private AudioClip negativeScore;
    [SerializeField][Range(0f, 1f)] private float negativeScoreVolume;

    [Header("Sound Car Hit")]
    [SerializeField] private AudioClip hitCarSound;
    [SerializeField][Range(0f, 1f)] private float hitCarVolume;

    [Header("Sound Applauses")]
    [SerializeField] private AudioClip applausesSound;
    [SerializeField][Range(0f, 1f)] private float applausesVolume;

    [Header("Sound Boos")]
    [SerializeField] private AudioClip boosSound;
    [SerializeField][Range(0f, 1f)] private float boosVolume;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);   
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSouce = GetComponent<AudioSource>();
    }

    public void CarDravingSound(bool _loop)
    {
        SoundController(carDravingSound, carDravingVolume, _loop);
    }

    public void ButtonSound()
    {
        SoundController(buttonSound, buttonVolume, false);
    }

    public void SpawnerSound()
    {
        SoundController(spawnerSound, spawnerVolume, false);
    }

    public void PickUpBoxSound()
    {
        SoundController(pickUpBoxSound, pickUpBoxVolume, false);
    }

    public void DeliveryBoxSound()
    {
        SoundController(deliveryBoxSound, deliveryBoxVolume, false);
    }

    public void NotDeliveryBoxSound()
    {
        SoundController(notDeliveryBoxSound, notDeliveryBoxVolume, false);
    }

    public void EndOfGameScorePositive()
    {
        SoundController(positiveScore, positiveScoreVolume, false);
    }

    public void EndOfGameScoreNegative()
    {
        SoundController(negativeScore, negativeScoreVolume, false);

    }

    public void HitCarSound()
    {
        SoundController(hitCarSound, hitCarVolume, false);
    }

    public void ApplausesSound()
    {
        SoundController(applausesSound, applausesVolume, false);
    }

    public void BoosSounds()
    {
        SoundController(boosSound, boosVolume, false);

    }

    private void SoundController(AudioClip _audioClip, float _clipVolume, bool _loop)
    {
        if (_audioClip != null)
        {
            audioSouce.clip = _audioClip;
            audioSouce.volume = _clipVolume;
            audioSouce.loop = _loop;
            audioSouce.Play();
        }
    }
}
