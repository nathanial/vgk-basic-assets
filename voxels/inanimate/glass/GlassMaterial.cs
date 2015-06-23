using VGK;
using UnityEngine;

namespace VGKBasicAssets {
  public class GlassMaterial : ChunkMaterial {
    readonly Material _material = new Material(Shader.Find("Diffuse"));

    public override Material Material {
      get { return _material; }
    }

    public override string Name { get { return "GlassMaterial"; } }

    public GlassMaterial(string basePath) : base(basePath) {}
  }
}
