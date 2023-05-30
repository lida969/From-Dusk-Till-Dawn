using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINAL : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;
    [SerializeField] Transform menuPoint;
    private PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (transform.position.x >= teleportPoint.position.x)
        {
            transform.position = menuPoint.position;
            GetComponent<ShootingLeftHand>().enabled = false;
            GetComponent<ShootingRightHand>().enabled = false;
            transform.Rotate(0.0f, -180.0f, 0.0f, Space.Self);
            _playerMove.enabled = false;
            
        }
    }
}
