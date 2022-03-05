using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _turnSpeed = 300f;
    [SerializeField] float _moveSpeed = 20f;
    [SerializeField] float _slowSpeed = 15f;
    [SerializeField] float _boostSpeed = 30f;

    void Update()
    {
        float _turnAmount = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;
        float _moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -_turnAmount); //rotates object rotation on Z axis
        transform.Translate(0, _moveAmount, 0); //moves object position on Y axis
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Booster")
        {
            _moveSpeed = _boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        _moveSpeed = _slowSpeed;
    }
}
