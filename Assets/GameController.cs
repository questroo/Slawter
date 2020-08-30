using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        public GameObject sphere;
        public GameObject box;
        public GameObject secondBox;

        // Responsible for sending notification to whoever is interested in knowing
        Subject subject = new Subject();
        private void Start()
        {
            // Creating box that can observer the jump event
            Box box1 = new Box(box, new Jump());
            Box box2 = new Box(secondBox, new Jump());
            // Add the box to the list of objects waiting for notification
            subject.AddObserver(box1);
            subject.AddObserver(box2);
        }
        private void Update()
        {
            if ((sphere.transform.position).magnitude < 0.5f)
            {
                subject.Notify();
            }
        }
    }
}
