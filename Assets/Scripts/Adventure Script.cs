using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector3 mousePosWorld;
    public Vector2 mousePosWorld2D;
    RaycastHit2D hit;
    public GameObject player;
    public Vector2 targetPos;
    public float speed;
    public bool isMoving;

    public bool key = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Überprüfung, ob Maus gedrückt wurde
        if(Input.GetMouseButtonDown(0))
        {
            // Ausgabe, wenn Mausklick erkannt wurde
            print("Maustaste wurde gedrückt");
            // Mausposition wird überprüft
            mousePos = Input.mousePosition;
            // Mausposition wird auf Konsole ausgegeben
            print("Screen Space" + mousePos);
            // Koordinaten werden von Screenspace zu Worldspace umgewandelt
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            // Worldspace Koordinaten werden auf Konsole ausgegeben
            print("World Space" + mousePosWorld);
            // Umwandlung von vector3 zu Vector2
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
            // Raycast2D -> hit abspeichern
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);
            // Überprüfung, ob hit einen Collider beinhaltet
            if(hit.collider != null)
            {
                print("Objekt mit Collider wurde getroffen");
                // Ausgabe des getroffenen Gameobjektes in der Konsole
                print(hit.collider.gameObject.name);
                // Ausgabe des Tags des getroffenen Gameobjektes in der Konsole
                print(hit.collider.gameObject.tag);
                // Abfrage ob der Ground angeklickt wurde
                if (hit.collider.gameObject.gameObject.tag == "Ground")
                {
                    targetPos = hit.point;
                    // IsMoving = wahr, damit sich Spieler bewegt
                    isMoving = true;
                    // Überprüfung ob der Sprite geflipt werden muss
                    CheckSpriteFlip();
                }
                // Abfrage ob ein aufnehmbarer Gegenstand angeklickt wurde
                else if (hit.collider.gameObject.tag == "Key")
                {
                    // Grafik deaktivieren
                    hit.collider.gameObject.SetActive(false);
                    // aufnehmbaren Gegenstand im Skript abspeichern
                    key = true;
                    Debug.Log("Test");
                }
                // Abfrage ob es die Tür ist
                else if (hit.collider.gameObject.tag == "DoorOut")
                {
                    // Nächstes Level laden
                    SceneManager.LoadScene("Dorf");
                }
                // Abfrage ob es die Tür ist
                else if (hit.collider.gameObject.tag == "DoorIn")
                {
                    // Nächstes Level laden
                    SceneManager.LoadScene("Taverne");
                }
            }
            else
            {
                print("Kein Collider erkannt.");
            }
        }
    }
    private void FixedUpdate()
    {
        // Überprüfung, ob Spieler sich bewegt
        if (isMoving)
        {
            // Spieler an Zielort befördern
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
            // Ist der Spieler am Spielort?
            if(player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                // Spieler am Spielort -> isMoving false
                isMoving = false;
            }
        }
        
    }
    void CheckSpriteFlip()
    {
        if(player.transform.position.x > targetPos.x)
        {
            // Nach links schauen
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            // Nach rechts schauen
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
