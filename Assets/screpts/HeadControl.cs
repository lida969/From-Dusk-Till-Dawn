using UnityEngine;

public class HeadControl : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _power;

    private const string WEAPON_TAG = "Weapon";
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(WEAPON_TAG))
        {
            return;
        }
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up*_power);
    }
}
