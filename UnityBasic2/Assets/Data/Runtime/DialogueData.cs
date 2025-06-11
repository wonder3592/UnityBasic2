using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class DialogueData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  string bg;
  public string BG { get {return bg; } set { this.bg = value;} }
  
  [SerializeField]
  int[] characterid = new int[0];
  public int[] Characterid { get {return characterid; } set { this.characterid = value;} }
  
  [SerializeField]
  int[] position = new int[0];
  public int[] Position { get {return position; } set { this.position = value;} }
  
  [SerializeField]
  string dialogue;
  public string Dialogue { get {return dialogue; } set { this.dialogue = value;} }
  
}