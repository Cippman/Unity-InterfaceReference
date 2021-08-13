/*
 *  Author: Alessandro Salani (Cippman)
 */

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace CippSharp.Core.Interfaces.Samples
{
    public class ExposedInterfaceReference : MonoBehaviour
    {
        [Serializable]
        public class CustomInterfaceReference : InterfaceReference<ICustomInterfaceExample>
        {
			
        }
        
        		
        [Header("Interface:")]
        [Expose] public CustomInterfaceReference customInterfaceReference = new CustomInterfaceReference();

    }
}
#endif