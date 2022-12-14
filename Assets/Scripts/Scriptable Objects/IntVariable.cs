using UnityEngine;

[CreateAssetMenu(fileName = "New IntVariable", menuName = "ScriptableObjects/IntVariable")]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;

    public int Value
    {
        get { return _currentValue; }
        set { _currentValue = value; }
    }
    public virtual int ApplyChange(int change)
    {
        return _currentValue += change;
    }
    public virtual void SetValue(int newValue)
    {
        _currentValue = newValue;
    }
    private void OnEnable()
    {
        _currentValue = _maxValue;
        Debug.Log("reset");
    }
}
