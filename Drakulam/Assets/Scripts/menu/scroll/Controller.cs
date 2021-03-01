using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] 
    private ScrollPopup _popup;

    // Use this for initialization
    void Start()
    {
        _popup.itemShowed += (index, view) => {
            view.SetData("item " + index);
        };
        _popup.SetData(100);
    }

}
