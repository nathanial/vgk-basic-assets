using VGK;
using UnityEngine;

namespace VGKBasicAssets {
  public class BeaconMaterial : ChunkMaterial {
    float _emissionGain = 0.2f;
    readonly Material _material = new Material(Shader.Find("Sonic Ether/Emissive/Textured"));

    public override string Name { get { return "BeaconMaterial"; } }

    public BeaconMaterial(string basePath) : base(basePath) {
      _material.SetTexture("_Illum", _material.mainTexture);
      _material.SetColor ("_EmissionColor", new Color (255 / 256.0f, 255 / 256.0f, 255 / 256.0f, 1.0f));
      _material.SetColor ("_DiffuseColor", new Color (255 / 256.0f, 255 / 256.0f, 255 / 256.0f, 1.0f));
      _material.SetFloat ("_EmissionGain", _emissionGain);
    }

    public override Material Material {
      get { return _material; }
    }

    public float EmissionGain {
      set {
        _emissionGain = value;
        _material.SetFloat ("_EmissionGain", _emissionGain);
      }
      get {
        return _emissionGain;
      }
    }
  }
}
