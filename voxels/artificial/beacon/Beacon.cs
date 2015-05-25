using VGK;

namespace VGKBasicAssets {
  public class Beacon : VoxelDefinition {

    public Beacon(){
      Name = "Beacon";
      AllImages = "voxels/artificial/beacon/beacon.png";
      Hardness = Hardness.Brittle;
      MaterialName = "BeaconMaterial";
      Drains.Add(new ManaDrain {
        Mana = ManaKind.Any,
        Max = 10.0,
        Min = 0.0,
        Source = ManaZone.Connection
      });
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Luxen,
        ValueFunction = (entity, position) => {
          return Drains[0].FindValue(entity, position) * 0.1;
        },
        EmitTo = ManaZone.Ambient
      });
      Lights.Add(new VoxelLight {
        Color = "#ffffff",
        Intensity = .5f,
        Range = 20
        // IntensityFunction = (entity, position) => {
        //   return Drains[0].FindValue(entity, position) * 0.25;
        // },
        // RangeFunction = (entity, position) => {
        //   return Drains[0].FindValue(entity, position) * 2;
        // }
      });
    }
  }
}
