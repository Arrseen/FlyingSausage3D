using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundScript : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GameManager.Instance.audioSource;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!GameManager.Instance.deathSoundPlayed && collision.gameObject.layer != 10)
        {
            // layer 6 is player and layer 9 is player body
            if (collision.gameObject.layer != 6 && collision.gameObject.layer != 9)
            {
                int randomHitSound = Random.Range(0, GameManager.Instance.hitClip.Length);

                source.PlayOneShot(GameManager.Instance.hitClip[randomHitSound]);

                GameManager.Instance.hitSoundPlayed = true;
            }
        }
        
    }
}
