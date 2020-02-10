using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool move = false;
    public Rigidbody2D rb;
    public Animator legsAnim;
    Vector3 trans;
    public float speed = 10.0f;
    private float x = 0;
    private float y = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        legsAnim = transform.GetChild(2).GetComponent<Animator>();
    }
    void FixedUpdate() {
        rb.MovePosition(transform.position - trans * speed * Time.fixedDeltaTime);
    }
    void Update()
    {
        // position
        if (Input.GetKey(KeyCode.A))
            x -= 1f;
        if (Input.GetKey(KeyCode.D))
            x += 1f;
        if (Input.GetKey(KeyCode.W))
            y += 1f;
        if (Input.GetKey(KeyCode.S))
            y -= 1f;
        if (x != 0 || y != 0)
            move = true;
        else
            move = false;
        trans = new Vector3(x, y, 0);
        x = 0;
        y = 0;
        
        // rotation
        legsAnim.SetBool("moving", move);
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
