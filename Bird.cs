using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 233f;

    private bool isDead = false;
    private Rigidbody2D rbd2;
    private Animator Anim;

    Quaternion downRotation;
    Quaternion forwartRotation;
    private float tiltSmooth = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwartRotation = Quaternion.Euler(0, 0, 35);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rbd2.velocity = Vector2.zero;
                transform.rotation = forwartRotation;
                rbd2.AddForce(new Vector2(0, upForce));
                Anim.SetTrigger("Flap");
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth
                * Time.deltaTime);
        }

       
        

    }

    void OnCollisionEnter2D()
    {
        rbd2.velocity = Vector2.zero;
        isDead = true;
        Anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }

}
