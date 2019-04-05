//======= Copyright (c) Immerxive Srl, All rights reserved. ===================
//
// Author: Alessandro Salani (Cippo)
//
// Purpose: 
//
// Notes:
//
//=============================================================================

using System;
using UnityEngine;

namespace CippSharp.Interfaces.Examples
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

