using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Faz com que a classe "dialogueSettings" apare�a na janela Project, quando se clicar com o bot�o direito.
//fileName = � um nome que se pode dar para todo arquivo que for gerado a partir desta classe.
//menuName = � aonde voc� quer organizar, para que esta op��o de criar um Dialogue Settings, ele apare�a no menu quando voc� clicar com o bot�o direito na janela Project.

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    //Um cabe�alho, na hora que criamos um Header ele aparece no Inspector como titulo de uma se��o de Variaveis
    [Header("Settings")]

    //actor = temos que passar qual � o NPC que queremos que fale as determinadas falas, que iremos configurar nesse Scriptable. Ent�o � preciso referenciar qual � o objeto, qual o NPC.
    //� inclusive um padr�o utilizado em todos os jogos � uma pratica que se coloca quando se vai referenciar um Objeto, que seja um personagem, coloca-se o termo Actor.
    public GameObject actor;

    [Header("Dialogue")]
    //Sprite de quem esteja falando.
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;

}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }

    }
}

#endif