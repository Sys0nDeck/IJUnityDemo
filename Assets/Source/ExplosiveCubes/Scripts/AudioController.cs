using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AudioClip clip = _audioSource.clip;
        _audioSource.PlayOneShot(clip, 0.3f);
    }
}
