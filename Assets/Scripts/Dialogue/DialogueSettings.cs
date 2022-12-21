using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Faz com que a classe "dialogueSettings" apareça na janela Project, quando se clicar com o botão direito.
//fileName = é um nome que se pode dar para todo arquivo que for gerado a partir desta classe.
//menuName = é aonde você quer organizar, para que esta opção de criar um Dialogue Settings, ele apareça no menu quando você clicar com o botão direito na janela Project.

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    //Um cabeçalho, na hora que criamos um Header ele aparece no Inspector como titulo de uma seção de Variaveis
    [Header("Settings")]

    //actor = temos que passar qual é o NPC que queremos que fale as determinadas falas, que iremos configurar nesse Scriptable. Então é preciso referenciar qual é o objeto, qual o NPC.
    //É inclusive um padrão utilizado em todos os jogos é uma pratica que se coloca quando se vai referenciar um Objeto, que seja um personagem, coloca-se o termo Actor.
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