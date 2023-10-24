using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
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

    }

    void Question2a()
    {
        startPt = new Vector2(0, 0); // Determines position of tail
        endPt = new Vector2(2, 3); // Determines position of head

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black); // Initialises line with properties in order of tail & head position, followed by width and color of line

        drawnLine.EnableDrawing(true); // Draws the line

        Vector2 vec2 = endPt - startPt; // Calculates the x and y values of the vector
        Debug.Log("Magnitude = " + vec2.magnitude); 
    }

    void Question2b(int n)
    {
        lineFactory.maxLines = n; // sets max no. of lines
        maxX = 5; maxY = 5; // sets value of maximum value of x and y to 5

        for (int i = 0; i < lineFactory.maxLines; i++) // repeats until 20 lines have been drawn
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY)); // creates random startpoint

            endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY)); // creates random endpoint

            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black); // initialises line with random start and endpoint

            drawnLine.EnableDrawing(true); // draws line
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow( // creates a 3d arrow using vector3s as the start and endpoint
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        lineFactory.maxLines = n; // sets maxlines to n (20)
        maxX = 5; maxY = 5; // sets value pf max value of x and y

        for (int i = 0; i < n; i++) // repeats until 20 arrows drawn
        {
            startPt = new Vector3(0, 0, 0); // start point is always the origin or 0 point

            DebugExtension.DebugArrow( // creates 3d vector using randomized endpoints
                startPt,
                new Vector3(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY)), // generates random endpoint
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;
        // github
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1, 0, 0), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        
        a.Normalize();

        DebugExtension.DebugArrow(new Vector3(1, 0, 0), a.ToUnityVector3(), Color.green, 60f);
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D proj = c.Projection(b);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
