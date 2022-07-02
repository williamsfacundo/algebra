using UnityEngine;
using MathDebbuger;

public class Ejercicios_Vector : MonoBehaviour
{
    enum Exercise {ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN };

    [SerializeField] private Exercise exercise = Exercise.ONE;
    private Exercise exerciseCopy;

    [SerializeField] private Vector3 vecOne = new Vector3();
    private Vector3 vecOneCopy;

    [SerializeField] private Vector3 vecTwo = new Vector3();
    private Vector3 vecTwoCopy;

    [SerializeField] private bool enable = true;
    private bool enableCopy;

    private Vector3 vecThree = new Vector3();

    private Color vecOneColor = Color.red;
    private Color vecTwoColor = Color.blue;
    private Color vecThreeColor = Color.white;

    private const string vecOneName = "VecOne";
    private const string vecTwoName = "VecTwo";
    private const string vecThreeName = "VecThree";

    void Start()
    {
        vecOneCopy = vecOne;
        vecTwoCopy = vecTwo;
        exerciseCopy = exercise;
        enableCopy = enable;

        Vector3Debugger.AddVector(vecOne, vecOneColor, vecOneName);
        Vector3Debugger.AddVector(vecTwo, vecTwoColor, vecTwoName);
        Vector3Debugger.AddVector(vecThree, vecThreeColor, vecThreeName);

        if (enable) 
        {
            Vector3Debugger.EnableEditorView(vecOneName);
            Vector3Debugger.EnableEditorView(vecTwoName);
            Vector3Debugger.EnableEditorView(vecThreeName);
        }        

        UpdateResultingVector();
    }

    void Update()
    {
        ChangeVectorsEditorView();

        if (VectorsChangeValue()) 
        {
            Vector3Debugger.UpdatePosition(vecOneName, vecOne);
            Vector3Debugger.UpdatePosition(vecTwoName, vecTwo);

            vecOneCopy = vecOne;
            vecTwoCopy = vecTwo;           

            UpdateResultingVector();
        }        
        else if (ExerciseChange()) 
        {
            exerciseCopy = exercise;

            UpdateResultingVector();
        }
    }

    void UpdateResultingVector() 
    {
        switch (exercise)
        {
            case Exercise.ONE:

                vecThree = vecOne + vecTwo;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.TWO:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.THREE:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.FOUR:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.FIVE:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.SIX:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.SEVEN:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.EIGHT:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.NINE:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.TEN:

                vecThree = Vector3.zero;
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;
        }
    }

    bool VectorsChangeValue() 
    {
        return vecOne != vecOneCopy || vecTwo != vecTwoCopy;
    }

    bool ExerciseChange() 
    {
        return exercise != exerciseCopy;
    }

    void ChangeVectorsEditorView() 
    {
        if (enable != enableCopy) 
        {
            enableCopy = enable;

            if (enable) 
            {
                Vector3Debugger.EnableEditorView(vecOneName);
                Vector3Debugger.EnableEditorView(vecTwoName);
                Vector3Debugger.EnableEditorView(vecThreeName);
            }
            else 
            {
                Vector3Debugger.DisableEditorView();
            }
        }
    }
}
