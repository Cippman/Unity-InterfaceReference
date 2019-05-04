/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CippSharp.Interfaces
{
    /// <summary>
    /// Create a custom serializable class that inherit from this class to reference an interface of type I
    /// I must be an interface.
    /// Useful to hold reference to components/objects of type t;
    /// </summary>
    /// <typeparam name="I"></typeparam>
    [Serializable]
    public abstract class InterfaceReference<I> : ISerializationCallbackReceiver where I : class
    {
        private const string None = "None";
     
        [SerializeField, NotEditable] private string name = null;
        
        /// <summary>
        /// Exposed field assignable from inspector
        /// </summary>
        [SerializeField] private Object target = null;

        /// <summary>
        /// The target.
        /// </summary>
        public Object Target
        {
            get { return target; }
            set
            {
                SetTarget(value);
                SetName(target);
            }
        }

        private void SetTarget(Object value)
        {
            if (value == null)
            {
                target = null;
                return;
            }
                
            if (value is I)
            {
                target = value;
            }
            else
            {
                target = null;                
                Debug.LogWarning(string.Format("You should set an Object that implements <i>{0}</i>.", typeof(I).FullName));
            } 
        }

        private void SetName(Object obj)
        {
            name = obj != null ? string.Format("{0} ({1})", obj.name, typeof(I).Name) : None;
        }
        
        
        /// <summary>
        /// The interface.
        /// </summary>
        public I Interface
        {
            get
            {
                return Target != null ? (I)(object)Target : null;
            }
        }

        #region ISerializationCallbackReceiver Implementation
        
        public void OnBeforeSerialize()
        {
            CheckTarget();
            SetName(Target);
        }

        private void CheckTarget()
        {
            if (Target == null)
            {
                return;
            }
            
            //For a comfy Drag n drop of a GameObject
            if (Target is GameObject)
            {
                GameObject gameObject = (GameObject) target;
                Target = gameObject.GetComponent(typeof(I));
                
                if (Target == null)
                {
                    Debug.LogWarning(string.Format("You must assign a gameObject that have at least one component of type <i>{0}</i>.", typeof(I).FullName));
                    return;
                }
            }
            
            if (!(Target is I))
            {
                //skip assignment by property during edit mode.
                target = null;
                Debug.LogWarning(string.Format("You must assign an Object that implements <i>{0}</i>.", typeof(I).FullName));
            }
        }

        public void OnAfterDeserialize()
        {
            
        }
        
        #endregion

        #region Operators
        
        public static implicit operator I(InterfaceReference<I> interfaceReference)
        {
            return interfaceReference.Interface;
        }
        
        #endregion

        public override string ToString()
        {
            return typeof(InterfaceReference<I>).Name + " " + name;
        }
    }
}
