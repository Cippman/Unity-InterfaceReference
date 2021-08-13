/*
 *  Author: Alessandro Salani (Cippman)
 */
#if UNITY_EDITOR
using UnityEngine;

namespace CippSharp.Core.Interfaces.Samples
{
	public class TypeFilterReference : MonoBehaviour
	{
		[TypeFilter(new [] {typeof(ICustomInterfaceExample)})] 
		public Object reference = null;

		#pragma warning disable 414
		private ICustomInterfaceExample interfaceExample = null;
		#pragma warning restore 414

		private void Awake()
		{
			interfaceExample = reference != null ? (ICustomInterfaceExample)reference : null;
		}
	}
}
#endif