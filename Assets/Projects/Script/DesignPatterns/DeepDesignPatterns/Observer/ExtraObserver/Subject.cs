using System.Collections.Generic;
using UnityEngine;

namespace GamePatterns.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();
        public void AddObserver(IObserver observer) => _observers.Add(observer);
        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

        protected void Notify(Entity entity, GameEvent gameEvent)
        {
            foreach(IObserver observer in _observers)
            {
                observer.OnNotify(entity, gameEvent);
            }
        }
    }
}

