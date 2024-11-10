using UnityEngine;

public class PositionToPlace : MonoBehaviour
{
    public Vector3 placePosition;
    public Grabbable placedGameObject = null;

    private void Start()
    {
        placePosition = transform.position;
    }
}
