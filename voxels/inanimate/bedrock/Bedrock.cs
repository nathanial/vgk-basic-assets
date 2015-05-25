using VGK;

namespace VGKBasicAssets {
  public class Bedrock : VoxelDefinition {
    public Bedrock() {
      AllImages = "voxels/inanimate/bedrock/bedrock.png";
      Hardness = Hardness.Unbreakable;
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Earth,
        Value = 5,
        EmitTo = ManaZone.Ambient
      });
    }
  }
}
