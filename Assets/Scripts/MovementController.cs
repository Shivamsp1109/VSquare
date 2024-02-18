using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4F;
    // public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5F);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }
}
