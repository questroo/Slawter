using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace ObserverPattern
{
    // Responsible for invoking notification method
    public class Subject
    {
        List<Observer> observers = new List<Observer>();
        // Send notification when something has happened
        public void Notify()
        {
            for (int i = 0; i < observers.Count; ++i)
            {
                observers[i].OnNotify();
            }
        }
        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }
    }
    // When the object does something
    public abstract class Observer
    {
        public abstract void OnNotify();
    }
    public class TextUI : Observer
    {
        TextMeshProUGUI uIText;
        UIEvent uIEvent;
        public TextUI(TextMeshProUGUI uIText, UIEvent uIEvent)
        {
            this.uIText = uIText;
            this.uIEvent = uIEvent;
        }
        public override void OnNotify()
        {

        }
    }
    public class Box : Observer
    {
        GameObject boxObject;
        BoxEvent boxEvent;
        public Box(GameObject boxObject, BoxEvent boxEvent)
        {
            this.boxObject = boxObject;
            this.boxEvent = boxEvent;
        }
        public override void OnNotify()
        {
            Jump(boxEvent.GetJumpForce());
        }
        void Jump(float jumpForce)
        {
            if(boxObject.transform.position.y < 0.55f)
            {
                boxObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }

    public class UIEvent
    {
        public string GetUIEventString()
        {
            return "sdfsdf";
        }
    }
    // Instead call UIEvent
    public abstract class BoxEvent
    {
        public abstract float GetJumpForce();
    }

    public class Jump : BoxEvent
    {
        public override float GetJumpForce()
        {
            return 30.0f;
        }
    }
}
