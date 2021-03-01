using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollPopup : MonoBehaviour {

    public event Action<int, ScrollItemView> itemShowed = delegate { };
    private const int itemHeight = 150;
    private const int spacing = 8;
    private const int top = 10;
    private const int bottom = 10;

    [SerializeField]
    private ScrollItemView[] _views;

    [SerializeField]
    private RectTransform _content;


    private int count { get; set; }

    private float y;
    private int oldIndex = -1;
    private RectTransform item;



    void Update()
    {
        y = _content.anchoredPosition.y - spacing;

        if (y < 0)
            return;
        var inx = Mathf.FloorToInt(y / (itemHeight + spacing));

        if (oldIndex == inx)
            return;

        //added to end
        if (inx > oldIndex)
        {
            var newInd = inx % _views.Length;
            newInd--;
            if (newInd < 0)
                newInd = _views.Length - 1;
            var id = inx + _views.Length - 1;
            if (id < count)
            {
                item = _views[newInd].GetComponent<RectTransform>();
                var pos = item.anchoredPosition;
                pos.y = -(top + id * spacing + id * itemHeight);
                item.anchoredPosition = pos;
                itemShowed(id, _views[newInd]);
            }
        }
        //added to begin
        else
        {
            var newInd = inx % _views.Length;
            item = _views[newInd].GetComponent<RectTransform>();
            var pos = item.anchoredPosition;
            pos.y = -(top + inx * spacing + inx * itemHeight);
            item.anchoredPosition = pos;
            itemShowed(inx, _views[newInd]);
        }
        oldIndex = inx;
    }

    public void SetData(int _count)
    {
        oldIndex = 0;
        count = _count;
        var h = itemHeight * count * 1f + top + bottom + (count == 0 ? 0 : ((count - 1) * spacing));
        _content.sizeDelta = new Vector2(_content.sizeDelta.x, h);
        var pos = _content.anchoredPosition;
        pos.y = 0;
        _content.anchoredPosition = pos;
        bool showed = false;
        var y = top;
        for (int i = 0; i < _views.Length; i++)
        {
            showed = i < count;
            _views[i].gameObject.SetActive(showed);
            if (showed)
            {
                pos = _views[i].GetComponent<RectTransform>().anchoredPosition;
                pos.y = -y;
                _views[i].GetComponent<RectTransform>().anchoredPosition = pos;
                y += spacing + itemHeight;
                itemShowed(i, _views[i]);
            }
        }
    }

}
