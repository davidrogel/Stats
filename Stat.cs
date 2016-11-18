[System.Serializable]
public class Stat
{

    [UnityEngine.SerializeField]
    string name = "";
    [UnityEngine.SerializeField]
    float initialValue;
    float value;
    
    public void SetFinalValue(float value)
    {
        this.value = value;
    }

    public float GetValue()
    {
        return value;
    }

    public string GetName()
    {
        return name;
    }

    public float GetInitialValue()
    {
        return initialValue;
    }

    public void AddPoint()
    {
        initialValue++;
    }

    public void RemovePoint()
    {
        initialValue--;
    }
}
