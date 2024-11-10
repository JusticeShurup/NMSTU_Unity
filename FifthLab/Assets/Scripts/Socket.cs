using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public List<PositionToPlace> positionToPlaces = new();

    public List<PositionToPlace> EmptyPositions => positionToPlaces.Where(g => g.placedGameObject == null).ToList();
    public List<PositionToPlace> FilledPosition => positionToPlaces.Where(g => g.placedGameObject != null).ToList();

    void Start()
    {
        positionToPlaces.AddRange(GetComponentsInChildren<PositionToPlace>());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PutGrabbable(Grabbable grabbable)
    {
        var emptyPositions = EmptyPositions;

        if (emptyPositions.Count == 0) return false;

        EmptyPositions[0].placedGameObject = grabbable;
        grabbable.gameObject.transform.position = emptyPositions[0].placePosition;
        grabbable.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log(EmptyPositions.Count);
        return true;
    }

    public Grabbable TakeGrabbable()
    {
        if (FilledPosition.Count == 0)
        {
            return null;
        }

        Grabbable grabbable = FilledPosition[0].placedGameObject; 
        FilledPosition[0].placedGameObject = null;
        grabbable.GetComponent<Rigidbody>().isKinematic = false;

        return grabbable;
    }

}
