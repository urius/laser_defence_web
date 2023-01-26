using UnityEngine;

namespace Src.Common.Providers
{
    public interface IRootGameTransformProvider
    {
        Transform Transform { get; }
    }
}