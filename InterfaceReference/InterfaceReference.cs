/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CippSharp
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
     
        [SerializeField, HideInInspector] private string name = null;
        
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
                if (value == null)
                {
                    target = null;
                    name = None;
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
                
                if (Target != null)
                {
                    name = string.Format("{0} ({1}).", Target.name, typeof(I).Name);
                }
            }
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

        public void OnBeforeSerialize()
        {
            if (Target == null)
            {
                name = None;
                return;
            }
            
            //For a comfy Drag n drop of a GameObject
            if (Target is GameObject)
            {
                GameObject gameObject = (GameObject) target;
                Target = gameObject.GetComponent(typeof(I));
                
                if (Target == null)
                {
                    name = None;
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

            if (Target != null)
            {
                name = string.Format("{0} ({1}).", Target.name, typeof(I).Name);
            }
            else
            {
                name = None;
            }
        }

        public void OnAfterDeserialize()
        {
            
        }

        public static implicit operator I(InterfaceReference<I> interfaceReference)
        {
            return interfaceReference.Interface;
        }

        public override string ToString()
        {
            return typeof(InterfaceReference<I>).Name + " " + name;
        }
    }
}
