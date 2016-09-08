using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;
    public AudioClip step4;
    public float timer = 0.25f;

    private AudioClip[] steps;

    void Start()
    {
        steps = new AudioClip[4];
        steps[0] = step1;
        steps[1] = step2;
        steps[2] = step3;
        steps[3] = step4;
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            var grounded = GetComponent<FirstPersonDrifter>().grounded;
            if (grounded && (Input.GetAxis("Horizontal") > 0.25 || Input.GetAxis("Vertical") > 0.25))
            {
                var index = Random.Range(0, 3);
                gameObject.GetComponent<AudioSource>().PlayOneShot(steps[index]);
            }
            timer = Random.Range(0.20f, 0.35f);
        }
	}
}
