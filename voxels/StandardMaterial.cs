using VGK;
using UnityEngine;

namespace VGKBasicAssets {
  public class StandardMaterial : ChunkMaterial {
    readonly Material _material = new Material(Shader.Find("Diffuse"));

    public override string Name { get { return "StandardMaterial"; } }

    public override Material Material {
      get { return _material; }
    }

    public StandardMaterial(string basePath) : base(basePath){}
  }
}
