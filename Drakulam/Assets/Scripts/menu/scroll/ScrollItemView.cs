using System;
using UnityEngine.UI;
using UnityEngine;

public class ScrollItemView : MonoBehaviour {
    [SerializeField]
    private Text nameText;
    public void SetData(string itemName) {
        nameText.text = itemName;
    }

}
