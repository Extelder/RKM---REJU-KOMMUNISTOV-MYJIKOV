using UnityEngine;

[CreateAssetMenu(menuName = "KPP/Day")]
public class DayData : ScriptableObject
{
    public PakostiType Pakosty;
    public Character[] Characters;
}

public abstract class DayEventable : MonoBehaviour
{
    public abstract void DayStartedEvent();
    public abstract void DayEndedEvent();
}