using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.AI;

public class GraphicRaycasterTest : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler , IBeginDragHandler , IEndDragHandler, IDragHandler
{
    //�巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        EventSystemTestManager.instance.text.text = name;
    }
    //�巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition += eventData.delta; 
        //���� �����Ӱ� ���� �������� ������ ��ġ ���� (�̵���)
    }
    //�巡�� �Ϸ�
    public void OnEndDrag(PointerEventData eventData)
    {
        EventSystemTestManager.instance.text.text = "nothing";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Mouse Over");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Mouse Exit");
    }
}
