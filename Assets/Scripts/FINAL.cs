using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINAL : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;
    private PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (transform.position.x >= teleportPoint.position.x)
        {
            this.transform.position = new Vector3(468.6271f, 49.79527f, 644.1874f);
            transform.Rotate(0.0f, -180.0f, 0.0f, Space.Self);
            _playerMove.enabled = false;
        }
    }
}
