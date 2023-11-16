using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string interactableTag = "Interactable";
    //[SerializeField] private
    //[SerializeField] private

    public bool canInteract;
    [SerializeField]
    public Interactable interactable;
    [SerializeField]
    public Sprite interactableSprite;
    

    [SerializeField]
    private float interactDistance = 200f;
    [SerializeField]
    private Image interactImage;

    void Start()
    {
        canInteract = true;
    }


    private void Update()
    {
        LookAt();
    }

    void LookAt()
    {
        if (canInteract)
        {
            var inspectRaycast = RaycastManager.instance.CastRay(References.cam.transform.position, References.cam.transform.forward, interactDistance);
            if (inspectRaycast.Item1)
            {
                if (inspectRaycast.Item2.transform.CompareTag(interactableTag))
                {
                    interactable = inspectRaycast.Item2.transform.GetComponent<Interactable>();
                    interactImage.sprite = interactable.interactableSprite;
                    interactImage.color = new Color32(255, 255, 225, 255);
                }
                else
                {
                    interactImage.color = new Color32(255, 255, 225, 0);
                }
            }
            else
            {
                interactImage.color = new Color32(255, 255, 225, 0);
            }
        }
        else
        {
            interactImage.color = new Color32(255, 255, 225, 0);
        }
    }

    public void Interact()
    {
        if (canInteract)
        {
            var inspectRaycast = RaycastManager.instance.CastRay(References.cam.transform.position, References.cam.transform.forward, interactDistance);
            if (inspectRaycast.Item1)
            {
                inspectRaycast.Item2.transform.GetComponent<Interactable>().Interact();
            }
        }
    }



}
