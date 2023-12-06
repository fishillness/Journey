using UnityEngine;

namespace Journey
{
    public interface IDependency<T>
    {
        void Construct(T obj);
    }
}