using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] Color32 _hasPackageColour = new Color32 (1,1,1,1);
    [SerializeField] Color32 _noPackageColour = new Color32 (1,1,1,1);
    [SerializeField] float _destroyPackageTimer = 0.2f;
    bool _hasPackage = false;
    SpriteRenderer _spriteRenderer;

    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log(gameObject.name + " Hit Collision Box");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !_hasPackage) 
        {
            Debug.Log(gameObject.name + " Collected Package");
            _hasPackage = true;
            _spriteRenderer.color = _hasPackageColour;
            Destroy(other.gameObject, _destroyPackageTimer);
        } 
        
        if (other.tag == "Customer" && _hasPackage)
        {
            Debug.Log(gameObject.name + " Delivered Package");
            _hasPackage = false;
            _spriteRenderer.color = _noPackageColour;
        }
    }
}
