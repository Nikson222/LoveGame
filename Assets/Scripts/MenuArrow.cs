using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuArrow : MonoBehaviour
{
    [SerializeField] private Animator _menubarAnimator;
    private bool _isUpped = false;
    public void SetBool(string BoolName)
    {
        if (!_isUpped)
        {
            _isUpped = true;
            _menubarAnimator.SetBool(BoolName, _isUpped);
        }
        else
        {
            _isUpped = false;
            _menubarAnimator.SetBool(BoolName, _isUpped);
        }
    }
}
