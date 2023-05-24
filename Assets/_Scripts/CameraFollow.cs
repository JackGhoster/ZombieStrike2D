using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _followTarget;
    private void LateUpdate()
    {
        var pos = new Vector3(_followTarget.position.x, _followTarget.position.y, -10);
        transform.position = pos;
    }
}
