using System.Collections;
using UnityEngine;

public class EnemyMusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackClip;
    public AudioClip chaseClip;
    public AudioClip deathClip;
    public AudioClip hitClip;

    // Called when the enemy attacks
    public void PlayAttackMusic()
    {
        // Play the attack music as a one-shot
        audioSource.PlayOneShot(attackClip);
    }

    // Called when the enemy chases the player
    public void PlayChaseMusic()
    {
        StartCoroutine(PlayClipAndWait(chaseClip));
    }

    // Called when the enemy dies
    public void PlayDeathMusic()
    {
        if (deathClip != null)
        {
            StartCoroutine(PlayClipAndWait(deathClip));
            Debug.Log("Music found");
        }
        else
        {
            Debug.Log("No music");
        }
    }

    // Called when the enemy hits the player
    public void PlayHitMusic()
    {
        StartCoroutine(PlayClipAndWait(hitClip));
    }

    // Coroutine to play audio clip and wait for it to finish
    private IEnumerator PlayClipAndWait(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
    }
}
