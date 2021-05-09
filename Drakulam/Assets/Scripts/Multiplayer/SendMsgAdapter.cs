using System;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgAdapter
    : MonoBehaviour
{
    TimeCall _event = null;
    [SerializeField] Text _msgField;

    private void Start()
    {
        if (_msgField != null)
            _msgField.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_event != null && _event.Check())
        {
            _event.Release();
            _event = null;
        }
            
    }
      
    public void ShowMsg(string msg, double time = -1)
    {
        if (_msgField == null)
        {
            Debug.LogWarning("connection message input field is null");
            return;
        }
        _msgField.gameObject.SetActive(true);
        _msgField.text = msg;

        if (time > 0)
            _event = new TimeCall(time, () => { Clear(); });
    }

    public void Clear()
    {
        if (_msgField == null)
        {
            Debug.LogWarning("connection message input field is null");
            return;
        }
        _msgField.text = "";
        _msgField.gameObject.SetActive(false);
    }
}

class TimeCall
{
    double _time;
    double _offset;
    Action _callBack;

    public TimeCall(double offset, Action fun)
    {
        _time = Time.time;
        _offset = offset;
        Action _callBack = fun;
    }

    public bool Check()
    {
        return Time.time <= _time + _offset;
    }

    public void Release()
    {
        _callBack();
    }
}

public class MSG
{
    public static string CONNECTION { get { return "Connection..."; } }
    public static string CON_SUCCESS { get { return "Сonnection completed successfully"; } }
    public static string CON_FAILED { get { return "Connection faild"; } }
    public static string JOIN_ROOM { get { return "Joining a room..."; } }
    public static string JOIN_LOBBY { get { return "Join lobby..."; } }
    public static string JOIN_FAILED { get { return "Joining faild"; } }
    public static string CREATE_ROOM_FAILED { get { return "Create room failed"; } }
    private MSG() { }
}