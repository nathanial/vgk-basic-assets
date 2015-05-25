using VGK;

namespace VGKBasicAssets {

  public class Bookshelf : VoxelDefinition {
    public Bookshelf(){
      SideImage = "voxels/artificial/bookshelf/bookshelf.png";
      TopImage = "voxels/artificial/bookshelf/planks_acacia.png";
      BottomImage = "voxels/artificial/bookshelf/planks_acacia.png";
      // 
      // Flammable = true;
      //
      // Characteristic += new ItemStorage<Book>{
      //   Capacity = 10
      // };
    }
  }

}
