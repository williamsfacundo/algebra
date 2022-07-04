using UnityEngine;
using MathDebbuger;

public class EjerciciosQuaternionResueltos : MonoBehaviour
{
    private const short _maxEjercicio = 3;

    [SerializeField, Range(1, _maxEjercicio)] private int _ejercicioQuaternion = 1;

    private int _auxEjercicio;

    [SerializeField] private float angle;

    private Vector3 vector1;
    
    private Vector3 vector2;
    
    private Vector3 vector3;
    
    private Vector3 vector4;    

    private string vector1Name = "one";

    private string vector2Name = "two";

    private string vector3Name = "three";

    private string vector4Name = "four";    

    // Start is called before the first frame update
    private void Start()
    {
        ValorInicialDeLosVectores();

        Vector3Debugger.AddVector(Vector3.zero, vector1, Color.black, vector1Name);
        
        Vector3Debugger.AddVector(vector1, vector2, Color.red, vector2Name);
        
        Vector3Debugger.AddVector(vector2, vector3, Color.yellow, vector3Name);
        
        Vector3Debugger.AddVector(vector3, vector4, Color.green, vector4Name);
        
        Vector3Debugger.EnableEditorView();        
    }

    private void Update()
    {
        if (_auxEjercicio != _ejercicioQuaternion) 
        {
            _auxEjercicio = _ejercicioQuaternion;

            ValorInicialDeLosVectores();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3Debugger.TurnOffVector(vector1Name);
        Vector3Debugger.DisableEditorView(vector1Name);

        Vector3Debugger.TurnOffVector(vector2Name);
        Vector3Debugger.DisableEditorView(vector2Name);

        Vector3Debugger.TurnOffVector(vector3Name);
        Vector3Debugger.DisableEditorView(vector3Name);

        Vector3Debugger.TurnOffVector(vector4Name);
        Vector3Debugger.DisableEditorView(vector4Name);

        switch (_ejercicioQuaternion) 
        {
            case 1:

                EjercicioUno();
 
                break;

            case 2:

                EjercicioDos();

                break; 

            case 3:

                EjercicioTres();

                break;
        }
    }

    private void ValorInicialDeLosVectores() 
    {
        vector1 = new Vector3(10, 0, 0);
        vector2 = new Vector3(10, 10, 0);
        vector3 = new Vector3(20, 10, 0);
        vector4 = new Vector3(20, 20, 0);
    }

    private void EjercicioUno() 
    {
        Vector3Debugger.TurnOnVector(vector1Name);
        Vector3Debugger.EnableEditorView(vector1Name);

        vector1 = Quaternion.Euler(new Vector3(0f, angle, 0f)) * vector1;

        Vector3Debugger.UpdatePosition(vector1Name, vector1);
    }

    private void EjercicioDos() 
    {
        Vector3Debugger.TurnOnVector(vector1Name);
        Vector3Debugger.EnableEditorView(vector1Name);

        Vector3Debugger.TurnOnVector(vector2Name);
        Vector3Debugger.EnableEditorView(vector2Name);

        Vector3Debugger.TurnOnVector(vector3Name);
        Vector3Debugger.EnableEditorView(vector3Name);

        vector1 = Quaternion.Euler(new Vector3(0, angle, 0)) * vector1;
        vector2 = Quaternion.Euler(new Vector3(0, angle, 0)) * vector1;
        vector3 = Quaternion.Euler(new Vector3(0, angle, 0)) * vector1;

        Vector3Debugger.UpdatePosition(vector1Name, vector1);
        Vector3Debugger.UpdatePosition(vector2Name, vector1, vector2);
        Vector3Debugger.UpdatePosition(vector3Name, vector2, vector3);
    }

    private void EjercicioTres() 
    {
        
    }
}