using UnityEngine;

namespace CippSharp.Interfaces.Examples
{
    public class ExposedInterfaceReference : MonoBehaviour
    {
        [SerializeField, Expose] public ICustomInterfaceExample customInterfaceExample = null;
    }
}
