using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator playerAnim;
    private Mover playerMoviment;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerMoviment = GetComponentInParent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("isShake", playerMoviment.IsMovingToward);
    }
}
