using VGK;

namespace VGKBasicAssets {
  public class Book : VoxelItem {

    public Book(Entity entity) : base (entity) {
      Actions.Add(new Write {
        UI = "Book"
      });
      Actions.Add(new Burn());

      entity.Scale(0.01);
      Hardness = Hardness.Soft;
      var LEATHER = Assets.Voxels["Leather"].Block;
      var PAPER = Assets.Voxels["Paper"].Block;
      for(var x = 0; x < 8; x++){
        for(var y = 0; y < 10; y++){
          if(x == 0){
            for(var z = 0; z < 5; z++){
              entity[x,y,z] = LEATHER;
            }
          } else {
            entity[x,y,0] = LEATHER;
            entity[x,y,1] = PAPER;
            entity[x,y,2] = PAPER;
            entity[x,y,3] = PAPER;
            entity[x,y,4] = LEATHER;
          }
        }
      }
      entity.Freeze();
    }
  }
}
