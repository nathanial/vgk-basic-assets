using UnityEngine;
using VGK;

namespace VGKBasicAssets {

  [ChunkMaterial("BeaconMaterial")]
  public class BeaconMaterial : ChunkMaterial {
    float _emissionGain = 0.47f;
    Material _material;

    public void Init(){
      _material = new Material(Shader.Find("Sonic Ether/Emissive/Textured"));
      _material.SetTexture("_Illum", LoadTexture("voxels/artificial/beacon/beacon.png"));
      _material.SetColor ("_EmissionColor", new Color (77 / 256.0f, 138 / 256.0f, 255 / 265.0f, 1.0f));
      _material.SetColor ("_DiffuseColor", new Color (77 / 256.0f, 138 / 256.0f, 255 / 265.0f, 1.0f));
      _material.SetFloat ("_EmissionGain", _emissionGain);
      _material = material;
    }

    public Material Material {
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

  [Voxel("Beacon", Material=typeof(BeaconMaterial))]
  [Light(Range=10, Color="#3c76ff", Intensity=2.5)]
  [PowerDraw(Mana="Light", Rate=10)]
  [Images(AllSides="voxels/artificial/beacon/beacon.png")]
  public class BeaconVoxel {
    readonly Light _light;
    readonly BeaconMaterial _material;

    public BeaconVoxel(Light light, BeaconMaterial material){
      _light = light;
      _material = material;
    }

    public void Update(double time){
      _light.Intensity = Mathf.Sin(time) + 2;
      _material.EmissionGain = Mathf.Max(0.0f, Mathf.Sin(time));
    }
  }
}
