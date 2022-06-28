using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CapsuleTouchScript movement;

    public AudioClip[] deathClip;
    private AudioSource source;

    public ParticleSystem deathParticles;

    private void Start()
    {
        source = GameManager.Instance.audioSource;
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.layer == 7)    // mustard layer
        {
            Destroy(collisionInfo.gameObject);
        }
        else if (collisionInfo.gameObject.layer == 8)    // fork layer
        {
            movement.enabled = false;

            Time.timeScale = 0.5f;

            deathParticles = collisionInfo.GetComponent<ParticleSystem>();

            deathParticles.Play();

            //Camera.main.transform.Translate(new Vector3(0, 0, 5 * Time.deltaTime), Space.World);
            

            if (!GameManager.Instance.deathSoundPlayed)
            {
                int randomSound = Random.Range(0, deathClip.Length);
                source.PlayOneShot(deathClip[randomSound]);

                GameManager.Instance.deathSoundPlayed = true;
            }

            GameManager.Instance.EndGame();
        }
    }
}
