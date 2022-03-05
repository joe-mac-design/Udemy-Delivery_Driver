using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Camera position = Players position
    [SerializeField] GameObject _player;

    void LateUpdate()
    {
        transform.position = _player.transform.position + new Vector3 (0,0,-10f); 
    }
}
