using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private GameGuiController gameGuiController;
    private float speed;
    [SerializeField] private bool isMovingToward;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float normalSpeedB;
    [SerializeField] private ParticleSystem[] hitCarEffect;
    private AudioSource audioSource;
    [SerializeField] private AudioClip speedSound;
    [SerializeField] private float speedVolume;
    private bool isPlaying;



    public bool IsMovingToward
    {
        get { return isMovingToward; }
        set { isMovingToward = value; }
    }


    private void Awake()
    {
        gameGuiController = FindObjectOfType<GameGuiController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameGuiController.GetIsOver())
        {
            PlayerMoviment();

            GetCarSound();
        }

        

        VolumeController();
    }

    private void PlayerMoviment()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            speed = normalSpeed;
            isMovingToward = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speed = 0;

            isMovingToward = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = -normalSpeedB;
            speed = Mathf.Clamp(speed, -normalSpeedB, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speed = 0;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        transform.Rotate(new Vector3(0, horizontal * 1.1f, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if(other.gameObject.CompareTag("Obstacle"))
            {
                for(int i = 0; i < hitCarEffect.Length; i++)
                {
                    hitCarEffect[i].Play();
                }
            }
        }
    }

    private void VolumeController()
    {
        if (isMovingToward)
        {
            speedVolume = Mathf.Lerp(speedVolume, 0.2f, 0.1f);
            if (Mathf.Abs(speedVolume - 0.2f) < 0.01f)
            {
                speedVolume = 0.2f;
            }
        }
        else
        {
            speedVolume = Mathf.Lerp(speedVolume, 0f, 0.1f);
            if (Mathf.Abs(speedVolume - 0f) < 0.01f)
            {
                speedVolume = 0f;
            }
        }

        speedVolume = Mathf.Clamp(speedVolume, 0f, 0.2f);
    }

    private void GetCarSound()
    {
        audioSource.volume = speedVolume;

        if (!isPlaying)
        {
            audioSource.clip = speedSound;
            audioSource.loop = true;
            audioSource.Play();
            isPlaying = true;
        }
    }

}
