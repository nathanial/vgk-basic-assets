from VGK.Modules import ITerrainGenerator, TerrainGenerator
from VGK import World, Chunk
from SimplexNoise import Noise
from UnityEngine import Random, Vector3, Mathf, Debug


class IslandTerrain(TerrainGenerator):
    def CreateVoxels(self, chunk):
        Random.seed = World.currentWorld.seed
        grain_0_offset = Vector3(Random.value * 10000.0, Random.value * 10000.0, Random.value * 10000.0)
        grain_1_offset = Vector3(Random.value * 10000.0, Random.value * 10000.0, Random.value * 10000.0)
        grain_2_offset = Vector3(Random.value * 10000.0, Random.value * 10000.0, Random.value * 10000.0)

        height_base = 10.0
        max_height = 50.0
        height_swing = max_height - height_base

        x = 0
        while x < Chunk.Width:
            y = 0
            while y < Chunk.Height:
                z = 0
                while z < Chunk.Width:
                    pos = Vector3(x,y,z) + chunk.Position.ToVector3()
                    mountain_value = self.CalculateNoiseValue(pos, grain_0_offset, 0.009)
                    distance_from_center = Mathf.Sqrt(pos.x * pos.x + pos.z * pos.z)

                    if mountain_value < 0:
                        mountain_value = 0

                    mountain_value *= height_swing
                    mountain_value += height_base
                    mountain_value -= (distance_from_center * distance_from_center) / 1500.0

                    block_value = self.CalculateNoiseValue(pos, grain_2_offset, 0.025)
                    block_value *= height_swing
                    block_value += height_base
                    block_value /= 2.0

                    if block_value > (y + chunk.Position.y):
                        mountain_value += self.CalculateNoiseValue(pos, grain_2_offset, 0.08) * 5.0 - 2.5
                        if mountain_value >= y:
                            chunk.Voxels[self.GetIndex(x,y,z)] = 2
                    else:
                        mountain_value += self.CalculateNoiseValue(pos, grain_1_offset, 0.05) * 2.5 - 1.25
                        if mountain_value >= (y + chunk.Position.y):
                            chunk.Voxels[self.GetIndex(x,y,z)] = 1
                            if y > 0 and chunk.Voxels[self.GetIndex(x,y-1,z)] == 1:
                                chunk.Voxels[self.GetIndex(x,y-1,z)] = 3
                    z += 1
                y += 1
            x += 1
