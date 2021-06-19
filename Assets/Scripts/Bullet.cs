using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody m_Rigidbody;

    public void Shoot(float power)
    {
        m_Rigidbody.AddRelativeForce(Vector3.forward * m_Rigidbody.mass * power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        //m_Rigidbody.isKinematic = true;
    }


}
