using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class DamageDealer : MonoBehaviour
{
    static private int _damage = 1;
    static public int Damage { get => _damage; }

    private Hearth _tempCurrentHearth;

    public void TakeClickDamage()
    {
        _tempCurrentHearth.GetDamage(_damage);
    }

    private bool CheckTouchMobile()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector3 touchPos = touch.position;
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touchPos);
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                    if (hit.collider != null && hit.collider.CompareTag("Hearth"))
                    {
                        _tempCurrentHearth = hit.collider.GetComponent<Hearth>();
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        return false;
    }
    private bool CheckTouchPC()
    {
        Vector3 touchPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(touchPos);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        print("Click");
        if (hit.collider != null && hit.collider.CompareTag("Hearth"))
        {
            _tempCurrentHearth = hit.collider.GetComponent<Hearth>();
            return true;
        }
        else
            return false;
    }

    private void OnMouseDown()
    {
        if (CheckTouchPC())
            TakeClickDamage();
    }
}
