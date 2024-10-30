using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    [SerializeField] private InteractableHelper _currentInteractableHelper = null;
    
    private void Start()
    {
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawLine(ray.GetPoint(0), ray.GetPoint(2));
        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.collider.TryGetComponent<InteractableHelper>(out var interactableHelper))
            {
                if (_currentInteractableHelper != interactableHelper)
                {
                    _currentInteractableHelper?.Hide();
                    _currentInteractableHelper = interactableHelper;
                    _currentInteractableHelper.Show();
                }
            }
        }
        else
        {
            _currentInteractableHelper?.Hide();
            _currentInteractableHelper = null;
        }
    }

}