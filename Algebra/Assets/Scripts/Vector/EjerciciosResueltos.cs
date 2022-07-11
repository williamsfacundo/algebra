using UnityEngine;
using MathDebbuger;
using WilliamsMath;

public class EjerciciosResueltos : MonoBehaviour
{
    enum Exercise {ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN };

    [SerializeField] private Exercise exercise = Exercise.ONE;
    private Exercise exerciseCopy;

    [SerializeField] private Vec3 vecOne = new Vec3();
    private Vec3 vecOneCopy;

    [SerializeField] private Vec3 vecTwo = new Vec3();
    private Vec3 vecTwoCopy;

    [SerializeField] private bool enable = true;
    private bool enableCopy;

    private Vec3 vecThree = new Vec3();

    private Color vecOneColor = Color.red;
    private Color vecTwoColor = Color.blue;
    private Color vecThreeColor = Color.white;

    private const string vecOneName = "VecOne";
    private const string vecTwoName = "VecTwo";
    private const string vecThreeName = "VecThree";

    private float lerpTimer = 0f;

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

            if (exercise == Exercise.FIVE)
            {
                lerpTimer = 0f;
            }

            UpdateResultingVector();
        }

        if (exercise == Exercise.FIVE)
        {
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

                vecThree = vecOne - vecTwo;

                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.THREE:

                vecThree = new Vec3(vecOne.x * vecTwo.x, vecOne.y * vecTwo.y, vecOne.z * vecTwo.z);

                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.FOUR:

                vecThree = Vec3.Cross(vecOne, vecTwo);

                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.FIVE:

                if (lerpTimer > 1f) 
                {
                    lerpTimer = 0f;
                }                

                lerpTimer += Time.deltaTime;

                vecThree = Vec3.Lerp(vecOne, vecTwo, lerpTimer);

                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.SIX:

                vecThree = Vec3.Max(vecOne, vecTwo);
                
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.SEVEN:

                vecThree = Vec3.Project(vecOne, vecTwo);
                
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.EIGHT:

                vecThree = Vec3.Zero;
                
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.NINE:

                vecThree = Vec3.Zero;
                
                Vector3Debugger.UpdatePosition(vecThreeName, vecThree);
                break;

            case Exercise.TEN:

                vecThree = Vec3.Zero;

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
