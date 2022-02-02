using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _icon;
    private Transform _dragParent;
    private Transform _originalParent;

    public void Init(Transform dragParent)
    {
        _dragParent = dragParent;
        _originalParent = transform.parent;
    }
    
    public void Render(Item item)
    { 
        _icon.sprite = item.UIIcon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _dragParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int clIndex = 0;

        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {
            if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) <
                Vector3.Distance(transform.position, _originalParent.GetChild(clIndex).position))
            {
                clIndex = 1;
            } ;
        }

        transform.parent = _originalParent;
        transform.SetSiblingIndex(clIndex);
    }
}
