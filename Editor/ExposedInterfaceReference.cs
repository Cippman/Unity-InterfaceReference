/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;

namespace CippSharp.Interfaces.Examples
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
