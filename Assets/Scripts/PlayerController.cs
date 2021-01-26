using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //particles en audio
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    //variables
    private Rigidbody playerRb;
    public float JumpForce;
    public float GravityModifier;
    public bool IsOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        //alle components binnenhalen
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //jump dingen
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checken voor ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirtParticle.Play();
        }
        //collision met een obstacle
        else if (collision.gameObject.CompareTag("Object"))
        {
            gameOver = true;
            Debug.Log("game over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
