using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    [SerializeField] private InteractableHelper _currentInteractableHelper = null;
    [SerializeField] private Grabbable _currentGrabbableSelect;
    [SerializeField] private Grabbable _currentGrabbableGrabed;
    [SerializeField] private SpringJoint _springJoint;

    private void Start()
    {
        _springJoint = Camera.main.GetComponentInChildren<SpringJoint>();
    }

    private void Update()
    {
        if (_currentGrabbableGrabed != null && Input.GetKeyDown(KeyCode.E))
        {
            _springJoint.connectedBody = null;
            _currentGrabbableGrabed = null;
        }

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
            else if (hit.collider.TryGetComponent<Grabbable>(out var grabbable))
            {
                if (Input.GetKeyDown(KeyCode.E) && _currentGrabbableGrabed == null)
                {
                    var grabbableRigidbody = grabbable.GetComponent<Rigidbody>();
                    _springJoint.connectedBody = grabbableRigidbody;
                    _springJoint.gameObject.transform.position = grabbableRigidbody.gameObject.transform.position;
                    _currentGrabbableGrabed = grabbable;
                    grabbableRigidbody.drag = 15;
                }
                grabbable.GetComponent<MeshRenderer>().material.color = Color.yellow;
                _currentGrabbableSelect = grabbable;
            }
            else if (hit.collider.TryGetComponent<Socket>(out var socket))
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (_currentGrabbableGrabed)
                    {
                        if (socket.PutGrabbable(_currentGrabbableGrabed))
                        {
                            _springJoint.connectedBody = null;
                            _currentGrabbableGrabed = null;
                        }
                    }
                    else
                    {
                        var tookGrabbable = socket.TakeGrabbable();
                        if (tookGrabbable != null)
                        {
                            var grabbableRigidbody = tookGrabbable.GetComponent<Rigidbody>();
                            _springJoint.connectedBody = grabbableRigidbody;
                            _springJoint.gameObject.transform.position = grabbableRigidbody.gameObject.transform.position;
                            _currentGrabbableGrabed = tookGrabbable;
                            grabbableRigidbody.drag = 15;
                        }
                    }
                }
            }
            else if (hit.collider.TryGetComponent<RadioController>(out var radioController))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (radioController.audioSource.isPlaying)
                    {
                        radioController.audioSource.Stop();
                    }
                    else
                    {
                        radioController.audioSource.Play();
                    }
                }
            }
            else 
            {
                _currentInteractableHelper?.Hide();
                _currentInteractableHelper = null;
                if (_currentGrabbableSelect != null) _currentGrabbableSelect.GetComponent<MeshRenderer>().material.color = _currentGrabbableSelect.standartColor;
                _currentGrabbableSelect = null;
            }

        }
        else
        {
            _currentInteractableHelper?.Hide();
            _currentInteractableHelper = null;
            if (_currentGrabbableSelect != null) _currentGrabbableSelect.GetComponent<MeshRenderer>().material.color = _currentGrabbableSelect.standartColor;
            _currentGrabbableSelect = null;
        }

    }

}