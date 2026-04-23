// using Unity.Collections;
// using Unity.Collections.LowLevel.Unsafe;
// using Unity.Jobs;

// struct MyJob : IJobParallelFor
// {
//     public NativeArray<float> data;

//     public void Execute(int index)
//     {
//         unsafe
//         {
//             float* ptr = (float*)data.GetUnsafePtr();
//             ptr[index] *= 2.0f;
//         }
//     }
// }