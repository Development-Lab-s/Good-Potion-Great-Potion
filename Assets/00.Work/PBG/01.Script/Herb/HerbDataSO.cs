using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "HerbDataSO", menuName = "SO/Herb/Data")]
public class HerbDataSO : ScriptableObject
{
    public string herbName;
    public Sprite herbIcon;
}
