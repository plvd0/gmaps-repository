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
        CalculateGameDimensions();

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
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0,0); // The tail of the vector
        endPt = new Vector2(2,3); // The head of the vector
        
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt; // Calculation for magnitude
        Debug.Log("Magnitude = " + vec2.magnitude); // "Length" or magnitude of the vector in console
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)  // Loop to generate random lines until n, which is 20
        {
            maxX = 5; maxY = 5; // Maximum values for start & end point
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY)); // Generates start point of the line
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY)); // Generates end point of the line

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black); // Configurations for line
            drawnLine.EnableDrawing(true); // Draws the line
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++) // Loop to generate the arrows until n
        {
            DebugExtension.DebugArrow(
               new Vector3(0, 0, 0), // Setting every arrows tail to start from origin
               new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-maxY, maxY)), // Setting the head to be a random X,Y,Z value
               Color.white, // Color of arrow to be white
               60f);
        }
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5); // Object of a
        HVector2D b = new HVector2D(-4, 2); // Object of b
        HVector2D c = a + b; // Object of c, sum of a + b

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f); // Creating object A
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f); // Creating object B
        //DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f); // Creating object C

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.green, 60f); // Creating object B, starting at A

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2")); // Magnitude of a
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2")); // Magnitude of b
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2")); // Magnitude of c 

        HVector2D b2 = a - b; // Modification of code

        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f); // Modification of b
        DebugExtension.DebugArrow(Vector3.zero, b2.ToUnityVector3(), Color.white, 60f); // Modification of c, which is white to hit the head of -b
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5); // Object of a 
        HVector2D b = new HVector2D(a.x * 2, a.y * 2); // Object of b
        HVector2D a2 = new HVector2D(a.x / 2, a.y / 2); // Modification of a

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f); // Creating object A
        //DebugExtension.DebugArrow(Vector3.zero, a2.ToUnityVector3(), Color.red, 60f); // Creating modification of object A, where it is divided by 2
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f); // Creating object b, with the ".right" being an offset (1,0,0)
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5); // Object of a

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f); // Creating object A
        a.Normalize(); // Normalizing the current object A
        DebugExtension.DebugArrow(Vector3.right, a.ToUnityVector3(), Color.green, 60f); // Creating the new normalized A, with a offset of (0,0,1)

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2")); // Magnitude of the normalized A, being 1.0
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
