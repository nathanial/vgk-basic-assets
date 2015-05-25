using VGK;

namespace VGKBasicAssets {

  public class Glass : VoxelDefinition {    
    public Glass(){
      AllImages = "voxels/inanimate/glass/glass.png";
      Hardness = Hardness.Brittle;
      MaterialName = "GlassMaterial";
    }
  }
}
