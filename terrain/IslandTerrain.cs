using VGK.Modules;
using VGK;
using SimplexNoise;
using UnityEngine;
using System;

namespace VGKBasicAssets {
  public class IslandTerrain : TerrainGenerator {
    readonly System.Random _random = new System.Random();
    readonly Vector3 _grain0Offset;
    readonly Vector3 _grain1Offset;
    readonly Vector3 _grain2Offset;

    public IslandTerrain(){
        ViewDistance = 400;
        _grain0Offset = new Vector3(
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0)
        );
        _grain1Offset = new Vector3(
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0)
        );
        _grain2Offset = new Vector3(
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0)
        );
    }

    public override void CreateVoxels(Chunk chunk){
      var heightBase = 10.0f;
      var maxHeight = 50.0f;
      var heightSwing = maxHeight - heightBase;

      var GRASS = Assets.Voxels["Grass"].Block;
      var DIRT = Assets.Voxels["Dirt"].Block;
      var STONE = Assets.Voxels["Stone"].Block;
      var BEACON = Assets.Voxels["Beacon"].Block;

      var i = 0;
      for(var x = 0; x < Chunk.Width; x++){
        for(var y = 0; y < Chunk.Height; y++){
          for(var z = 0; z < Chunk.Width; z++){
            var pos = new Vector3(x,y,z) + chunk.Position.ToVector3();
            var mountainValue = CalculateNoiseValue(pos, _grain0Offset, 0.009f);
            var distanceFromCenter = Mathf.Sqrt(pos.x * pos.x + pos.z * pos.z);

            if(mountainValue < 0){
              mountainValue = 0;
            }

            mountainValue *= heightSwing;
            mountainValue += heightBase;
            mountainValue -= (distanceFromCenter * distanceFromCenter) / (1500.0f * (ViewDistance / 200.0f));

            mountainValue += CalculateNoiseValue(pos, _grain1Offset, 0.05f) * 2.5f - 1.25f;
            if(mountainValue >= (y + chunk.Position.y)){
              if(i % 1000 == 0){
                chunk.Voxels[GetIndex(x,y,z)] = BEACON;
              } else {
                chunk.Voxels[GetIndex(x,y,z)] = GRASS;
              }
              if(y > 0 && chunk.Voxels[GetIndex(x,y-1,z)] == GRASS || chunk.Voxels[GetIndex(x,y-1,z)] == BEACON) {
                chunk.Voxels[GetIndex(x,y-1,z)] = DIRT;
              }
            }
          }
        }
      }
    }
  }
}
