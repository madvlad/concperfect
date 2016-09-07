using UnityEngine;
using System.Collections;

public class Conc : MonoBehaviour {
    public AudioClip timerSFX;
    public AudioClip explodeSFX;
    public float timer = 4.0f;
	void Start () {
        Invoke("Explode", timer);
        if (timerSFX)
        {
            if (gameObject.GetComponent<AudioSource>())
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(timerSFX);
            } else
            {
                AudioSource.PlayClipAtPoint(timerSFX, gameObject.transform.position);
            }
        }
	}

    void Explode()
    {
        Invoke("Destroy", timer);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        EnactPush();
        PlayExplosionSound();
    }

    void EnactPush()
    {
        var colliders = Physics.OverlapSphere(transform.position, 5.0f);
        foreach(var hit in colliders)
        {
            if(hit.CompareTag("Player"))
            {
                var receiver = hit.GetComponent<ImpactReceiver>();
                if (receiver)
                {
                    var dir = hit.transform.position - transform.position;
                    var force = Mathf.Clamp(250.0f, 0, 250.0f);
                    receiver.AddImpact(dir, force);
                }
            }
        }
    }

    void PlayExplosionSound()
    {
        if (explodeSFX)
        {
            if (gameObject.GetComponent<AudioSource>())
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(explodeSFX);
            }
            else
            {
                AudioSource.PlayClipAtPoint(explodeSFX, gameObject.transform.position);
            }
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
