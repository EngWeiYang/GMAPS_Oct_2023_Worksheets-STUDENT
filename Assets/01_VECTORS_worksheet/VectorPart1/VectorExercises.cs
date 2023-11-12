using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    private Vector3 endPoint;

    public float GameWidth, GameHeight;
    private float minX = -5, minY = -5, maxX = 5, maxY = 5;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
        {
            CalculateGameDimensions();
            Question2b(20);
        }
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;  //Gets orthographic size of camera (distance from center to top of screen)
                                                         //and multiplies it by 2 to get the height of the game
        GameWidth = Camera.main.aspect * GameHeight; //Gets the aspect ratio of the camera (width / height)
                                                     //and multiplies it by the game height which gives the width

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;

        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            startPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            endPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0 ,0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);  //Lifespan of the shape in seconds
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            endPoint = new Vector3(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(-maxX, maxX));

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                endPoint,
                Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;

        //Arrow 'a' (red)
        DebugExtension.DebugArrow(
            new Vector2(0, 0),
            a.ToUnityVector2(),
            Color.red,
            60f);

        //Arrow 'b' (green)
        DebugExtension.DebugArrow(
            new Vector2(0, 0),
            b.ToUnityVector2(),
            Color.green,
            60f);

        //Arrow 'c' (white)
        DebugExtension.DebugArrow(
            new Vector2(0, 0),
            c.ToUnityVector2(),
            Color.white,
            60f);

        //Arrow 'b' on tip of 'a'
        /*DebugExtension.DebugArrow(
            vecA,
            vecB,
            Color.green,
            60f);*/

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));

        //-'b' from tip of 'a'
        DebugExtension.DebugArrow(
            a.ToUnityVector2(),
            -b.ToUnityVector2(),
            Color.green,
            60f);
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(
            new Vector2(0, 0),
            a.ToUnityVector2(),
            Color.red,
            60f);

        DebugExtension.DebugArrow(
            new Vector2(1, 0),
            b.ToUnityVector2(),
            Color.green,
            60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);

        DebugExtension.DebugArrow(
            new Vector2(0, 0),
            a.ToUnityVector2(),
            Color.red,
            60f);

        a.Normalize();
        DebugExtension.DebugArrow(
            new Vector2(1, 0),
            a.ToUnityVector2(),
            Color.green,
            60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;

        // Your code here
        float yellow = (c - a).Magnitude();

        //HVector2D proj = v1 * (DotProduct(v1) / v1.DotProduct(b));

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
