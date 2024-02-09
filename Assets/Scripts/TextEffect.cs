using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine.Rendering;

public enum textEffectSelection
    {
        Option1,
        Option2,
        Option3
    }
public class TextEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponant;
    [SerializeField] float effectSpeed = 2f;
    [SerializeField] float effectVeticalPwr = 0.05f;
    [SerializeField] float effectIntensity = 10f;
    public textEffectSelection _textEffectSelection;

    void Update()
    {
        switch (_textEffectSelection)
        {
            case textEffectSelection.Option1:
                LetterByLetterEffect();
                break;
            case textEffectSelection.Option2:
                break;
            case textEffectSelection.Option3:
                break;
        }
    }
    void LetterByLetterEffect()
    {
        // generate the mesh
        textComponant.ForceMeshUpdate();
        var textInfo = textComponant.textInfo;

        // edit the draft
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];
            
            if (!charInfo.isVisible)
            {
                continue;
            }

            // select each vertices of the mesh and store them in a variable
            var vertices = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            // now we loop 4 time the individual vertex point in the vertices
            for (int j = 0; j < 4; j++)
            {
                var vertex = vertices[charInfo.vertexIndex + j];
                // we apply the changes to the vertex to its base vertex and store the it in the vertices
                vertices[charInfo.vertexIndex + j] = vertex + new Vector3(0, Mathf.Sin(Time.time*effectSpeed + vertex.x*effectVeticalPwr) *effectIntensity ,0); // write cool effect in vector3
            }
        }
        // Update the actual vertices
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponant.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
