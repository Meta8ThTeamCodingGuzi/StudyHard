using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public LayerMask targetLayer;

    private Renderer childRenderer;

    private Tweener jumpTween;
    private void Awake()
    {
        childRenderer = GetComponentInChildren<Renderer>();
        childRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, targetLayer))
            {
                transform.position = hit.point;
                childRenderer.enabled = true;
                if (jumpTween != null)
                {
                    jumpTween.Complete();
                }
                childRenderer.enabled = true;

                jumpTween = childRenderer.transform.DOPunchScale(Vector3.up * 35f, 0.5f)
                    .OnComplete(() =>childRenderer.enabled = false)
                    .SetEase(Ease.Flash);
            }
        }
    }

    private IEnumerator HideAfterJump()
    {
        yield return new WaitForSeconds(0.5f);
        childRenderer.enabled = false;
    }
}
