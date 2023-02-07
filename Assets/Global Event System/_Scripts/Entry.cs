using event_system;
using UnityEngine;

public class Entry : MonoBehaviour
{
    void Start()
    {
        GroupEvent g1 = EventManager.Instance.CreateGroupEvent("g_1");
        SingleEvent s1 = EventManager.Instance.CreateSingleEvent("s_1" , "g_1");
        //SingleEvent s1 = EventManager.Instance.CreateSingleEvent("s_1" , "g_1");
        //g1.AddEvent(s1);

        s1.SetCondition(() =>
        {
            return Input.GetKeyDown(KeyCode.Space);
        });

        s1.Subscribe(() =>
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Space)");
        });

        EventManager.Instance.Enable("Root", true);
    }

    void Update()
    {
        EventManager.Instance.OnUpdate();
    }
}
