using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler
{
    public event UnityAction deltaChange;

    //Detect current clicks on the GameObject (the one with the script attached)

    private Collider2D _c2d;



    private void OnEnable()
    {
        deltaChange += onDeltaChange;
    }

    private void OnDisable()
    {
        deltaChange -= onDeltaChange;
    }


    private void Start()
    {
        _c2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        deltaChange.Invoke();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
     
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData + "No longer being clicked");
        deltaChange.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData + "No longer being clicked");
        deltaChange.Invoke();
    }



    private void onDeltaChange() {

        Debug.Log("Тут событие");

    }


}


