/*
 *  Author: Alessandro Salani (Cippman)
 */

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace CippSharp.Core.Interfaces.Samples
{
	public class ComponentWithReference : MonoBehaviour
	{
		[Serializable]
		public class CustomInterfaceReference : InterfaceReference<ICustomInterfaceExample>
		{
			
		}
		
		[Header("Interface:")]
		public CustomInterfaceReference customInterfaceReference = new CustomInterfaceReference();
	}
}
#endif
