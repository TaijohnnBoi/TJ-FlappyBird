using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour { 

    public float upforce = 200f;

    private bool IsDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    AudioSource audioSource;
    public AudioClip flapSound;
    public AudioClip dieSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead == false)
        {
            if (Input.GetMouseButtonDown (0))
            {

                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2 (0, upforce));
                anim.SetTrigger("Flap");
                PlaySound(flapSound);

            }
        }
    }

    void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        IsDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
        PlaySound(dieSound);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
}
