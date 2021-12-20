using UnityEngine;

public class StackPartController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private MeshRenderer meshRenderer;
    private Collider collider;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }
    public void Shatter()
    {
        rigidbody.isKinematic = false;
        collider.enabled = false;


        Vector3 forcePoint = transform.parent.position;
        float xPosition = meshRenderer.bounds.center.x;

        Vector3 subDirection = (forcePoint.x - xPosition < 0) ? Vector3.right : Vector3.left;
        Vector3 direction = (Vector3.up * 1.5f + subDirection).normalized;

        float force = Random.Range(5, 15);
        float torque = Random.Range(110, 180);

        rigidbody.AddForceAtPosition(direction * force, forcePoint, ForceMode.Impulse);
        rigidbody.AddTorque(Vector3.left * torque);
        rigidbody.velocity = Vector3.down;
        Invoke("DestroyParent",1);
    }

    private void DestroyParent()
    {
        if(transform.parent!=null)
            Destroy(transform.parent.gameObject);
    }
}
