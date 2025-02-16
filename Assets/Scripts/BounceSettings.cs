using UnityEngine;

public class BounceSettings : MonoBehaviour
{
    [SerializeField] private float bounceForce;

    public float BounceForce => bounceForce;

    public void SetBounceForce(float force)
    {
        bounceForce = force;
    }
} 