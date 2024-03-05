using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{


    private const float Speed = 8;
    private const float JumpForce = 13;

    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private ParticleSystem particleSystem;

    private bool _isGrounded;


    [SerializeField] private Transform groundCheckObject;
    [SerializeField] private LayerMask layerMask;



    // Update is called once per frame
    void Update()
    {
        if(!Global.InPlayMode) return;

        _isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, 0.1f, layerMask);


        transform.Translate(new Vector2(x: Speed * Time.deltaTime, y:0));
        Jump();

        if(_isGrounded)
        {
            particleSystem.Play();
        } 
        else
        {
            particleSystem.Stop();
        }

        ParticleSystemSetSpeed();


    }


   
    private void ParticleSystemSetSpeed()
    {

        var velocityOverLifeTime = particleSystem.velocityOverLifetime;
        velocityOverLifeTime.x = rigidbody2D.velocity.x;

    }

    private void Jump() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

}
