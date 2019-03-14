using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public bool playerInputEnabled = false;

    private Vector3 _moveAmount;
    private Rigidbody _rb;
    //private Animator anim;


    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerInputEnabled) {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _moveAmount = moveInput.normalized * speed;
        }
    }

    private void FixedUpdate() {
        _rb.MovePosition(_rb.position + _moveAmount * Time.fixedDeltaTime);
    }
}
