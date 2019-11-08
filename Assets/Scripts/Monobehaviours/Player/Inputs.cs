using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Inputs : MonoBehaviour
{
    // Singleton.
    public static Inputs Instance { get; private set; }

    public Vector3ReactiveProperty Movement { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
