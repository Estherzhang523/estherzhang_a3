using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{

    public static float totalScore = 0;
    public static float totalCollected = 0;
    public static float totalUniqueCollected = 0;
    public static HashSet<int> collected = new HashSet<int>();
    [SerializeField] TextMesh outputText;
    [SerializeField] TextMesh victoryText;

    public static void collect(Collectible collectible) {
        totalCollected += 1;
        totalScore += Collectible.getScore(collectible);
        collected.Add(collectible.name.GetHashCode());
        totalUniqueCollected = collected.Count;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            RaycastHit result;
            if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out result, Mathf.Infinity)) {
                if (result.collider.gameObject.GetComponent<Collectible>()) {

                    Player.collect(result.collider.gameObject.GetComponent<Collectible>());
                    outputText.text = "Total Score: " + Player.totalScore;
                    outputText.text += "\n";
                    outputText.text += "Total Objects Collected: " + Player.totalCollected;
                    outputText.text += "\n";
                    outputText.text += "Total Unique Objects: " + Player.totalUniqueCollected;
                    Destroy(result.collider.gameObject);
                    if (Player.totalUniqueCollected == 3) {
                        victoryText.text = "YOU WIN Esther Zhang";
                    }
                }
            }
        }
    }
}
