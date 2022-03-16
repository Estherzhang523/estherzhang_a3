using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Collectible : MonoBehaviour
{
    //int currentFrame=0;
    //public TextMesh outputText;

    [SerializeField] TextMesh outputText;
    [SerializeField] TextMesh victoryText;

    public static float getScore(Collectible collectible) {
        if (collectible.name.Equals("Collectible")) {
            return 1;
        }
        if (collectible.name.Equals("Collectible 2")) {
            return 2;
        }
        if (collectible.name.Equals("Collectible 3")) {
            return 3;
        }
        return 0;
    }

 
    // Update is called once per frame
    /*void Update()
    {
        // print("current frame is: "+currentFrame);
        outputText.text = "current frame is: " + currentFrame;
        currentFrame++;
    }*/

    void OnCollisionEnter(Collision other){
        
        print("I, "+this.gameObject.name+" hit "+other.collider.gameObject.name);

        if (other.collider.gameObject.name.Equals("AROrigin")) {
            print("HIT");
            Player.collect(this.gameObject.GetComponent<Collectible>());
            outputText.text = "Total Score: " + Player.totalScore;
            outputText.text += "\n";
            outputText.text += "Total Objects Collected: " + Player.totalCollected;
            outputText.text += "\n";
            outputText.text += "Total Unique Objects: " + Player.totalUniqueCollected;
            Destroy(this.gameObject);
            if (Player.totalUniqueCollected == 3) {
                victoryText.text = "YOU WIN Esther Zhang";
            }
        }   

        /*
        if (other.collider.gameObject.GetComponent<Collectible>()){
            print("I, "+this.gameObject.name+" hit another collectible called "+other.collider.gameObject.name);
        }*/
    }

    /*void OnTriggerEnter(Collider other){
        if (other.gameObject.GetComponent<Collectible>()){
            print("I, "+this.gameObject.name+" overlapped another collectible called "+other.gameObject.name);
        }
    }*/

}
