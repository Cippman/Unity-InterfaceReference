﻿/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;

namespace CippSharp.Core.Interfaces.Editor.Examples
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

