using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class AbstractCube : MonoBehaviour
{
    protected void DestroyCube()
    {
        EventBus.Instance.OnChanchedScore?.Invoke();
        Destroy(this.gameObject);
    }
}
