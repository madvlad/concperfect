using UnityEngine;
using System.Collections;

public class Conc : MonoBehaviour {
    public AudioClip timerSFX;
    public AudioClip explodeSFX;
	void Start () {
        Invoke("Explode", 4.0f);
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
        Invoke("Destroy", 4.0f);
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
                Debug.Log("Hit player!");
                var receiver = hit.GetComponent<ImpactReceiver>();
                if (receiver)
                {
                    var dir = hit.transform.position - transform.position;
                    var force = Mathf.Clamp(250.0f, 0, 250.0f);
                    receiver.AddImpact(dir, force);
                }
                //hit.GetComponent<Rigidbody>().AddExplosionForce(500.0f, transform.position, 5.0f, 1.0f);
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
