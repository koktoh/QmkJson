using System.Numerics;

namespace QmkJson.Definitions
{
    public interface IHexNumber<TBase>
        where TBase : INumber<TBase>
    {
        TBase Value { get; }
    }
}
